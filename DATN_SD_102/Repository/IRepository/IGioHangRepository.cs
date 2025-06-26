using F4_API.Models;

namespace F4_API.Repository.IRepository
{
    public interface IGioHangRepository
    {
        Task<IEnumerable<GioHang>> GetAllGioHang();
        Task<GioHang> GetByIdGioHang(Guid id);
        Task CreateGioHang(GioHang gh);
        Task UpdateGioHang(GioHang gh);
        Task DeleteGioHang(Guid id);
    }
}
