using F4_API.Models;

namespace F4_API.Repository.IRepository
{
    public interface IChucVuRepository
    {
        Task<IEnumerable<ChucVu>> GetAllChucVuAsync();
        Task<ChucVu> GetByIdChucVuAsync(Guid id);
        Task CreateChucVuAsync(ChucVu chucVu);
        Task UpdateChucVuAsync(ChucVu chucVu);
        Task DeleteChucVuAsync(Guid id);
    }
}
