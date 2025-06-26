using F4_API.Models;

namespace F4_API.Repository.IRepository
{
    public interface IDiaChiKhachHangRepository
    {
        Task<IEnumerable<DiaChiKhachHang>> GetAll();
        Task<DiaChiKhachHang> GetById(Guid id);
        Task Add(DiaChiKhachHang diaChiKhachHang);
        Task Update(DiaChiKhachHang diaChiKhachHang);
        Task DeleteById(Guid id);
    }
}
