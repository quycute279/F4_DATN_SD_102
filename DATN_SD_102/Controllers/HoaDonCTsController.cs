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
    public class HoaDonCTsController : ControllerBase
    {
        private readonly IHoaDonCtRepository _repository;

        public HoaDonCTsController(IHoaDonCtRepository context)
        {
            _repository = context;
        }

        // GET: api/HoaDonCTs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HoaDonCT>>> GetHoaDonCTs()
        {
            var result = await _repository.GetAllHDCTAsync();
            return Ok(result);
        }

        // GET: api/HoaDonCTs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HoaDonCT>> GetHoaDonCT(Guid id)
        {
            var item = await _repository.GetByIdHDCTAsync(id);
            if (item == null) return NotFound();
            return Ok(item);
        }
    }
}
