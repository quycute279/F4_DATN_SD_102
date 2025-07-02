using F4_API.Models.DTO;
using F4_API.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using Web_DATN.Models;

namespace Web_DATN.Controllers
{
    public class LinhKienChiTietController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl = "https://localhost:7183/api/LinhKienChiTiets";

        public LinhKienChiTietController()
        {
            _httpClient = new HttpClient();
        }

        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync(_baseUrl);
            var result = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var data = JsonConvert.DeserializeObject<List<LinhKienCT>>(result);
                return View(data);
            }

            ViewBag.Error = "Không thể tải dữ liệu Chi Tiết Linh Kiện";
            return View(new List<LinhKienCT>());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(LinhKienChiTietsDTO dto)
        {
            var content = new StringContent(JsonConvert.SerializeObject(dto), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(_baseUrl, content);

            if (response.IsSuccessStatusCode)
                return RedirectToAction("Index");

            ViewBag.Error = "Tạo chi tiết linh kiện thất bại.";
            return View(dto);
        }
    }
}
