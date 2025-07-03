using F4_API.Models;

namespace F4_API.Repository.IRepository
{
    public interface IDanhMucRepository
    {
        Task<List<DanhMuc>> GetAllAsync();
        Task<DanhMuc?> GetByIdAsync(Guid id);
        Task CreateAsync(DanhMuc danhMuc);
        Task UpdateAsync(DanhMuc danhMuc);
        Task DeleteAsync(Guid id);
        //
        Task<List<DanhMuc_LinhKien_ThuocTinh>> GetThuocTinhsByDanhMucAsync(Guid danhMucId);
        //
    }
}
