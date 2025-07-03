using F4_API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Web_DATN.Controllers
{
    public class ComboController : Controller
    {
        private readonly HttpClient _client;

        public ComboController()
        {
            _client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7183")
            };
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var response = await _client.GetAsync("/api/Combos");
            if (!response.IsSuccessStatusCode)
            {
                ViewBag.loii = "Không thể lấy danh sách combo.";
                return View(new List<Combo>());
            }

            var content = await response.Content.ReadAsStringAsync();
            var combos = JsonSerializer.Deserialize<List<Combo>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return View(combos);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(string Ten, string MoTa, double GiaTien, bool TrangThai)
        {
            if (string.IsNullOrWhiteSpace(Ten))
            {
                ViewBag.loii = "Tên combo không được để trống.";
                return View();
            }

            var combo = new Combo
            {
                ComboId = Guid.NewGuid(),
                Ten = Ten,
                MoTa = MoTa,
                GiaTien = GiaTien,
                TrangThai = TrangThai,
                NgayTao = DateTime.Now
            };

            var response = await _client.PostAsJsonAsync("/api/Combos", combo);
            if (!response.IsSuccessStatusCode)
            {
                ViewBag.loii = "Tạo combo thất bại.";
                return View();
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var response = await _client.GetAsync($"/api/Combos/{id}");
            if (!response.IsSuccessStatusCode)
            {
                ViewBag.loii = "Không tìm thấy combo.";
                return RedirectToAction("Index");
            }

            var combo = await response.Content.ReadFromJsonAsync<Combo>();
            return View(combo);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Guid ComboId, string Ten, string MoTa, double GiaTien, bool TrangThai)
        {
            var combo = new Combo
            {
                ComboId = ComboId,
                Ten = Ten,
                MoTa = MoTa,
                GiaTien = GiaTien,
                TrangThai = TrangThai,
                NgayTao = DateTime.Now
            };

            var response = await _client.PutAsJsonAsync($"/api/Combos/{ComboId}", combo);
            if (!response.IsSuccessStatusCode)
            {
                ViewBag.loii = "Cập nhật combo thất bại.";
                return View(combo);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var response = await _client.DeleteAsync($"/api/Combos/{id}");
            if (!response.IsSuccessStatusCode)
            {
                ViewBag.loii = "Xóa combo thất bại.";
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var response = await _client.GetAsync($"/api/Combos/{id}");
            if (!response.IsSuccessStatusCode)
            {
                ViewBag.loii = "Không tìm thấy combo.";
                return RedirectToAction("Index");
            }

            var combo = await response.Content.ReadFromJsonAsync<Combo>();
            return View(combo);
        }
        //2.7
    }
}
