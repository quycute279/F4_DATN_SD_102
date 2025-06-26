using F4_API.Models;

namespace F4_API.Repository.IRepository
{
    public interface IHoaDonRepository
    {
        Task<List<HoaDon>> GetAll();
        Task<HoaDon> GetById(Guid id);
        Task Create(HoaDon hoaDon);
        Task Update(HoaDon hoaDon);
        Task<bool> Delete(Guid id);
    }
}
