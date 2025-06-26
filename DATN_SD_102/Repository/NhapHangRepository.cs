using F4_API.DATA;
using F4_API.Models;
using F4_API.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace F4_API.Repository
{
    public class NhapHangRepository : INhapHangRepository
    {
        private readonly AppDbContext _context;

        public NhapHangRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<NhapHang>> GetAllAsync()
        {
            return await _context.NhapHangs
                .Include(n => n.NhanVien)
                .Include(n => n.ChiTiets)
                .ToListAsync();
        }

        public async Task<NhapHang?> GetByIdAsync(Guid id)
        {
            return await _context.NhapHangs
                .Include(n => n.NhanVien)
                .Include(n => n.ChiTiets)
                .FirstOrDefaultAsync(n => n.NhapHangId == id);
        }

        public async Task CreateAsync(NhapHang nhapHang)
        {
            _context.NhapHangs.Add(nhapHang);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(NhapHang nhapHang)
        {
            _context.NhapHangs.Update(nhapHang);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _context.NhapHangs.FindAsync(id);
            if (entity != null)
            {
                _context.NhapHangs.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
