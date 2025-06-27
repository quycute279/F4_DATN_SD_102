using F4_API.DATA;
using F4_API.Models;
using F4_API.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace F4_API.Repository
{
    public class DanhMucLinhKienThuocTinhRepository : IDanhMucLinhKienThuocTinhRepository
    {
        private readonly AppDbContext _context;

        public DanhMucLinhKienThuocTinhRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DanhMuc_LinhKien_ThuocTinh>> GetAllAsync()
        {
            return await _context.DanhMuc_LinhKien_ThuocTinhs.ToListAsync();
        }

        public async Task<DanhMuc_LinhKien_ThuocTinh?> GetByIdAsync(Guid id)
        {
            return await _context.DanhMuc_LinhKien_ThuocTinhs.FindAsync(id);
        }

        public async Task AddAsync(DanhMuc_LinhKien_ThuocTinh entity)
        {
            await _context.DanhMuc_LinhKien_ThuocTinhs.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(DanhMuc_LinhKien_ThuocTinh entity)
        {
            _context.DanhMuc_LinhKien_ThuocTinhs.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _context.DanhMuc_LinhKien_ThuocTinhs.FindAsync(id);
            if (entity != null)
            {
                _context.DanhMuc_LinhKien_ThuocTinhs.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
