using F4_API.Models;

namespace F4_API.Repository.IRepository
{
    public interface ILinhKienRepository
    {
        Task<IEnumerable<LinhKien>> GetAllAsync();
        Task<LinhKien> GetByIdAsync(Guid id);
        Task AddAsync(LinhKien linhKien);
        Task UpdateAsync(LinhKien linhKien);
        Task DeleteAsync(Guid id);
        Task<IEnumerable<LinhKien>> GetByDanhMucIdAsync(Guid danhMucId);
        Task<IEnumerable<LinhKien>> SearchByNameAsync(string keyword);
    }
}
