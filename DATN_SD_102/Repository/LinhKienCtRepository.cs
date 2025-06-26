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

        public async Task<LinhKienCT> AddAsync(LinhKienCT entity)
        {
            entity.LkctId = Guid.NewGuid();
            entity.TrangThai = true;
        

            _context.LinhKienCTs.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<LinhKienCT> UpdateAsync(LinhKienCT entity)
        {
            var existing = await _context.LinhKienCTs.FindAsync(entity.LkctId);
            if (existing == null) return null;

            existing.LkId = entity.LkId;
            existing.ThuocTinhId = entity.ThuocTinhId;
            existing.ThuongHieuId = entity.ThuongHieuId;
            existing.HinhAnhId = entity.HinhAnhId;
            existing.GiaTri = entity.GiaTri;
            existing.MoTa = entity.MoTa;
            existing.TrangThai = entity.TrangThai;

            await _context.SaveChangesAsync();
            return existing;
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
        public async Task<bool> AddMultipleAsync(List<LinhKienCT> chiTietList)
        {
            foreach (var item in chiTietList)
            {
                item.LkId = Guid.NewGuid();
                item.TrangThai = true;
             
                _context.LinhKienCTs.Add(item);
            }

            await _context.SaveChangesAsync();
            return true;
        }

    }
}
