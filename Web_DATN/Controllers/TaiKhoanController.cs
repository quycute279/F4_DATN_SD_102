using F4_API.DATA;
using F4_API.Models;
using F4_API.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace Web_DATN.Controllers
{
    public class TaiKhoanController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string tk, string mk)
        {
            if (string.IsNullOrWhiteSpace(tk) || string.IsNullOrWhiteSpace(mk))
            {
                ViewBag.loii = "Vui lòng nhập đầy đủ tài khoản và mật khẩu.";
                return View();
            }

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7183");
                var response = await client.GetAsync($"/api/TaiKhoans/login?username={tk}&pass={mk}");

                if (!response.IsSuccessStatusCode)
                {
                    ViewBag.loii = "Sai tài khoản hoặc mật khẩu.";
                    return View();
                }

                var content = await response.Content.ReadAsStringAsync();
                var loginResponse = JsonSerializer.Deserialize<LoginResponseDTO>(content,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                if (loginResponse == null || !loginResponse.IsSuccess)
                {
                    ViewBag.loii = loginResponse?.Message ?? "Đăng nhập thất bại.";
                    return View();
                }

                // Lưu thông tin session
                HttpContext.Session.SetString("username", loginResponse.Username);
                HttpContext.Session.SetString("Role", loginResponse.Role ?? "");

                // Điều hướng theo role
                if (loginResponse.Role == "KhachHang")
                {
                    HttpContext.Session.SetString("Role", "KhachHang");
                    HttpContext.Session.SetString("MaKhachHang", loginResponse.Username); // hoặc ID nếu có
                    HttpContext.Session.SetString("TenKhachHang", loginResponse.Username);
                    return RedirectToAction("Index", "KhachHang");
                }
                //else if (loginResponse.Role == "Admin")
                //{
                //    HttpContext.Session.SetString("Role", "Admin");
                //    HttpContext.Session.SetString("TenNguoiDung", loginResponse.Username);
                //    return RedirectToAction("DangKyNhanVien", "TaiKhoan");
                //}
                else if (loginResponse.Role == "Admin")
                {
                    HttpContext.Session.SetString("Role", "Admin");
                    HttpContext.Session.SetString("TenNguoiDung", loginResponse.Username);
                    return RedirectToAction("Dashboard", "Admin"); // CHUYỂN ĐẾN TRANG QUẢN TRỊ
                }
                else if (loginResponse.Role == "NhanVien")
                {
                    HttpContext.Session.SetString("Role", "NhanVien");
                    HttpContext.Session.SetString("TenNguoiDung", loginResponse.Username);
                    return RedirectToAction("DangKyNhanVien", "TaiKhoan");
                }
                else
                {
                    ViewBag.loii = "Chức vụ không xác định.";
                    return View();
                }
            }
        }


        private bool VerifyPassword(string inputPassword, string storedPassword)
        {
            return inputPassword == storedPassword;
        }
        public IActionResult DangKy()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DangKy(string Email, string Ten, string SoDienThoai, string Tk, string MK1, string MK2, string GioiTinh, DateTime NgayTao, DateTime ngaycapnhat)
        {
            if (string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Ten) || string.IsNullOrWhiteSpace(Tk) ||
                string.IsNullOrWhiteSpace(MK1) || string.IsNullOrWhiteSpace(MK2))
            {
                ViewBag.loii = "Vui lòng điền đầy đủ thông tin.";
                return View();
            }

            if (MK1 != MK2)
            {
                ViewBag.loii = "Mật khẩu không trùng khớp.";
                return View();
            }

            // Kiểm tra tài khoản đã tồn tại
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7183");
                var response = await client.GetAsync($"/api/TaiKhoans/username/{Tk}");
                if (response.IsSuccessStatusCode)
                {
                    ViewBag.loii = "Tài khoản đã tồn tại.";
                    return View();
                }
            }

            // Tạo taiKhoan 1 lần duy nhất
            var taiKhoan = new TaiKhoan
            {
                TaiKhoanId = Guid.NewGuid(),
                Username = Tk,
                Password = MK1,
                NgayTaoTaiKhoan = DateTime.Now
            };

            var khachHang = new KhachHang
            {
                TenKhachHang = Ten,
                Email = Email,
                Sdt = SoDienThoai,
                NgayTao = NgayTao,
                NgayCapNhatCuoiCung = ngaycapnhat,
                GioiTinh = GioiTinh == "Nam",
                TrangThai = true,
                TaiKhoanId = taiKhoan.TaiKhoanId
            };

            // Tạo tài khoản trước
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7183");
                var response = await client.PostAsJsonAsync("/api/TaiKhoans", taiKhoan);
                if (!response.IsSuccessStatusCode)
                {
                    ViewBag.loii = "Lỗi tạo tài khoản.";
                    return View();
                }
            }

            // Sau đó mới tạo khách hàng
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7183");
                var response = await client.PostAsJsonAsync("/api/KhachHangs", khachHang);
                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    ViewBag.loii = "Lỗi tạo khách hàng: " + errorContent;
                    return View();
                }
            }


            return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult DangKyNhanVien()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DangKyNhanVien(string Email,string HoVaTen,string SoDienThoai,string DiaChi,string Tk,  string MK1,  string MK2,  string GioiTinh,  DateTime NgaySinh,  DateTime NgayTao,DateTime NgayCapNhat)
        {
            if (string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(HoVaTen) ||
                string.IsNullOrWhiteSpace(Tk) || string.IsNullOrWhiteSpace(MK1) || string.IsNullOrWhiteSpace(MK2))
            {
                ViewBag.loii = "Vui lòng điền đầy đủ thông tin.";
                return View();
            }

            if (MK1 != MK2)
            {
                ViewBag.loii = "Mật khẩu không trùng khớp.";
                return View();
            }

            // Kiểm tra tài khoản đã tồn tại
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7183");
                var response = await client.GetAsync($"/api/TaiKhoans/username/{Tk}");
                if (response.IsSuccessStatusCode)
                {
                    ViewBag.loii = "Tài khoản đã tồn tại.";
                    return View();
                }
            }

            // Tạo tài khoản
            var taiKhoan = new TaiKhoan
            {
                TaiKhoanId = Guid.NewGuid(),
                Username = Tk,
                Password = MK1,
                NgayTaoTaiKhoan = DateTime.Now
            };

            // Gán sẵn ChucVuId mặc định
            var ChucVuId = Guid.Parse("22222222-2222-2222-2222-222222222222");

            // Tạo nhân viên
            var nhanVien = new NhanVien
            {
                NhanVienId = Guid.NewGuid(),
                HoVaTen = HoVaTen,
                GioiTinh = GioiTinh == "Nam",
                Sdt = SoDienThoai,
                DiaChi = DiaChi,
                Email = Email,
                NgaySinh = NgaySinh,
                NgayTao = NgayTao,
                NgayCapNhatCuoiCung = NgayCapNhat,
                TrangThai = true,
                ChucVuId = ChucVuId,
                TaiKhoanId = taiKhoan.TaiKhoanId
            };

            // Gửi API tạo tài khoản trước
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7183");
                var response = await client.PostAsJsonAsync("/api/TaiKhoans", taiKhoan);
                if (!response.IsSuccessStatusCode)
                {
                    ViewBag.loii = "Lỗi tạo tài khoản.";
                    return View();
                }
            }

            // Gửi API tạo nhân viên sau
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7183");
                var response = await client.PostAsJsonAsync("/api/NhanViens", nhanVien);
                if (!response.IsSuccessStatusCode)
                {
                    var error = await response.Content.ReadAsStringAsync();
                    ViewBag.loii = "Lỗi tạo nhân viên: " + error;
                    return View();
                }
            }

            return RedirectToAction("Login");
        }



    }
}
