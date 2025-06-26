using F4_API.DATA;
using F4_API.Models;
using Microsoft.EntityFrameworkCore;
using F4_API.Repository.IRepository;

namespace F4_API.Repository
{
    public class KhachHangRepository : IKhachHangRepository
    {
        private readonly AppDbContext _db;
        public KhachHangRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task CreateKhachHangAsync(KhachHang khachhang)
        {
            try
            {
                if (khachhang.TaiKhoanId == Guid.Empty)
                {
                    khachhang.TaiKhoanId = null;
                }
                await _db.KhachHangs.AddAsync(khachhang);
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi tạo khách hàng: {ex.Message}");
            }
        }

        public async Task DeleteKhachHangAsync(Guid id)
        {
            try
            {
                var DeleId = await _db.KhachHangs.FindAsync(id);
                if (DeleId != null)
                {
                    _db.KhachHangs.Remove(DeleId);
                    _db.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<KhachHang>> GetAllKhachHangAsync()
        {
            return await _db.KhachHangs
                  .Include(kh => kh.TaiKhoan)
                  .Include(kh => kh.HoaDons)
                  .Include(kh => kh.DiaChiKhachHangs)
                  .Include(kh => kh.GioHangs)
                  .ToListAsync();
        }

        public async Task<KhachHang> GetByIdKhachHangAsync(Guid id)
        {
            return await _db.KhachHangs.FindAsync(id);
        }

        public async Task UpdatekhachHangAsync(KhachHang khachhang)
        {
            try
            {
                var existing = await _db.KhachHangs.FindAsync(khachhang.KhachHangId);
                if (existing == null)
                    throw new Exception("Không tìm thấy nhân viên cần cập nhật.");

                // Chỉ cập nhật các trường thay đổi
                _db.Entry(existing).CurrentValues.SetValues(khachhang);

                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi cập nhật nhân viên: " + ex.Message);
            }
        }

        public async Task<List<KhachHang>> SearchKhachHangAsync(string keyword)
        {
            keyword = keyword.ToLower();
            return await _db.KhachHangs
                .Where(nv => nv.TenKhachHang.ToLower().Contains(keyword))
                .ToListAsync();
        }
    }
}
