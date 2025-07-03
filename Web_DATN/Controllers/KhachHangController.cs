using F4_API.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using Web_DATN.Models; // Giả sử model KhachHang ở đây

namespace Web_DATN.Controllers
{
    public class KhachHangController : Controller
    {

        public async Task<IActionResult> Index()
        {
            List<KhachHang> khachhang = new List<KhachHang>();

            using (var http = new HttpClient())
            {
                http.BaseAddress = new Uri("https://localhost:7183/");
                var response = await http.GetAsync("api/KhachHangs");

                if (response.IsSuccessStatusCode)
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    khachhang = JsonConvert.DeserializeObject<List<KhachHang>>(apiResponse);
                }
            }

            return View(khachhang);
        }

        // GET: KhachHang/Edit/{id}
        public async Task<IActionResult> Edit(Guid id)
        {
            using (var http = new HttpClient())
            {
                http.BaseAddress = new Uri("https://localhost:7183/");
                var response = await http.GetAsync($"api/KhachHangs/{id}");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var khachHang = JsonConvert.DeserializeObject<KhachHang>(json);
                    return View(khachHang);
                }
                return NotFound();
            }
        }

        // POST: KhachHang/Edit/{id}
        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, KhachHang model)
        {
            if (id != model.KhachHangId)
                return BadRequest();

            using (var http = new HttpClient())
            {
                http.BaseAddress = new Uri("https://localhost:7183/");
                var json = JsonConvert.SerializeObject(model);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await http.PutAsync($"api/KhachHangs/{id}", content);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            ModelState.AddModelError("", "Lỗi cập nhật khách hàng");
            return View(model);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            using (var http = new HttpClient())
            {
                http.BaseAddress = new Uri("https://localhost:7183/");
                var response = await http.DeleteAsync($"api/KhachHangs/{id}");

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            TempData["Error"] = "Không thể xóa khách hàng.";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(KhachHang khachHang)
        {
            if (!ModelState.IsValid)
            {
                return View(khachHang);
            }

            khachHang.KhachHangId = Guid.NewGuid();
            khachHang.NgayTao = DateTime.UtcNow;
            khachHang.NgayCapNhatCuoiCung = DateTime.UtcNow;

            // Xóa navigation để tránh serialize lỗi
            khachHang.TaiKhoan = null;
            khachHang.HoaDons = null;
            khachHang.GioHangs = null;
            khachHang.DiaChiKhachHangs = null;

            using (var http = new HttpClient())
            {
                // ✅ Bắt buộc phải có dòng này
                http.BaseAddress = new Uri("https://localhost:7183/");

                var jsonContent = new StringContent(JsonConvert.SerializeObject(khachHang), Encoding.UTF8, "application/json");
                var response = await http.PostAsync("api/KhachHangs", jsonContent);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            ModelState.AddModelError("", "Tạo khách hàng thất bại.");
            return View(khachHang);
        }

    }
}

