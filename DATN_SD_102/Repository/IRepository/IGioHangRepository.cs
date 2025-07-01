using F4_API.Models;

namespace F4_API.Repository.IRepository
{
    public interface IGioHangRepository
    {
        Task<IEnumerable<GioHang>> GetAllGioHang();
        Task<GioHang> GetByIdGioHang(Guid id);
        Task<GioHang?> GetGioHangByKhachHangId(Guid khachHangId);
        Task CreateGioHang(GioHang gh);
        Task UpdateGioHang(GioHang gh);
        Task DeleteGioHang(Guid id);
    }
}
