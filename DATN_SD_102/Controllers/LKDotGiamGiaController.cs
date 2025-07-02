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
    public class LKDotGiamGiaController : ControllerBase
    {
        private readonly ILKDotGiamGiaRepository _context;

        public LKDotGiamGiaController(ILKDotGiamGiaRepository context)
        {
            _context = context;
        }

        // GET: api/LKDotGiamGia
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LKDotGiamGia>>> GetAll()
        {
            var result = await _context.GetAllAsync();
            return Ok(result);
        }

        // GET: api/LKDotGiamGia/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LKDotGiamGia>> GetById(Guid id)
        {
            var result = await _context.GetByIdAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        // GET: api/LKDotGiamGia/by-giamgia/5
        [HttpGet("by-giamgia/{giamGiaId}")]
        public async Task<ActionResult<IEnumerable<LKDotGiamGia>>> GetByGiamGiaId(Guid giamGiaId)
        {
            var result = await _context.GetByGiamGiaIdAsync(giamGiaId);
            return Ok(result);
        }

        // GET: api/LKDotGiamGia/by-linhkien/5
        [HttpGet("by-linhkien/{linhKienId}")]
        public async Task<ActionResult<IEnumerable<LKDotGiamGia>>> GetByLinhKienId(Guid linhKienId)
        {
            var result = await _context.GetByLinhKienIdAsync(linhKienId);
            return Ok(result);
        }

        // PUT: api/LKDotGiamGia/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, LKDotGiamGia entity)
        {
            if (id != entity.LKDotGiamGiaId)
                return BadRequest("ID không khớp");

            await _context.UpdateLkdotgiamgia(entity);
            return NoContent();
        }

        // POST: api/LKDotGiamGia
        [HttpPost]
        public async Task<IActionResult> Create(LKDotGiamGia entity)
        {
            await _context.CreateLkdotgiamgia(entity);
            return Ok();
        }

        // DELETE: api/LKDotGiamGia/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _context.DeleteLkdotgiamgia(id);
            return Ok();
        }
        //2.7
    }
}
