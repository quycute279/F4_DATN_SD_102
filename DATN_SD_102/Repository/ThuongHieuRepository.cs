using F4_API.DATA;
using F4_API.Models;
using F4_API.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace F4_API.Repository
{
    public class ThuongHieuRepository : IThuongHieuRepository
    {
        private readonly AppDbContext _context;
        public ThuongHieuRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(ThuongHieu entity)
        {
            try
            {
                _context.ThuongHieus.Add(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            try
            {
                var deleId = await _context.ThuongHieus.FindAsync(id);
                if (deleId != null)
                {
                    _context.ThuongHieus.Remove(deleId);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<IEnumerable<ThuongHieu>> GetAllAsync()
        {
            return await _context.ThuongHieus.ToListAsync();
        }

        public async Task<ThuongHieu?> GetByIdAsync(Guid id)
        {
            return await _context.ThuongHieus.FindAsync(id);
        }

        public async Task UpdateAsync(ThuongHieu entity)
        {
            try
            {
                _context.ThuongHieus.Update(entity);
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }
    }
}
