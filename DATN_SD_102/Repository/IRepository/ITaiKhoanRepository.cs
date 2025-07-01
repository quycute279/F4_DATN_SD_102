using F4_API.Models;

namespace F4_API.Repository.IRepository
{
    public interface ITaiKhoanRepository
    {
        Task<List<TaiKhoan>> GetAllTaiKhoanAsync();
        Task<TaiKhoan> GetByIdTaiKhoanAsync(Guid id);
        Task CreateTaiKhoanAsync(TaiKhoan tk);
        Task UpdateTaiKhoanAsync(TaiKhoan tk);
        Task DeleteTaiKhoanAsync(Guid id);
        Task<TaiKhoan> GetByIdChucVuAsync(string username, string password);
        Task<KhachHang?> GetKhachHangByTaiKhoanIdAsync(Guid taiKhoanId);

        Task<TaiKhoan> GetByUsernameAsync(string username);
    }
}
