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
    public class LinhKienCTsController : ControllerBase
    {
        private readonly ILinhKienCtRepository _repository;

        public LinhKienCTsController(ILinhKienCtRepository repository)
        {
            _repository = repository;
        }

        // GET: api/LinhKienCTs
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var list = await _repository.GetAllAsync();
            return Ok(list);
        }

        // GET: api/LinhKienCTs/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
                return NotFound();

            return Ok(entity);
        }

        // PUT: api/LinhKienCTs/5
        [HttpGet("linhkien/{lkId}")]
        public async Task<IActionResult> GetByLinhKienId(Guid lkId)
        {
            var list = await _repository.GetByLinhKienIdAsync(lkId);
            return Ok(list);
        }
        [HttpPost]
        public async Task<IActionResult> Create(LinhKienCT model)
        {
            model.LkctId = Guid.NewGuid();
            await _repository.AddAsync(model);
            return CreatedAtAction(nameof(GetById), new { id = model.LkctId }, model);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, LinhKienCT model)
        {
            if (id != model.LkctId)
            {
                return BadRequest("Id không khớp với dữ liệu nhân viên.");
            }

            try
            {
                await _repository.UpdateAsync(model);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Lỗi khi cập nhật: {ex.Message}");
            }
        }

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
