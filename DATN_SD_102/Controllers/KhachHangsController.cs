using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using F4_API.DATA;
using F4_API.Models;

namespace F4_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KhachHangsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public KhachHangsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/KhachHangs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<KhachHang>>> GetAllKhachHangs()
        {
            return await _context.Set<KhachHang>()
              .Include(k => k.TaiKhoan)
              .Include(k => k.HoaDons)
              .Include(k => k.GioHangs)
              .Include(k => k.DiaChiKhachHangs)
              .ToListAsync();
        }

        // GET: api/KhachHangs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<KhachHang>> GetKhachHang(Guid id)
        {
            var khachHang = await _context.Set<KhachHang>()
                .Include(k => k.TaiKhoan)
                .Include(k => k.HoaDons)
                .Include(k => k.GioHangs)
                .Include(k => k.DiaChiKhachHangs)
                .FirstOrDefaultAsync(k => k.KhachHangId == id);

            if (khachHang == null)
            {
                return NotFound();
            }

            return khachHang;
        }

        // PUT: api/KhachHangs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKhachHang(Guid id, KhachHang khachHang)
        {
            if (id != khachHang.KhachHangId)
            {
                return BadRequest("ID không trùng khớp.");
            }

            var khachHangExist = await _context.KhachHangs.FindAsync(id);
            if (khachHangExist == null)
            {
                return NotFound();
            }

            // Update thủ công các field
            khachHangExist.TenKhachHang = khachHang.TenKhachHang;
            khachHangExist.Email = khachHang.Email;
            khachHangExist.Sdt = khachHang.Sdt;
            khachHangExist.GioiTinh = khachHang.GioiTinh;
            khachHangExist.NgayTao = DateTime.UtcNow; ;
            khachHangExist.TrangThai = khachHang.TrangThai;
            khachHangExist.TaiKhoanId = khachHang.TaiKhoanId;
            khachHangExist.NgayCapNhatCuoiCung = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        // POST: api/KhachHangs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<KhachHang>> PostKhachHang(KhachHang khachHang)
        {
            khachHang.KhachHangId = Guid.NewGuid();
            khachHang.NgayTao = DateTime.UtcNow;
            khachHang.NgayCapNhatCuoiCung = DateTime.UtcNow;

            _context.KhachHangs.Add(khachHang);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetKhachHang), new { id = khachHang.KhachHangId }, khachHang);
        }

        // DELETE: api/KhachHangs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKhachHang(Guid id)
        {
            var khachHang = await _context.KhachHangs.FindAsync(id);
            if (khachHang == null)
            {
                return NotFound();
            }

            _context.KhachHangs.Remove(khachHang);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<KhachHang>>> SearchKhachHang(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
             
                return Ok(await _context.KhachHangs
                    .Include(kh => kh.TaiKhoan)
                    .Include(kh => kh.HoaDons)
                    .Include(kh => kh.GioHangs)
                    .Include(kh => kh.DiaChiKhachHangs)
                    .ToListAsync());
            }

            // Tìm theo Họ tên (lowercase)
            keyword = keyword.ToLower();

            var result = await _context.KhachHangs
                .Include(kh => kh.TaiKhoan)
                .Include(kh => kh.HoaDons)
                .Include(kh => kh.GioHangs)
                .Include(kh => kh.DiaChiKhachHangs)
                .Where(kh => kh.TenKhachHang.ToLower().Contains(keyword))
                .ToListAsync();

            return Ok(result);
        }
    }
}
