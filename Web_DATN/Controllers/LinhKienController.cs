using F4_API.Models;
using F4_API.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Web_DATN.Controllers
{
    public class LinhKienController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseApiUrl = "https://localhost:7183/api/LinhKiens";
        public LinhKienController()
        {
            _httpClient = new HttpClient();
        }
        public async Task<IActionResult> Index()
        {
            List<LinhKien> linhKiens = new List<LinhKien>();
            var response = await _httpClient.GetAsync(_baseApiUrl);

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                linhKiens = JsonConvert.DeserializeObject<List<LinhKien>>(jsonData)!;
            }
            else
            {
                ViewBag.Error = "Không thể lấy dữ liệu từ API";
            }

            return View(linhKiens);
        }

        [HttpPost]
        public async Task<IActionResult> Create(LinhKien model)
        {
            var dto = new LinhKienDTO
            {
                TenLinhKien = model.TenLinhKien,
                DanhMucId = model.DanhMucId,
                Gia = model.Gia,
                MoTa = model.MoTa,
                TrangThai = true,
                linhKienCTs = model.ChiTiets.Select(ct => new LinhKienChiTietsDTO
                {
                    ThuocTinhId = ct.ThuocTinhId,
                    GiaTri = ct.GiaTri,
                    MoTa = ct.MoTa,
                    TrangThai = ct.TrangThai
                }).ToList()
            };

            var content = new StringContent(JsonConvert.SerializeObject(dto), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(_baseApiUrl, content);

            if (response.IsSuccessStatusCode)
                return RedirectToAction("Index");

            ViewBag.Error = "Không thể tạo mới linh kiện.";
            return View(model);
        }

    }
}
