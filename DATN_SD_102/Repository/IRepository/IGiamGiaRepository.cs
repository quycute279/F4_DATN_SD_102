using F4_API.Models;

namespace F4_API.Repository.IRepository
{
    public interface IGiamGiaRepository
    {
        Task<IEnumerable<GiamGia>> GetAllGiamGia(); // Lấy tất cả khuyến mãi
        Task<GiamGia> GetByIdGiamGia(Guid id); // Lấy khuyến mãi theo ID
        Task<IEnumerable<GiamGia>> GetActiveGiamGia(); // Lấy khuyến mãi đang hoạt động
        Task CreateGiamGia(GiamGia entity); // Thêm mới
        Task UpdateGiamGia(GiamGia entity); // Cập nhật
        Task DeleteGiamGia(Guid id); // Xoá theo ID

        //abdahjbdhad
    }
}
