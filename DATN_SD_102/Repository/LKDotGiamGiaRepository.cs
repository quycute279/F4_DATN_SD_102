using F4_API.DATA;
using F4_API.Models;
using F4_API.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace F4_API.Repository
{
    public class LKDotGiamGiaRepository : ILKDotGiamGiaRepository
    {
        private readonly AppDbContext _dbcontext;

        public LKDotGiamGiaRepository(AppDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<IEnumerable<LKDotGiamGia>> GetAllAsync()
        {
            return await _dbcontext.LKDotGiamGias.ToListAsync();
        }

        public async Task<LKDotGiamGia> GetByIdAsync(Guid id)
        {
            return await _dbcontext.LKDotGiamGias.FindAsync(id);
        }

        public async Task<IEnumerable<LKDotGiamGia>> GetByGiamGiaIdAsync(Guid giamGiaId)
        {
            return await _dbcontext.LKDotGiamGias
                .Where(x => x.GiamGiaId == giamGiaId)
                .ToListAsync();
        }

        public async Task<IEnumerable<LKDotGiamGia>> GetByLinhKienIdAsync(Guid linhKienId)
        {
            return await _dbcontext.LKDotGiamGias
                .Where(x => x.LkId == linhKienId)
                .ToListAsync();
        }

        public async Task CreateLkdotgiamgia(LKDotGiamGia entity)
        {
            try
            {
                await _dbcontext.LKDotGiamGias.AddAsync(entity);
                await _dbcontext.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task UpdateLkdotgiamgia(LKDotGiamGia entity)
        {
            try
            {
                _dbcontext.LKDotGiamGias.Update(entity);
                await _dbcontext.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task DeleteLkdotgiamgia(Guid id)
        {
            try
            {
                var item = await _dbcontext.LKDotGiamGias.FindAsync(id);
                if (item != null)
                {
                    _dbcontext.LKDotGiamGias.Remove(item);
                    await _dbcontext.SaveChangesAsync();
                }
            }
            catch
            {
                throw;
            }
        }
        //abdahjbdhad
    }
}
