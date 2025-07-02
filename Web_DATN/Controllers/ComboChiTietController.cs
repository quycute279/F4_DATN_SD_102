using F4_API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Web_DATN.Controllers
{
    public class ComboChiTietController : Controller
    {
        private readonly HttpClient _client;

        public ComboChiTietController()
        {
            _client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7183")
            };
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var response = await _client.GetAsync("/api/ComboChiTiets");
            if (!response.IsSuccessStatusCode)
            {
                ViewBag.loii = "Không thể tải danh sách combo chi tiết.";
                return View(new List<ComboChiTiet>());
            }

            var content = await response.Content.ReadAsStringAsync();
            var data = JsonSerializer.Deserialize<List<ComboChiTiet>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Guid ComboId, Guid LinhKienId, int SoLuong)
        {
            if (ComboId == Guid.Empty || LinhKienId == Guid.Empty || SoLuong <= 0)
            {
                ViewBag.loii = "Vui lòng nhập đầy đủ và hợp lệ thông tin.";
                return View();
            }

            var comboChiTiet = new ComboChiTiet
            {
                ComboChiTietId = Guid.NewGuid(),
                ComboId = ComboId,
                LinhKienId = LinhKienId,
                SoLuong = SoLuong
            };

            var response = await _client.PostAsJsonAsync("/api/ComboChiTiets", comboChiTiet);
            if (!response.IsSuccessStatusCode)
            {
                ViewBag.loii = "Lỗi khi tạo combo chi tiết.";
                return View();
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var response = await _client.GetAsync($"/api/ComboChiTiets/{id}");
            if (!response.IsSuccessStatusCode)
            {
                ViewBag.loii = "Không tìm thấy combo chi tiết.";
                return RedirectToAction("Index");
            }

            var item = await response.Content.ReadFromJsonAsync<ComboChiTiet>();
            return View(item);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Guid ComboChiTietId, Guid ComboId, Guid LinhKienId, int SoLuong)
        {
            var comboChiTiet = new ComboChiTiet
            {
                ComboChiTietId = ComboChiTietId,
                ComboId = ComboId,
                LinhKienId = LinhKienId,
                SoLuong = SoLuong
            };

            var response = await _client.PutAsJsonAsync($"/api/ComboChiTiets/{ComboChiTietId}", comboChiTiet);
            if (!response.IsSuccessStatusCode)
            {
                ViewBag.loii = "Lỗi khi cập nhật combo chi tiết.";
                return View(comboChiTiet);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var response = await _client.DeleteAsync($"/api/ComboChiTiets/{id}");
            if (!response.IsSuccessStatusCode)
            {
                ViewBag.loii = "Xóa combo chi tiết thất bại.";
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var response = await _client.GetAsync($"/api/ComboChiTiets/{id}");
            if (!response.IsSuccessStatusCode)
            {
                ViewBag.loii = "Không tìm thấy combo chi tiết.";
                return RedirectToAction("Index");
            }

            var item = await response.Content.ReadFromJsonAsync<ComboChiTiet>();
            return View(item);
            //2.7
        }
    }
}
