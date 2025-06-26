using F4_API.Models;

namespace F4_API.Repository.IRepository
{
    public interface IThuongHieuRepository
    {
        Task<IEnumerable<ThuongHieu>> GetAllAsync();
        Task<ThuongHieu?> GetByIdAsync(Guid id);
        Task AddAsync(ThuongHieu entity);
        Task UpdateAsync(ThuongHieu entity);
        Task DeleteAsync(Guid id);
    }
}
