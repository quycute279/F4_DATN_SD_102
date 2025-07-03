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
        //private const string BaseApiUrl = "https://localhost:7183/api/LinhKien";
        //private const string ThuocTinhApiUrl = "https://localhost:7183/api/DanhMuc_LinhKien_ThuocTinh";
        //private const string DanhMucApiUrl = "https://localhost:7183/api/DanhMucs";

        public LinhKienController(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient.CreateClient("LK");
        }
        public async Task<IActionResult> Index(Guid? DanhMucId, int pageNumber = 1, string? timkiem = null)
        {
            int pageSize = 8; // Số lượng linh kiện mỗi trang

            // Gọi API để lấy toàn bộ linh kiện
            var linhKiens = await _httpClient.GetFromJsonAsync<List<LinhKien>>("LinhKiens");

            // Lọc theo DanhMucId nếu có
            if (DanhMucId.HasValue)
            {
                linhKiens = linhKiens.Where(x => x.DanhMucId == DanhMucId).ToList();
            }

            // Lọc theo từ khóa tìm kiếm nếu có
            if (!string.IsNullOrEmpty(timkiem))
            {
                linhKiens = linhKiens
                    .Where(x => x.TenLinhKien != null && x.TenLinhKien.Contains(timkiem, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            // Phân trang
            int totalItems = linhKiens.Count;
            var itemsToShow = linhKiens
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            // Gửi ViewBag để phân trang
            ViewBag.CurrentPage = pageNumber;
            ViewBag.TotalPages = (int)Math.Ceiling((double)totalItems / pageSize);
            ViewBag.TimKiem = timkiem;
            ViewBag.DanhMucId = DanhMucId;

            // Gửi danh sách danh mục cho menu
            var danhMucs = await _httpClient.GetFromJsonAsync<List<DanhMuc>>("DanhMucs");
            ViewBag.DanhMucList = danhMucs;

            return View(itemsToShow);
        }


        public async Task<IActionResult> QuanLySanPham(Guid? DanhMucId)
        {
            var linhKiens = await _httpClient.GetFromJsonAsync<List<LinhKien>>("LinhKiens");
            var danhMucs = await _httpClient.GetFromJsonAsync<List<DanhMuc>>("DanhMucs");

            var danhMucDict = danhMucs.ToDictionary(x => x.DanhMucId, x => x.TenDanhMuc);
            ViewBag.DanhMucDict = danhMucDict;

            // Tạo từ điển chứa các thuộc tính của từng danh mục
            Dictionary<Guid, List<DanhMuc_LinhKien_ThuocTinh>> thuocTinhDict = new();

            foreach (var danhMuc in danhMucs)
            {
                var response = await _httpClient.GetAsync($"DanhMucs/{danhMuc.DanhMucId}/thuoc-tinhs");
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    var thuocTinhs = JsonConvert.DeserializeObject<List<DanhMuc_LinhKien_ThuocTinh>>(data);
                    thuocTinhDict[danhMuc.DanhMucId] = thuocTinhs;
                }
            }

            ViewBag.ThuocTinhDict = thuocTinhDict;

            return View(linhKiens);
        }
        //
        [HttpGet]
        public async Task<IActionResult> GetThuocTinhsByDanhMuc(Guid danhMucId)
        {
            var response = await _httpClient.GetAsync($"DanhMucs/{danhMucId}/thuoc-tinhs");
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                return Content(data, "application/json");
            }

            return NotFound();
        }
        // GET: /LinhKien/Create
        //
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var response = await _httpClient.GetAsync("DanhMucs");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var danhMucs = JsonConvert.DeserializeObject<List<DanhMuc>>(jsonData);
                ViewBag.DanhMucs = new SelectList(danhMucs, "DanhMucId", "TenDanhMuc");
            }
            else
            {
                ViewBag.DanhMucs = new SelectList(new List<DanhMuc>(), "DanhMucId", "TenDanhMuc");
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(LinhKien linhKien)
        {
            if (ModelState.IsValid)
            {
                linhKien.TrangThai = true; 
                var response = await _httpClient.PostAsJsonAsync("LinhKiens", linhKien);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("QuanLySanPham", "LinhKien");
                }
            }

            var danhMucResponse = await _httpClient.GetAsync("DanhMucs");
            if (danhMucResponse.IsSuccessStatusCode)
            {
                var jsonData = await danhMucResponse.Content.ReadAsStringAsync();
                var danhMucs = JsonConvert.DeserializeObject<List<DanhMuc>>(jsonData);
                ViewBag.DanhMucs = new SelectList(danhMucs, "DanhMucId", "TenDanhMuc");
            }
            return View(linhKien);
        }
        //
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var linhKien = await _httpClient.GetFromJsonAsync<LinhKien>($"LinhKiens/{id}");
            if (linhKien == null) return NotFound();

            var danhMucsResponse = await _httpClient.GetAsync("DanhMucs");
            if (danhMucsResponse.IsSuccessStatusCode)
            {
                var danhMucs = JsonConvert.DeserializeObject<List<DanhMuc>>(await danhMucsResponse.Content.ReadAsStringAsync());
                ViewBag.DanhMucs = new SelectList(danhMucs, "DanhMucId", "TenDanhMuc", linhKien.DanhMucId);
            }

            var thuocTinhResponse = await _httpClient.GetAsync($"DanhMucs/{linhKien.DanhMucId}/thuoc-tinhs");
            if (thuocTinhResponse.IsSuccessStatusCode)
            {
                ViewBag.ThuocTinhs = JsonConvert.DeserializeObject<List<DanhMuc_LinhKien_ThuocTinh>>(await thuocTinhResponse.Content.ReadAsStringAsync());
            }

            return View(linhKien);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, LinhKien linhKien)
        {
            if (id != linhKien.LkId)
                return BadRequest();

            if (!ModelState.IsValid)
                return View(linhKien);

            var response = await _httpClient.PutAsJsonAsync($"LinhKiens/{id}", linhKien);
            if (response.IsSuccessStatusCode)
                return RedirectToAction("Index");

            ModelState.AddModelError("", "Cập nhật thất bại.");
            return View(linhKien);
        }
    }
}
