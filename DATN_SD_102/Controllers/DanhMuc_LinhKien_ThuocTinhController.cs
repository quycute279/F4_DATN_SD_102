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
            return await _context.DanhMuc_LinhKien_ThuocTinhs
                .Include(x => x.DanhMuc)
                .ToListAsync();
        }

        // GET: api/DanhMuc_LinhKien_ThuocTinh/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<DanhMuc_LinhKien_ThuocTinh>> GetById(Guid id)
        {
            var item = await _context.DanhMuc_LinhKien_ThuocTinhs
                .Include(x => x.DanhMuc)
                .FirstOrDefaultAsync(x => x.DanhMucId == id);

            if (item == null) return NotFound();

            return item;
        }

        // GET theo DanhMucId để load thuộc tính khi tạo linh kiện
        [HttpGet("danhmuc/{danhMucId}")]
        public async Task<ActionResult<IEnumerable<DanhMuc_LinhKien_ThuocTinh>>> GetByDanhMuc(Guid danhmucId)
        {
            var list = await _context.DanhMuc_LinhKien_ThuocTinhs
                .Where(x => x.DanhMucId == danhmucId && x.TrangThai)
                .ToListAsync();

            return Ok(list);
        }

        // POST: api/DanhMuc_LinhKien_ThuocTinh
        [HttpPost]
        public async Task<ActionResult<DanhMuc_LinhKien_ThuocTinh>> Create(DanhMuc_LinhKien_ThuocTinh model)
        {
            model.ThuocTinh = Guid.NewGuid();
            _context.DanhMuc_LinhKien_ThuocTinhs.Add(model);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = model.ThuocTinh }, model);
        }

        // PUT: api/DanhMuc_LinhKien_ThuocTinh/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, DanhMuc_LinhKien_ThuocTinh model)
        {
            if (id != model.ThuocTinh) return BadRequest();

            _context.Entry(model).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Exists(id)) return NotFound();
                else throw;
            }

            return NoContent();
        }

        // DELETE: api/DanhMuc_LinhKien_ThuocTinh/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var item = await _context.DanhMuc_LinhKien_ThuocTinhs.FindAsync(id);
            if (item == null) return NotFound();

            _context.DanhMuc_LinhKien_ThuocTinhs.Remove(item);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Exists(Guid id)
        {
            return _context.DanhMuc_LinhKien_ThuocTinhs.Any(e => e.ThuocTinh == id);
        }
    }
}
