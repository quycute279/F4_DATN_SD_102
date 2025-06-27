using F4_API.Models;

namespace F4_API.Repository.IRepository
{
    public interface IDanhMucLinhKienThuocTinhRepository
    {
        Task<IEnumerable<DanhMuc_LinhKien_ThuocTinh>> GetAllAsync();
        Task<DanhMuc_LinhKien_ThuocTinh?> GetByIdAsync(Guid id);
        Task AddAsync(DanhMuc_LinhKien_ThuocTinh entity);
        Task UpdateAsync(DanhMuc_LinhKien_ThuocTinh entity);
        Task DeleteAsync(Guid id);
    }
}
