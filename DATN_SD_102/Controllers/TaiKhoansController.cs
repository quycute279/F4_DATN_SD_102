using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using F4_API.DATA;
using F4_API.Models;
using F4_API.Models.DTO;
using F4_API.Repository.IRepository;

namespace F4_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaiKhoansController : ControllerBase
    {
        private readonly ITaiKhoanRepository _context;
        private readonly INhanVienRepository _nhanVienRepository;
        private readonly IChucVuRepository _chucVuRepository;
        private readonly IKhachHangRepository _khachHangrepo;

        public TaiKhoansController(ITaiKhoanRepository context, INhanVienRepository nhanVienRepository, IChucVuRepository chucVuRepository, IKhachHangRepository khachHangrepo  )
        {
            _context = context;
            _nhanVienRepository = nhanVienRepository;
            _chucVuRepository = chucVuRepository;
            _khachHangrepo = khachHangrepo;
        }


        // GET: api/TaiKhoans
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaiKhoan>>> GetTaiKhoans()
        {
            return Ok(await _context.GetAllTaiKhoanAsync());
        }

        // GET: api/TaiKhoans/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TaiKhoan>> GetTaiKhoan(Guid id)
        {
            return Ok(await _context.GetByIdTaiKhoanAsync(id));
        }

        // PUT: api/TaiKhoans/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTaiKhoan(Guid id, TaiKhoan taiKhoan)
        {
            await _context.UpdateTaiKhoanAsync(taiKhoan);
            return Ok();
        }

        // POST: api/TaiKhoans
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TaiKhoan>> PostTaiKhoan(TaiKhoan taiKhoan)
        {
            await _context.CreateTaiKhoanAsync(taiKhoan);
            return Ok();
        }

        // DELETE: api/TaiKhoans/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaiKhoan(Guid id)
        {
            await _context.DeleteTaiKhoanAsync(id);
            return Ok();
        }

        [HttpGet("username/{username}")]
        public async Task<ActionResult<TaiKhoan>> GetTaiKhoanByUsername(string username)
        {
            var taiKhoan = await _context.GetByUsernameAsync(username);
            Console.WriteLine($"Username received: {username}, Found: {taiKhoan != null}");

            if (taiKhoan == null)
            {
                return NotFound();
            }
            return Ok(taiKhoan);
        }

        [HttpGet("login")]
        public async Task<ActionResult<LoginResponseDTO>> Login(string username, string pass)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new LoginResponseDTO
                {
                    IsSuccess = false,
                    Message = "Dữ liệu đăng nhập không hợp lệ."
                });
            }

            var taiKhoan = await _context.GetByIdChucVuAsync(username, pass);
            if (taiKhoan == null)
            {
                return Unauthorized(new LoginResponseDTO
                {
                    IsSuccess = false,
                    Message = "Sai tên đăng nhập hoặc mật khẩu."
                });
            }

            // Kiểm tra Nhân viên
            var nhanVien = await _nhanVienRepository.GetIdNhanVienTaiKhoan(taiKhoan.TaiKhoanId);
            if (nhanVien != null && nhanVien.ChucVuId != null)
            {
                var chucVu = await _chucVuRepository.GetByIdChucVuAsync(nhanVien.ChucVuId.Value);
                return Ok(new LoginResponseDTO
                {
                    IsSuccess = true,
                    Username = username,
                    Role = chucVu?.TenChucVu ?? "NhanVien",
                    Message = "Đăng nhập thành công (nhân viên)!"
                });
            }

            // Kiểm tra Khách hàng
            var khachHang = await _context.GetKhachHangByTaiKhoanIdAsync(taiKhoan.TaiKhoanId);
            if (khachHang != null)
            {
                return Ok(new LoginResponseDTO
                {
                    IsSuccess = true,
                    Username = username,
                    Role = "KhachHang",
                    Message = "Đăng nhập thành công (khách hàng)!"
                });
            }

            return BadRequest(new LoginResponseDTO
            {
                IsSuccess = false,
                Message = "Tài khoản không có thông tin người dùng hợp lệ."
            });
        }

    }
}
