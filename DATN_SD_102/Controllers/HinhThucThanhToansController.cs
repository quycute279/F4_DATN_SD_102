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
    public class HinhThucThanhToansController : ControllerBase
    {
        private readonly IHinhThucTTRepository _repository;

        public HinhThucThanhToansController(IHinhThucTTRepository repository)
        {
            _repository = repository;
        }

        // GET: api/HinhThucThanhToans
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var list = await _repository.GetAllAsync();
            return Ok(list);
        }

        // GET: api/HinhThucThanhToans/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _repository.GetByIdAsync(id);
            if (result == null)
                return NotFound();

            return Ok(result);
        }

        // PUT: api/HinhThucThanhToans/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, HinhThucThanhToan hinhThuc)
        {
            if (id != hinhThuc.HinhThucThanhToanId)
                return BadRequest("ID không khớp");

            var existing = await _repository.GetByIdAsync(id);
            if (existing == null)
                return NotFound();

            existing.TenHinhThuc = hinhThuc.TenHinhThuc;
            existing.MoTa = hinhThuc.MoTa;

            await _repository.UpdateAsync(existing);
            return NoContent();
        }

        // POST: api/HinhThucThanhToans
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> Create(HinhThucThanhToan hinhThuc)
        {
            hinhThuc.HinhThucThanhToanId = Guid.NewGuid();
            await _repository.AddAsync(hinhThuc);
            return CreatedAtAction(nameof(GetById), new { id = hinhThuc.HinhThucThanhToanId }, hinhThuc);
        }

        // DELETE: api/HinhThucThanhToans/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null)
                return NotFound();

            await _repository.DeleteAsync(id);
            return NoContent();
        }
    }
}
