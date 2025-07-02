using F4_API.Models;

namespace F4_API.Repository.IRepository
{
    public interface ILKDotGiamGiaRepository
    {
        Task<IEnumerable<LKDotGiamGia>> GetAllAsync(); // Lấy tất cả
        Task<LKDotGiamGia> GetByIdAsync(Guid id); // Lấy theo ID
        Task<IEnumerable<LKDotGiamGia>> GetByGiamGiaIdAsync(Guid giamGiaId); // Lấy theo GiamGiaId
        Task<IEnumerable<LKDotGiamGia>> GetByLinhKienIdAsync(Guid linhKienId); // Lấy theo LkId
        Task CreateLkdotgiamgia(LKDotGiamGia entity); // Thêm mới
        Task UpdateLkdotgiamgia(LKDotGiamGia entity); // Cập nhật
        Task DeleteLkdotgiamgia(Guid id); // Xoá
        //abdahjbdhad
    }
}
