using F4_API.DATA;
using F4_API.Models;
using F4_API.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace F4_API.Repository
{
    public class DanhMucRepository : IDanhMucRepository
    {
         private readonly AppDbContext _context;

    public DanhMucRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<DanhMuc>> GetAllAsync()
    {
        return await _context.DanhMucs
            .Include(d => d.LinhKiens)
            .Include(d => d.ThuocTinhs)
            .ToListAsync();
    }

    public async Task<DanhMuc?> GetByIdAsync(Guid id)
    {
        return await _context.DanhMucs
            .Include(d => d.LinhKiens)
            .Include(d => d.ThuocTinhs)
            .FirstOrDefaultAsync(d => d.DanhMucId == id);
    }

    public async Task CreateAsync(DanhMuc danhMuc)
    {
        _context.DanhMucs.Add(danhMuc);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(DanhMuc danhMuc)
    {
        _context.DanhMucs.Update(danhMuc);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var danhMuc = await _context.DanhMucs.FindAsync(id);
        if (danhMuc != null)
        {
            _context.DanhMucs.Remove(danhMuc);
            await _context.SaveChangesAsync();
        }
    }
}
}
