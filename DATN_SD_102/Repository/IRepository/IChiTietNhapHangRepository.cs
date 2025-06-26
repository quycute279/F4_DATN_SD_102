using F4_API.Models;

namespace F4_API.Repository.IRepository
{
    public interface IChiTietNhapHangRepository
    {
        Task<List<ChiTietNhapHang>> GetAllAsync();
        Task<ChiTietNhapHang?> GetByIdAsync(Guid id);
        Task<List<ChiTietNhapHang>> GetByNhapHangIdAsync(Guid nhapHangId);
        Task CreateAsync(ChiTietNhapHang ct);
        Task UpdateAsync(ChiTietNhapHang ct);
        Task DeleteAsync(Guid id);
    }
}
