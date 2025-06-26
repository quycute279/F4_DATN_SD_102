using F4_API.Models;

namespace F4_API.Repository.IRepository
{
    public interface IHinhThucTTRepository
    {
        Task<IEnumerable<HinhThucThanhToan>> GetAllAsync();
        Task<HinhThucThanhToan?> GetByIdAsync(Guid id);
        Task AddAsync(HinhThucThanhToan hinhThuc);
        Task UpdateAsync(HinhThucThanhToan hinhThuc);
        Task DeleteAsync(Guid id);
   
    }
}
