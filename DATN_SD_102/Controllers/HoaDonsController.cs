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
    public class HoaDonsController : ControllerBase
    {
        private readonly IHoaDonRepository _context;

        public HoaDonsController(IHoaDonRepository hoaDonRepo)
        {
            _context = hoaDonRepo;
        }

        // GET: api/HoaDons
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HoaDon>>> GetHoaDons()
        {
            var hoaDons = await _context.GetAll();
            return Ok(hoaDons);
        }

        // GET: api/HoaDons/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HoaDon>> GetHoaDonById(Guid id)
        {
            var hoaDon = await _context.GetById(id);
            if (hoaDon == null)
                return NotFound();

            return Ok(hoaDon);
        }

        // PUT: api/HoaDons/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHoaDon(Guid id, HoaDon hoaDon)
        {
            if (id != hoaDon.HoaDonId)
                return BadRequest("ID mismatch");

            await _context.Update(hoaDon);
            return NoContent();
        }

        // POST: api/HoaDons
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HoaDon>> CreateHoaDon(HoaDon hoaDon)
        {
            await _context.Create(hoaDon);
            return CreatedAtAction(nameof(GetHoaDonById), new { id = hoaDon.HoaDonId }, hoaDon);
        }

        // DELETE: api/HoaDons/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHoaDon(Guid id)
        {
            var result = await _context.Delete(id);
            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}
