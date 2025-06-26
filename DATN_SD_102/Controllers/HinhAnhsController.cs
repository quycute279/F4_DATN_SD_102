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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace F4_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HinhAnhsController : ControllerBase
    {
        private readonly IHinhAnhRepository _context;

        public HinhAnhsController(IHinhAnhRepository context)
        {
            _context = context;
        }

        // GET: api/HinhAnhs

        [HttpGet]
        public async Task<ActionResult<IEnumerable<HinhAnh>>> GetAll()
        {
            var result = await _context.GetAllAsync();
            return Ok(result);
        }


        // GET: api/HinhAnhs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HinhAnh>> GetById(Guid id)
        {
            var result = await _context.GetByIdAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

      
     
    }
}
