using F4_API.Models;

namespace F4_API.Repository.IRepository
{
    public interface ILinhKienCtRepository
    {
        Task<IEnumerable<LinhKienCT>> GetAllAsync();
        Task<LinhKienCT?> GetByIdAsync(Guid id);
        Task AddAsync(LinhKienCT entity);
        Task UpdateAsync(LinhKienCT entity);
        Task DeleteAsync(Guid id);
        Task<IEnumerable<LinhKienCT>> GetByLinhKienIdAsync(Guid lkId);
    }
}
