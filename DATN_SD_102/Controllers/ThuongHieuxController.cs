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
    public class ThuongHieuxController : ControllerBase
    {
        private readonly IThuongHieuRepository _context;

        public ThuongHieuxController(IThuongHieuRepository context)
        {
            _context = context;
        }

        // GET: api/ThuongHieux
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ThuongHieu>>> GetThuongHieus()
        {
            return Ok(await _context.GetAllAsync());
        }

        // GET: api/ThuongHieux/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ThuongHieu>> GetThuongHieu(Guid id)
        {
            return Ok(await _context.GetByIdAsync(id));
        }

        // PUT: api/ThuongHieux/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutThuongHieu(Guid id, ThuongHieu thuongHieu)
        {
            if (id != thuongHieu.ThuongHieuId)
                return BadRequest("ID mismatch");

            await _context.UpdateAsync(thuongHieu);
            return NoContent();
        }

        // POST: api/ThuongHieux
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ThuongHieu>> PostThuongHieu(ThuongHieu thuongHieu)
        {
            await _context.AddAsync(thuongHieu);
            return Ok();
        }

        // DELETE: api/ThuongHieux/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteThuongHieu(Guid id)
        {
            await _context.DeleteAsync(id);
            return Ok();
        }

      
    }
}
