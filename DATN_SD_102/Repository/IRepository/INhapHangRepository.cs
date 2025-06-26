using F4_API.Models;

namespace F4_API.Repository.IRepository
{
    public interface INhapHangRepository
    {
        Task<List<NhapHang>> GetAllAsync();
        Task<NhapHang?> GetByIdAsync(Guid id);
        Task CreateAsync(NhapHang nhapHang);
        Task UpdateAsync(NhapHang nhapHang);
        Task DeleteAsync(Guid id);
    }
}
