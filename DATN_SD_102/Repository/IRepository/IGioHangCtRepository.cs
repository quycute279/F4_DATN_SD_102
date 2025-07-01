using F4_API.Models;

namespace F4_API.Repository.IRepository
{
    public interface IGioHangCtRepository
    {
        Task<IEnumerable<GioHangCT>> GetAllAsync();
        Task<IEnumerable<GioHangCT>> GetByGioHangIdAsync(Guid gioHangId); // Lấy chi tiết giỏ hàng theo giỏ
        Task<GioHangCT> GetByIdAsync(Guid id);
        Task<GioHangCT> GetByGioHangVaLinhKienAsync(Guid gioHangId, Guid LinhKientId); // Kiểm tra sản phẩm trong giỏ
        Task AddAsync(GioHangCT entity);
        Task UpdateAsync(GioHangCT entity);
        Task DeleteAsync(Guid id);

        Task UpdateSoLuongAsync(Guid gioHangCtId, int soLuong);
    }
}
