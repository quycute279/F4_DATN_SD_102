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
    public class DanhMucsController : ControllerBase
    {
        private readonly IDanhMucRepository _repository;

        public DanhMucsController(IDanhMucRepository repository)
        {
            _repository = repository;
        }
        // GET: api/DanhMucs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DanhMuc>>> GetDanhMucs()
        {
            var result = await _repository.GetAllAsync();
            return Ok(result);
        }

        // GET: api/DanhMucs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DanhMuc>> GetByIdDanhMuc(Guid id)
        {
            var danhMuc = await _repository.GetByIdAsync(id);

            if (danhMuc == null)
                return NotFound();

            return Ok(danhMuc);
        }

        // PUT: api/DanhMucs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDanhMuc(Guid id, DanhMuc danhMuc)
        {
            if (id != danhMuc.DanhMucId)
                return BadRequest("ID không trùng khớp");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _repository.UpdateAsync(danhMuc);
            return NoContent();
        }

        // POST: api/DanhMucs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DanhMuc>> PostDanhMuc(DanhMuc danhMuc)
        {
            await _repository.CreateAsync(danhMuc);
            return Ok();        }

        // DELETE: api/DanhMucs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDanhMuc(Guid id)
        {
           await _repository.DeleteAsync(id);
            return Ok();
        }

       
    }
}
