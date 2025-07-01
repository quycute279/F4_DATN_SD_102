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

namespace F4_API.Controllers
{
  //huhuhuhu

    [Route("api/[controller]")]
    [ApiController]
    public class LinhKienController : ControllerBase
    {
        private readonly ILinhKienRepository _repository;

        public LinhKienController(ILinhKienRepository repository)
        {
            _repository = repository;
        }
        private LinhKienDTO MapToDTO(LinhKien linhKien)
        {
            return new LinhKienDTO
            {
                LkId = linhKien.LkId,
                TenLinhKien = linhKien.TenLinhKien,
                DanhMucId = linhKien.DanhMucId,
                Gia = linhKien.Gia,
                MoTa = linhKien.MoTa,
                TrangThai = true,


                linhKienCTs = linhKien.ChiTiets?.Select(st => new LinhKienChiTietsDTO
                {
                    LkctId = st.LkctId,
                    LkId = st.LkId,
                    ThuocTinhId = st.ThuocTinhId,
                    GiaTri = st.GiaTri,
                    HinhAnhId = st.HinhAnhId,
                    ThuongHieuId = st.ThuongHieuId,
                    MoTa = st.MoTa,
                    TrangThai = st.TrangThai
                }).ToList() ?? new List<LinhKienChiTietsDTO>()
            };
        }

        // GET: api/LinhKiens
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var giays = await _repository.GetAllAsync();
                var dtoList = giays.Select(MapToDTO).ToList();
                return Ok(dtoList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Lỗi khi lấy giày: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var giay = await _repository.GetByIdAsync(id);
            if (giay == null) return NotFound();

            return Ok(MapToDTO(giay));
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] LinhKienDTO dto)
        {
            var linhKienId = Guid.NewGuid();

            var linhKien = new LinhKien
            {
                LkId = linhKienId,
                TenLinhKien = dto.TenLinhKien,
                DanhMucId = dto.DanhMucId,
                Gia = dto.Gia,
                MoTa = dto.MoTa,
                TrangThai = true,

            
                ChiTiets = dto.linhKienCTs?.Select(x => new LinhKienCT
                {
                    LkctId = Guid.NewGuid(),
                    LkId = linhKienId,
                    ThuocTinhId = x.ThuocTinhId,
                    GiaTri = x.GiaTri,
                    HinhAnhId = x.HinhAnhId,
                    ThuongHieuId = x.ThuongHieuId,
                    MoTa = x.MoTa,
                    TrangThai = x.TrangThai ?? true
                }).ToList()
            };

       
            var created = await _repository.AddAsync(linhKien);
            return CreatedAtAction(nameof(GetById), new { id = created.LkId }, MapToDTO(created));
        }




        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] LinhKienDTO dto)
        {
            var linhKien = new LinhKien
            {
                LkId = id,
                TenLinhKien = dto.TenLinhKien,
                DanhMucId = dto.DanhMucId,
                Gia = dto.Gia,
                MoTa = dto.MoTa,
                TrangThai = true,
            };

            var created = await _repository.UpdateAsync(linhKien);
            return CreatedAtAction(nameof(GetById), new { id = created.LkId }, MapToDTO(created));
        }


        // DELETE: api/LinhKiens/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLinhKien(Guid id)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null)
                return NotFound();

            await _repository.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<LinhKien>>> Search(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return Ok(await _repository.GetAllAsync());

            var result = await _repository.SearchByNameAsync(keyword);
            return Ok(result);
        }
    }
}
