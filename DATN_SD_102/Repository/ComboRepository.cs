using F4_API.DATA;
using F4_API.Models;
using F4_API.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace F4_API.Repository
{
    public class ComboRepository : IComboRepository
    {
        private readonly AppDbContext _context;
        public ComboRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Combo>> GetAllAsync()
        {
            return await _context.Combos
                .Include(c => c.ChiTiets)
                .ToListAsync();
        }

        public async Task<Combo?> GetByIdAsync(Guid id)
        {
            return await _context.Combos
                .Include(c => c.ChiTiets)
                .FirstOrDefaultAsync(c => c.ComboId == id);
        }

        public async Task<Combo> AddAsync(Combo combo)
        {
            _context.Combos.Add(combo);
            await _context.SaveChangesAsync();
            return combo;
        }

        public async Task<Combo> UpdateAsync(Combo combo)
        {
            _context.Combos.Update(combo);
            await _context.SaveChangesAsync();
            return combo;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var combo = await _context.Combos.FindAsync(id);
            if (combo == null) return false;

            _context.Combos.Remove(combo);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
