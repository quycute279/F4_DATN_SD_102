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
    public class NhapHangsController : ControllerBase
    {
        private readonly INhapHangRepository _repository;

        public NhapHangsController(INhapHangRepository repository)
        {
            _repository = repository;
        }

        // GET: api/NhapHangs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NhapHang>>> GetNhapHangs()
        {
            return Ok(await _repository.GetAllAsync());
        }

        // GET: api/NhapHangs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NhapHang>> GetNhapHang(Guid id)
        {
            return Ok(await _repository.GetByIdAsync(id));
        }

        // PUT: api/NhapHangs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] NhapHang nhapHang)
        {
            if (id != nhapHang.NhapHangId)
                return BadRequest("ID không trùng khớp");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _repository.UpdateAsync(nhapHang);
            return NoContent();
        }

        // POST: api/NhapHangs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] NhapHang nhapHang)
        {
           await _repository.CreateAsync(nhapHang);
            return Ok();
        }

        // DELETE: api/NhapHangs/5
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
