using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Web_DATN.Models;
using F4_API.DATA;
using Microsoft.EntityFrameworkCore;
using F4_API.Models;

namespace Web_DATN.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _dbContext;

        public HomeController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index(Guid? loaiSanPham)
        {
            // Lấy danh mục để đưa vào ViewBag cho Layout
            var danhMucList = _dbContext.DanhMucs
                                        .OrderBy(x => x.TenDanhMuc)
                                        .ToList();
            ViewBag.DanhMucList = danhMucList;

            // Truy vấn danh sách linh kiện theo danh mục (nếu có)
            var query = _dbContext.LinhKiens
                .Include(m => m.ChiTiets)
                .Include(m => m.DanhMuc)
                .Where(m => m.DanhMuc != null);

            if (loaiSanPham.HasValue)
            {
                query = query.Where(m => m.DanhMucId == loaiSanPham.Value);
            }

            List<LinhKien> sanPhamList;

            if (!loaiSanPham.HasValue)
            {
                sanPhamList = query
                    .AsEnumerable()
                    .GroupBy(m => m.DanhMuc?.TenDanhMuc ?? "Không xác định")
                    .Select(g => g.Take(6))
                    .SelectMany(g => g)
                    .ToList();
            }
            else
            {
                sanPhamList = query.ToList();
            }

            return View(sanPhamList);
        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });
        }
    }
}
