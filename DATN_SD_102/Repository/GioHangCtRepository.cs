using F4_API.DATA;
using F4_API.Models;
using F4_API.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace F4_API.Repository
{
    public class GioHangCtRepository : IGioHangCtRepository
    {
        private readonly AppDbContext _context;

        public GioHangCtRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<GioHangCT>> GetAllAsync()
        {
            return await _context.GioHangCTs
                .Include(x => x.GioHang)
                .Include(x => x.LinhKien)
                .ToListAsync();
        }

        public async Task<IEnumerable<GioHangCT>> GetByGioHangIdAsync(Guid gioHangId)
        {
            return await _context.GioHangCTs
                .Where(x => x.GioHangId == gioHangId)
                .Include(x => x.GioHang)
                .Include(x => x.LinhKien)
                .ToListAsync();
        }

        public async Task<GioHangCT> GetByIdAsync(Guid id)
        {
            return await _context.GioHangCTs
                .Include(x => x.GioHang)
                .Include(x => x.LinhKien)
                .FirstOrDefaultAsync(x => x.GioHangCTId == id);
        }

        public async Task<GioHangCT> GetByGioHangVaLinhKienAsync(Guid gioHangId, Guid linhkienId)
        {
            return await _context.GioHangCTs
                .FirstOrDefaultAsync(x => x.GioHangId == gioHangId && x.LkId == linhkienId);
        }

        public async Task AddAsync(GioHangCT entity)
        {
            await _context.GioHangCTs.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(GioHangCT entity)
        {
            _context.GioHangCTs.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _context.GioHangCTs.FindAsync(id);
            if (entity != null)
            {
                _context.GioHangCTs.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateSoLuongAsync(Guid gioHangCtId, int soLuong)
        {
            var gioHangCt = await _context.GioHangCTs.FindAsync(gioHangCtId);
            if (gioHangCt == null)
            {
                throw new Exception("Không tìm thấy chi tiết giỏ hàng cần cập nhật.");
            }

            gioHangCt.SoLuong = soLuong;
            gioHangCt.NgayTao = DateTime.Now; // cập nhật lại ngày sửa nếu cần
            _context.GioHangCTs.Update(gioHangCt);
            await _context.SaveChangesAsync();
        }

    }
}
