using F4_API.Models;

namespace F4_API.Repository.IRepository
{
    public interface IComboChiTietRepository
    {
        Task<IEnumerable<ComboChiTiet>> GetAllAsync();
        Task<ComboChiTiet?> GetByIdAsync(Guid id);
        Task<ComboChiTiet> AddAsync(ComboChiTiet comboChiTiet);
        Task<ComboChiTiet> UpdateAsync(ComboChiTiet comboChiTiet);
        Task<bool> DeleteAsync(Guid id);
    }
}
