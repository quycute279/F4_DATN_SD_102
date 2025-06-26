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
using F4_API.Models.DTO;
using Humanizer;

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

        private LinhKienChiTietsDTO MapToDTO(LinhKienCT entity)
        {
            return new LinhKienChiTietsDTO
            {
                LkctId = entity.LkctId,
                LkId = entity.LkId,
                ThuocTinhId = entity.ThuocTinhId,
                ThuongHieuId = entity.ThuongHieuId,
                HinhAnhId = entity.HinhAnhId,
                GiaTri = entity.GiaTri,
                MoTa = entity.MoTa,
                TrangThai = entity.TrangThai,
            };
        }

        // GET: api/LinhKienCTs
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var items = await _repository.GetAllAsync();
            return Ok(items.Select(MapToDTO));
        }

        // GET: api/LinhKienCTs/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var item = await _repository.GetByIdAsync(id);
            if (item == null) return NotFound();
            return Ok(MapToDTO(item));
        }

        // PUT: api/LinhKienCTs/5
        [HttpGet("linhkien/{lkId}")]
        public async Task<IActionResult> GetByLinhKienId(Guid lkId)
        {
            var items = await _repository.GetByLinhKienIdAsync(lkId);
            return Ok(items.Select(MapToDTO));
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] LinhKienChiTietsDTO dto)
        {
            var entity = new LinhKienCT
            {
                LkId = dto.LkId,
                ThuocTinhId = dto.ThuocTinhId,
                HinhAnhId = dto.HinhAnhId,
                ThuongHieuId = dto.ThuongHieuId,
                GiaTri = dto.GiaTri,
                MoTa = dto.MoTa,
                TrangThai = true,
               
            };

            var created = await _repository.AddAsync(entity);
            return CreatedAtAction(nameof(GetById), new { id = created.LkctId }, MapToDTO(created));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] LinhKienChiTietsDTO dto)
        {
            var giay = new LinhKienCT
            {
                LkctId = id,
                GiaTri = dto.GiaTri,
                TrangThai = dto.TrangThai,
                MoTa = dto.MoTa,
                ThuongHieuId = dto.ThuongHieuId,
                ThuocTinhId = dto.ThuocTinhId,
                HinhAnhId = dto.HinhAnhId,
                LkId = dto.LkId,
                
            };

            var updated = await _repository.UpdateAsync(giay);
            if (updated == null) return NotFound();

            return Ok(MapToDTO(updated));
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

        [HttpPost("multiple")]
        public async Task<IActionResult> AddMultiple([FromBody] List<LinhKienChiTietsDTO> listDto)
        {
            var entities = listDto.Select(dto => new LinhKienCT
            {
                LkId = dto.LkId,
                ThuocTinhId = dto.ThuocTinhId,
                HinhAnhId = dto.HinhAnhId,
                ThuongHieuId = dto.ThuongHieuId,
                GiaTri = dto.GiaTri,
                MoTa = dto.MoTa,
                TrangThai = true,
            }).ToList();

            var result = await _repository.AddMultipleAsync(entities);
            return result ? Ok() : StatusCode(500, "Không thêm được danh sách");
        }
    }
}
