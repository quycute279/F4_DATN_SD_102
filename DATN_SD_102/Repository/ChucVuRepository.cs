using F4_API.DATA;
using F4_API.Models;
using F4_API.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace F4_API.Repository
{
    public class ChucVuRepository : IChucVuRepository
    {
        private readonly AppDbContext _db;

        public ChucVuRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<ChucVu>> GetAllChucVuAsync()
        {
            return await _db.ChucVus.ToArrayAsync();
        }

        public async Task<ChucVu> GetByIdChucVuAsync(Guid id)
        {
            return await _db.ChucVus.FindAsync(id);
        }

        public async Task CreateChucVuAsync(ChucVu chucVu)
        {
            try
            {
                _db.ChucVus.Add(chucVu);
                await _db.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task UpdateChucVuAsync(ChucVu chucVu)
        {
            try
            {
                _db.ChucVus.Update(chucVu);
                await _db.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task DeleteChucVuAsync(Guid id)
        {
            try
            {
                var chucVu = await _db.ChucVus.FindAsync(id);
                if (chucVu != null)
                {
                    _db.ChucVus.Remove(chucVu);
                    await _db.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
