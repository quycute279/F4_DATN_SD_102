using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using F4_API.DATA;
using F4_API.Models;
using F4_API.Repository.IRepository;

namespace F4_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NhanViensController : ControllerBase
    {
        private readonly INhanVienRepository _repository;

        public NhanViensController(INhanVienRepository context)
        {
            _repository = context;
        }

        // GET: api/NhanViens
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NhanVien>>> GetNhanViens()
        {
            return Ok(await _repository.GetAllNhanVienAsync());
        }

        // GET: api/NhanViens/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NhanVien>> GetNhanVien(Guid id)
        {
            return Ok(await _repository.GetByIdNhanVienAsync(id));
        }

        // PUT: api/NhanViens/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNhanVien(Guid id, NhanVien nhanVien)
        {
            if (id != nhanVien.NhanVienId)
            {
                return BadRequest("Id không khớp với dữ liệu nhân viên.");
            }

            try
            {
                await _repository.UpdateNhanVienAsync(nhanVien);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Lỗi khi cập nhật: {ex.Message}");
            }
        }

        // POST: api/NhanViens
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<NhanVien>> PostNhanVien(NhanVien nhanVien)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _repository.CreateNhanVien(nhanVien);
            return Ok();
        }

        // DELETE: api/NhanViens/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNhanVien(Guid id)
        {
            await _repository.DeleteNhanVienAsync(id);
            return Ok();
        }

        [HttpGet("tk/{taikhoanId}")]
        public async Task<ActionResult<NhanVien>> GetNhanVienByTaiKhoanId(Guid taikhoanId)
        {
            var nhanVien = await _repository.GetIdNhanVienTaiKhoan(taikhoanId);
            if (nhanVien == null)
            {
                return NotFound();
            }

            return Ok(nhanVien);
        }

    }
}
