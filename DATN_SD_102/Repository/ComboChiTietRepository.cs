using F4_API.DATA;
using F4_API.Models;
using F4_API.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace F4_API.Repository
{
    public class ComboChiTietRepository : IComboChiTietRepository
    {
        private readonly AppDbContext _context;

        public ComboChiTietRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ComboChiTiet>> GetAllAsync()
        {
            return await _context.ComboChiTiets
                .Include(c => c.Combo)
                .Include(c => c.LinhKienCT)
                .ToListAsync();
        }

        public async Task<ComboChiTiet?> GetByIdAsync(Guid id)
        {
            return await _context.ComboChiTiets
                .Include(c => c.Combo)
                .Include(c => c.LinhKienCT)
                .FirstOrDefaultAsync(c => c.ComboChiTietId == id);
        }

        public async Task<ComboChiTiet> AddAsync(ComboChiTiet comboChiTiet)
        {
            _context.ComboChiTiets.Add(comboChiTiet);
            await _context.SaveChangesAsync();
            return comboChiTiet;
        }

        public async Task<ComboChiTiet> UpdateAsync(ComboChiTiet comboChiTiet)
        {
            _context.ComboChiTiets.Update(comboChiTiet);
            await _context.SaveChangesAsync();
            return comboChiTiet;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var item = await _context.ComboChiTiets.FindAsync(id);
            if (item == null) return false;

            _context.ComboChiTiets.Remove(item);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
