using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using F4_API.Models;
using F4_API.Repository.IRepository;

namespace F4_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GiamGiaController : ControllerBase
    {
        private readonly IGiamGiaRepository _context;

        public GiamGiaController(IGiamGiaRepository context)
        {
            _context = context;
        }

        // GET: api/GiamGia
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GiamGia>>> GetAll()
        {
            var result = await _context.GetAllGiamGia();
            return Ok(result);
        }

        // GET: api/GiamGia/active
        [HttpGet("active")]
        public async Task<ActionResult<IEnumerable<GiamGia>>> GetActive()
        {
            var result = await _context.GetActiveGiamGia();
            return Ok(result);
        }

        // GET: api/GiamGia/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<GiamGia>> GetById(Guid id)
        {
            var result = await _context.GetByIdGiamGia(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        // POST: api/GiamGia
        [HttpPost]
        public async Task<IActionResult> Create(GiamGia entity)
        {
            await _context.CreateGiamGia(entity);
            return Ok();
        }

        // PUT: api/GiamGia/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, GiamGia entity)
        {
            if (id != entity.GiamGiaId)
                return BadRequest("ID không khớp");

            await _context.UpdateGiamGia(entity);
            return NoContent();
        }

        // DELETE: api/GiamGia/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _context.DeleteGiamGia(id);
            return Ok();
        }
        //2.7
    }
}
