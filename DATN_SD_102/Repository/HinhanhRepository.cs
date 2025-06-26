using F4_API.DATA;
using F4_API.Models;
using F4_API.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace F4_API.Repository
{
    public class HinhanhRepository : IHinhAnhRepository
    {
        private readonly AppDbContext _context;
        private readonly string _uploadsFolder;
        private readonly IWebHostEnvironment _env;

        public HinhanhRepository(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
            _uploadsFolder = Path.Combine(_env.ContentRootPath, "Uploads", "Images");
        }
        public async Task<bool> DeleteAsync(Guid id)
        {
            var anh = await _context.HinhAnhs.FindAsync(id);
            if (anh == null) return false;

            // Xóa file vật lý
            var fullPath = Path.Combine(_env.ContentRootPath, anh.DuongDan);
            if (File.Exists(fullPath))
                File.Delete(fullPath);

            _context.HinhAnhs.Remove(anh);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<HinhAnh>> GetAllAsync()
        {
            return await _context.HinhAnhs.ToListAsync();
        }

        public async Task<HinhAnh> GetByIdAsync(Guid id)
        {
            return await _context.HinhAnhs.FindAsync(id);
        }

        public async Task<HinhAnh> UpdateAsync(HinhAnh anh)
        {
            var existing = await _context.HinhAnhs.FindAsync(anh.HinhAnhId);
            if (existing == null) return null;

            existing.TenAnh = anh.TenAnh;
            existing.TrangThai = anh.TrangThai;
            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<HinhAnh> UpdateFileAsync(Guid id, IFormFile file, string tenAnh)
        {
            var existing = await _context.HinhAnhs.FindAsync(id);
            if (existing == null || file == null || file.Length == 0) return null;

            // Xóa file cũ
            var oldPath = Path.Combine(_env.ContentRootPath, existing.DuongDan);
            if (File.Exists(oldPath))
                File.Delete(oldPath);

            // Lưu file mới
            Directory.CreateDirectory(_uploadsFolder);
            var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
            var filePath = Path.Combine(_uploadsFolder, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            existing.DuongDan = Path.Combine("Uploads/Images", fileName).Replace("\\", "/");
            existing.TenAnh = tenAnh ?? existing.TenAnh;
            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<HinhAnh> UploadAsync(IFormFile file, string tenAnh)
        {
            if (file == null || file.Length == 0) return null;

            Directory.CreateDirectory(_uploadsFolder);
            var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
            var filePath = Path.Combine(_uploadsFolder, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            var anh = new HinhAnh
            {
                DuongDan = Path.Combine("Uploads/Images", fileName).Replace("\\", "/"),
                TenAnh = tenAnh
            };
            _context.HinhAnhs.Add(anh);
            await _context.SaveChangesAsync();
            return anh;
        }
    }
}
