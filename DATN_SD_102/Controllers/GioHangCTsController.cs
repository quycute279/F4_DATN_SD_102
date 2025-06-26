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
    public class GioHangCTsController : ControllerBase
    {
        private readonly IGioHangCtRepository _repository;

        public GioHangCTsController(IGioHangCtRepository repository)
        {
            _repository = repository;
        }

        // GET: api/GioHangCTs
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _repository.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var item = await _repository.GetByIdAsync(id);
            if (item == null) return NotFound();
            return Ok(item);
        }
        [HttpPost("AddToCart")]
        public async Task<IActionResult> AddToCart([FromBody] GioHangCT model)
        {
            if (model.SoLuong <= 0)
                return BadRequest("Số lượng sản phẩm phải lớn hơn 0");

            var existingItem = await _repository.GetByGioHangVaLinhKienAsync(model.GioHangCTId, model.LkId);
            if (existingItem != null)
            {
                existingItem.SoLuong += model.SoLuong;
                existingItem.NgayTao = DateTime.Now;
                existingItem.TrangThai = true;
                await _repository.UpdateAsync(existingItem);
                return Ok(existingItem);
            }
            else
            {
                model.GioHangCTId = Guid.NewGuid();
                model.NgayTao = DateTime.Now;
                model.TrangThai = true;
                await _repository.AddAsync(model);
                return CreatedAtAction(nameof(GetById), new { id = model.GioHangCTId }, model);
            }
        }

        // PUT: api/GioHangCTs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] GioHangCT model)
        {
            if (id != model.GioHangCTId) return BadRequest();
            await _repository.UpdateAsync(model);
            return NoContent();
        }

        // POST: api/GioHangCTs


        // DELETE: api/GioHangCTs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _repository.DeleteAsync(id);
            return NoContent();
        }
    }
}
