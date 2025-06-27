using F4_API.Models;

namespace F4_API.Repository.IRepository
{
    public interface IComboRepository
    {
        Task<IEnumerable<Combo>> GetAllAsync();
        Task<Combo?> GetByIdAsync(Guid id);
        Task<Combo> AddAsync(Combo combo);
        Task<Combo> UpdateAsync(Combo combo);
        Task<bool> DeleteAsync(Guid id);
    }
}
