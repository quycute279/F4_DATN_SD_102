using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using F4_API.DATA;
using F4_API.Models;

namespace F4_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DanhMuc_LinhKien_ThuocTinhController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DanhMuc_LinhKien_ThuocTinhController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/DanhMuc_LinhKien_ThuocTinh
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DanhMuc_LinhKien_ThuocTinh>>> GetAll()
        {
            return await _context.DanhMuc_LinhKien_ThuocTinhs.ToListAsync();
        }

        // GET: api/DanhMuc_LinhKien_ThuocTinh/thuoc-tinh/{danhMucId}
        [HttpGet("thuoc-tinh/{danhMucId}")]
        public async Task<IActionResult> GetThuocTinhTheoDanhMuc(Guid danhMucId)
        {
            var thuocTinhs = await _context.DanhMuc_LinhKien_ThuocTinhs
                .Where(x => x.DanhMucId == danhMucId)
                .Select(x => new
                {
                    ThuocTinhId = x.ThuocTinh,
                    TenThuocTinh = x.TenThuocTinh
                })
                .ToListAsync();

            return Ok(thuocTinhs);
        }

        // GET: api/DanhMuc_LinhKien_ThuocTinh/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<DanhMuc_LinhKien_ThuocTinh>> Get(Guid id)
        {
            var item = await _context.DanhMuc_LinhKien_ThuocTinhs.FindAsync(id);
            if (item == null) return NotFound();
            return item;
        }

        // POST: api/DanhMuc_LinhKien_ThuocTinh
        [HttpPost]
        public async Task<ActionResult<DanhMuc_LinhKien_ThuocTinh>> Post(DanhMuc_LinhKien_ThuocTinh model)
        {
            _context.DanhMuc_LinhKien_ThuocTinhs.Add(model);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = model.ThuocTinh }, model);
        }

        // PUT: api/DanhMuc_LinhKien_ThuocTinh/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, DanhMuc_LinhKien_ThuocTinh model)
        {
            if (id != model.ThuocTinh)
                return BadRequest();

            _context.Entry(model).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.DanhMuc_LinhKien_ThuocTinhs.Any(e => e.ThuocTinh == id))
                    return NotFound();

                throw;
            }

            return NoContent();
        }

        // DELETE: api/DanhMuc_LinhKien_ThuocTinh/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var item = await _context.DanhMuc_LinhKien_ThuocTinhs.FindAsync(id);
            if (item == null)
                return NotFound();

            _context.DanhMuc_LinhKien_ThuocTinhs.Remove(item);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
