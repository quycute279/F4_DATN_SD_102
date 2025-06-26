using F4_API.DATA;
using F4_API.Models;
using F4_API.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace F4_API.Repository
{
    public class LinhKienCtRepository : ILinhKienCtRepository
    {
        private readonly AppDbContext _context;

        public LinhKienCtRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<LinhKienCT>> GetAllAsync()
        {
            return await _context.LinhKienCTs
                .Include(x => x.ThuocTinh)
                .Include(x => x.ThuongHieu)
                .Include(x => x.HinhAnhs)
                .ToListAsync();
        }

        public async Task<LinhKienCT?> GetByIdAsync(Guid id)
        {
            return await _context.LinhKienCTs
                .Include(x => x.ThuocTinh)
                .Include(x => x.ThuongHieu)
                .Include(x => x.HinhAnhs)
                .FirstOrDefaultAsync(x => x.LkctId == id);
        }

        public async Task AddAsync(LinhKienCT entity)
        {
            await _context.LinhKienCTs.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(LinhKienCT entity)
        {
            _context.LinhKienCTs.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                _context.LinhKienCTs.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<LinhKienCT>> GetByLinhKienIdAsync(Guid lkId)
        {
            return await _context.LinhKienCTs
                .Where(x => x.LkId == lkId)
                .Include(x => x.ThuocTinh)
                .Include(x => x.ThuongHieu)
                .Include(x => x.HinhAnhs)
                .ToListAsync();
        }
    }
}
