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
using F4_API.Repository;

namespace F4_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GioHangsController : ControllerBase
    {
        private readonly IGioHangRepository _giohang;

        public GioHangsController(IGioHangRepository giohang)
        {
            _giohang = giohang;
        }
        // GET: api/GioHangs
        [HttpGet]
        public async Task<IActionResult> GetAllGioHang()
        {
            return Ok(await _giohang.GetAllGioHang());
        }

        // GET: api/GioHangs/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGioHangById(Guid id)
        {
            return Ok(await _giohang.GetByIdGioHang(id));
        }

        // PUT: api/GioHangs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(GioHang gioHang)
        {
            await _giohang.UpdateGioHang(gioHang);
            return Ok();

        }
        // POST: api/GioHangs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(GioHang gioHang)
        {
            await _giohang.CreateGioHang(gioHang);
            return Ok();
        }

        // DELETE: api/GioHangs/5

        [HttpDelete("delete/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _giohang.DeleteGioHang(id);
            return Ok();
        }

        [HttpGet("khachhang/{khachHangId}")]
        public async Task<IActionResult> GetGioHangByKhachHangId(Guid khachHangId)
        {
            var gioHang = await _giohang.GetGioHangByKhachHangId(khachHangId);
            if (gioHang == null)
                return NotFound("Không tìm thấy giỏ hàng cho khách hàng này.");

            return Ok(gioHang);
        }
    }
}
