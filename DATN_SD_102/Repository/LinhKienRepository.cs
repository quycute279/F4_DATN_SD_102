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
        public async Task<LinhKien> AddAsync(LinhKien linhKien)
        {
            linhKien.LkId = Guid.NewGuid();
            linhKien.TrangThai = true;
            _context.LinhKiens.Add(linhKien);
            await _context.SaveChangesAsync();
            return linhKien;
        }

        public async Task<LinhKien> UpdateAsync(LinhKien linhKien)
        {
            var existing = await _context.LinhKiens.FindAsync(linhKien.LkId);
            if (existing == null) return null;

            existing.TenLinhKien = linhKien.TenLinhKien;
            existing.TrangThai = linhKien.TrangThai;
            existing.DanhMucId = linhKien.DanhMucId;
            existing.Gia = linhKien.Gia;
            existing.MoTa = linhKien.MoTa;

            await _context.SaveChangesAsync();
            return existing;
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
