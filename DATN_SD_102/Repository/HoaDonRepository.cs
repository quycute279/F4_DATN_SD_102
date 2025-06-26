using F4_API.DATA;
using F4_API.Models;
using F4_API.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace F4_API.Repository
{
    public class HoaDonRepository : IHoaDonRepository
    {
        private readonly AppDbContext _context;

        public HoaDonRepository(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task Create(HoaDon hoaDon)
        {
            _context.HoaDons.Add(hoaDon);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Delete(Guid id)
        {
            var hoaDon = await _context.HoaDons.FindAsync(id);
            if (hoaDon == null)
                return false;

            _context.HoaDons.Remove(hoaDon);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<HoaDon>> GetAll()
        {
            return await _context.HoaDons
                  .Include(h => h.Voucher)
                  .Include(h => h.TaiKhoan)
                  .Include(h => h.HinhThucThanhToan)
                  .Include(h => h.KhachHang)
                  .Include(h => h.ChiTiets)
                  .ToListAsync();
        }

        public async Task<HoaDon> GetById(Guid id)
        {
            var hoaDon = await _context.HoaDons
              .Include(h => h.Voucher)
                  .Include(h => h.TaiKhoan)
                  .Include(h => h.HinhThucThanhToan)
                  .Include(h => h.KhachHang)
                  .Include(h => h.ChiTiets)
              .FirstOrDefaultAsync(h => h.HoaDonId == id);

            return hoaDon ?? throw new KeyNotFoundException("Hóa đơn không tồn tại với ID đã cho.");
        }

        public async Task Update(HoaDon hoaDon)
        {
            _context.HoaDons.Update(hoaDon);
            await _context.SaveChangesAsync();
        }
    }
}
