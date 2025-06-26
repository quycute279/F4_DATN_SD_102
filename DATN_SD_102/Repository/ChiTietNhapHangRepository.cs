using F4_API.DATA;
using F4_API.Models;
using F4_API.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace F4_API.Repository
{
    public class ChiTietNhapHangRepository : IChiTietNhapHangRepository
    {
        private readonly AppDbContext _context;

        public ChiTietNhapHangRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<ChiTietNhapHang>> GetAllAsync()
        {
            return await _context.ChiTietNhapHangs
                .Include(c => c.LinhKienCT)
                .Include(c => c.NhapHang)
                .ToListAsync();
        }

        public async Task<ChiTietNhapHang?> GetByIdAsync(Guid id)
        {
            return await _context.ChiTietNhapHangs
                .Include(c => c.LinhKienCT)
                .Include(c => c.NhapHang)
                .FirstOrDefaultAsync(c => c.ChiTietNhapHangId == id);
        }

        public async Task<List<ChiTietNhapHang>> GetByNhapHangIdAsync(Guid nhapHangId)
        {
            return await _context.ChiTietNhapHangs
                .Include(c => c.LinhKienCT)
                .Where(c => c.NhapHangId == nhapHangId)
                .ToListAsync();
        }

        public async Task CreateAsync(ChiTietNhapHang ct)
        {
            _context.ChiTietNhapHangs.Add(ct);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ChiTietNhapHang ct)
        {
            _context.ChiTietNhapHangs.Update(ct);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var ct = await _context.ChiTietNhapHangs.FindAsync(id);
            if (ct != null)
            {
                _context.ChiTietNhapHangs.Remove(ct);
                await _context.SaveChangesAsync();
            }
        }
    }
}
