using F4_API.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace F4_API.Repository.IRepository
{
    public interface IHinhAnhRepository
    {
        // Lấy danh sách ảnh
        Task<IEnumerable<HinhAnh>> GetAllAsync();

        // Lấy 1 ảnh theo id
        Task<HinhAnh> GetByIdAsync(Guid id);

        // Thêm ảnh (tải lên)
        Task<HinhAnh> UploadAsync(IFormFile file, string tenAnh);

        // Sửa thông tin ảnh (không đổi file)
        Task<HinhAnh> UpdateAsync(HinhAnh anh);

        // Sửa file ảnh (có đổi file)
        Task<HinhAnh> UpdateFileAsync(Guid id, IFormFile file, string tenAnh);

        // Xóa ảnh (và file vật lý)
        Task<bool> DeleteAsync(Guid id);
    }
}
