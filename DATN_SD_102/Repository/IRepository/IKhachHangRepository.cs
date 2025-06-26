using F4_API.Models;

namespace F4_API.Repository.IRepository
{
    public interface IKhachHangRepository
    {
        Task<List<KhachHang>> GetAllKhachHangAsync();
        Task<KhachHang> GetByIdKhachHangAsync(Guid id);
        Task CreateKhachHangAsync (KhachHang hang);
        Task DeleteKhachHangAsync (Guid id);
        Task UpdatekhachHangAsync(KhachHang hang);
        Task<List<KhachHang>> SearchKhachHangAsync(string keyword);
    }
}
