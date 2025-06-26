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
    public class ChiTietNhapHangsController : ControllerBase
    {
        private readonly IChiTietNhapHangRepository _repository;

        public ChiTietNhapHangsController(IChiTietNhapHangRepository repository)
        {
            _repository = repository;
        }

        // GET: api/ChiTietNhapHangs
        [HttpGet("{id}")]
        public async Task<ActionResult<ChiTietNhapHang>> GetById(Guid id)
        {
            var ct = await _repository.GetByIdAsync(id);
            if (ct == null) return NotFound();
            return Ok(ct);
        }

        [HttpGet("by-nhaphang/{nhapHangId}")]
        public async Task<ActionResult<IEnumerable<ChiTietNhapHang>>> GetByNhapHangId(Guid nhapHangId)
        {
            var list = await _repository.GetByNhapHangIdAsync(nhapHangId);
            return Ok(list);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] ChiTietNhapHang ct)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            await _repository.CreateAsync(ct);
            return Ok(ct);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(Guid id, [FromBody] ChiTietNhapHang ct)
        {
            if (id != ct.ChiTietNhapHangId) return BadRequest("ID mismatch");
            await _repository.UpdateAsync(ct);
            return Ok();
        }

        // DELETE: api/ChiTietNhapHangs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var ct = await _repository.GetByIdAsync(id);
            if (ct == null) return NotFound();
            await _repository.DeleteAsync(id);
            return NoContent();
        }
    }
}
