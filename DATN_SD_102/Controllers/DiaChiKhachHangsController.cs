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
using NuGet.Protocol.Core.Types;

namespace F4_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiaChiKhachHangsController : ControllerBase
    {
        private readonly IDiaChiKhachHangRepository _context;

        public DiaChiKhachHangsController(IDiaChiKhachHangRepository context)
        {
            _context = context;
        }

        // GET: api/DiaChiKhachHangs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DiaChiKhachHang>>> GetDiaChiKhachHangs()
        {
            return Ok(await _context.GetAll());
        }

        // GET: api/DiaChiKhachHangs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DiaChiKhachHang>> GetDiaChiKhachHang(Guid id)
        {
            return Ok(await _context.GetById(id));
        }

        // PUT: api/DiaChiKhachHangs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDiaChiKhachHang(Guid id, DiaChiKhachHang diaChiKhachHang)
        {
            if (id != diaChiKhachHang.DiaChiKhachHangId)
                return BadRequest("ID mismatch");

            await _context.Update(diaChiKhachHang);
            return NoContent();
        }

        // POST: api/DiaChiKhachHangs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DiaChiKhachHang>> PostDiaChiKhachHang(DiaChiKhachHang diaChiKhachHang)
        {
            await _context.Add(diaChiKhachHang);
            return Ok();
        }

        // DELETE: api/DiaChiKhachHangs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDiaChiKhachHang(Guid id)
        {
           await _context.DeleteById(id);
            return Ok();
        }

    }
}
