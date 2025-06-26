using F4_API.DATA;
using F4_API.Models;
using F4_API.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace F4_API.Repository
{
    public class HinhThucTTRepository : IHinhThucTTRepository
    {
        private readonly AppDbContext _context;

        public HinhThucTTRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<HinhThucThanhToan>> GetAllAsync()
        {
            return await _context.HinhThucThanhToans
                                 .Include(x => x.HoaDons)
                                 .ToListAsync();
        }

        public async Task<HinhThucThanhToan?> GetByIdAsync(Guid id)
        {
            return await _context.HinhThucThanhToans
                                 .Include(x => x.HoaDons)
                                 .FirstOrDefaultAsync(x => x.HinhThucThanhToanId == id);
        }

        public async Task AddAsync(HinhThucThanhToan entity)
        {
            await _context.HinhThucThanhToans.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(HinhThucThanhToan entity)
        {
            _context.HinhThucThanhToans.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                _context.HinhThucThanhToans.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

    }
}
