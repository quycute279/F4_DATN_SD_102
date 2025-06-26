using F4_API.DATA;
using F4_API.Models;
using F4_API.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace F4_API.Repository
{
    public class LinhKienRepository : ILinhKienRepository
    {
        private readonly AppDbContext _context;

        public LinhKienRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<LinhKien>> GetAllAsync()
        {
            return await _context.LinhKiens
                .Include(x => x.DanhMuc)
                .Include(x => x.ChiTiets)
                .Include(x => x.GioHangCTs)
                .Include(x => x.DotGiamGias)
                .ToListAsync();
        }

        public async Task<LinhKien?> GetByIdAsync(Guid id)
        {
            return await _context.LinhKiens
                .Include(x => x.DanhMuc)
                .Include(x => x.ChiTiets)
                .Include(x => x.GioHangCTs)
                .Include(x => x.DotGiamGias)
                .FirstOrDefaultAsync(x => x.LkId == id);
        }

        public async Task AddAsync(LinhKien linhKien)
        {
            await _context.LinhKiens.AddAsync(linhKien);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(LinhKien linhKien)
        {
            _context.LinhKiens.Update(linhKien);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                _context.LinhKiens.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<LinhKien>> GetByDanhMucIdAsync(Guid danhMucId)
        {
            return await _context.LinhKiens
                .Where(x => x.DanhMucId == danhMucId)
                .ToListAsync();
        }

        public async Task<IEnumerable<LinhKien>> SearchByNameAsync(string keyword)
        {
            keyword = keyword.ToLower();
            return await _context.LinhKiens
                .Where(nv => nv.TenLinhKien.ToLower().Contains(keyword))
                .ToListAsync();
        }
    }
}
