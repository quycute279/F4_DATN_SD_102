using F4_API.Models;

namespace F4_API.Repository.IRepository
{
    public interface INhanVienRepository
    {
        Task<List<NhanVien>> GetAllNhanVienAsync();
        Task<NhanVien> GetByIdNhanVienAsync(Guid id);
        Task CreateNhanVien(NhanVien nhanVien);
        Task DeleteNhanVienAsync(Guid id);
        Task UpdateNhanVienAsync(NhanVien nhanVien);

        Task<NhanVien> GetIdNhanVienTaiKhoan(Guid TK);
    }
}
