using F4_API.Models;
using F4_API.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;
using Web_DATN.ViewModels;

namespace Web_DATN.Controllers
{
    public class LinhKienController : Controller
    {
        private readonly HttpClient _httpClient;
        private const string BaseApiUrl = "https://localhost:7183/api/LinhKiens";
        private const string ThuocTinhApiUrl = "https://localhost:7183/api/DanhMuc_LinhKien_ThuocTinh";
        private const string DanhMucApiUrl = "https://localhost:7183/api/DanhMucs";

        public LinhKienController()
        {
            _httpClient = new HttpClient();
        }

        // Hiển thị danh sách linh kiện
        public async Task<IActionResult> Index(Guid? loaiSanPham)
        {
            var url = loaiSanPham.HasValue
                ? $"{BaseApiUrl}/by-category/{loaiSanPham.Value}"
                : BaseApiUrl;

            var response = await _httpClient.GetAsync(url);
            var linhKiens = new List<LinhKien>();

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                linhKiens = JsonConvert.DeserializeObject<List<LinhKien>>(json)!;
            }

            return View(linhKiens);
        }

        // GET: /LinhKien/Create
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var vm = new LinhKienFullViewModel
            {
                DanhMucs = await GetDanhMucSelectList(),
                ThuocTinhs = new List<LinhKienThuocTinhCreateViewModel>()
            };
            return View(vm);
        }

        // POST: /LinhKien/Create
        [HttpPost]
        public async Task<IActionResult> Create(LinhKienFullViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                vm.DanhMucs = await GetDanhMucSelectList();
                return View(vm);
            }

            var dto = new LinhKienDTO
            {
                TenLinhKien = vm.TenLinhKien,
                DanhMucId = vm.DanhMucId,
                Gia = vm.Gia,
                MoTa = vm.MoTa,
                TrangThai = vm.TrangThai,
                linhKienCTs = vm.ThuocTinhs.Select(ct => new LinhKienChiTietsDTO
                {
                    ThuocTinhId = ct.ThuocTinhId,
                    GiaTri = ct.GiaTri,
                    MoTa = ct.MoTa,
                    TrangThai = ct.TrangThai
                }).ToList()
            };

            var content = new StringContent(JsonConvert.SerializeObject(dto), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(BaseApiUrl, content);

            if (response.IsSuccessStatusCode)
                return RedirectToAction(nameof(Index));

            ViewBag.Error = "Không thể tạo mới linh kiện.";
            vm.DanhMucs = await GetDanhMucSelectList();
            return View(vm);
        }

        // AJAX: Lấy thuộc tính theo DanhMucId
        [HttpGet]
        public async Task<IActionResult> GetThuocTinhsTheoDanhMuc(string danhMucId)
        {
            var response = await _httpClient.GetAsync($"{ThuocTinhApiUrl}/{danhMucId}");
            if (!response.IsSuccessStatusCode)
                return Json(new List<object>());

            var json = await response.Content.ReadAsStringAsync();
            return Content(json, "application/json");
        }

        // Helper: load dropdown DanhMuc
        private async Task<List<SelectListItem>> GetDanhMucSelectList()
        {
            var response = await _httpClient.GetAsync(DanhMucApiUrl);
            var list = new List<SelectListItem>();
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<List<DanhMuc>>(json)!;
                list = data.Select(dm => new SelectListItem
                {
                    Value = dm.DanhMucId.ToString(),
                    Text = dm.TenDanhMuc
                }).ToList();
            }
            return list;
        }
    }
}
