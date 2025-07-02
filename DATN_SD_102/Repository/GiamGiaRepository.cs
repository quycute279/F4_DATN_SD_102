using F4_API.DATA;
using F4_API.Models;
using F4_API.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace F4_API.Repository
{
    public class GiamGiaRepository : IGiamGiaRepository
    {
        private readonly AppDbContext _db;
        public GiamGiaRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task CreateGiamGia(GiamGia giamgias)
        {
            try
            {
                _db.Add<GiamGia>(giamgias);
                await _db.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task DeleteGiamGia(Guid id)
        {
            try
            {
                var delGiamGia = await _db.GiamGias.FindAsync(id);
                if (delGiamGia != null)
                {
                    _db.Remove<GiamGia>(delGiamGia);
                    await _db.SaveChangesAsync();
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<GiamGia>> GetActiveGiamGia()
        {
            var now = DateTime.Now;
            return await _db.GiamGias.Where(g => g.TrangThai == true && g.NgayBatDau <= now && now <= g.NgayKetThuc).ToListAsync();
            //return await _dbcontext.GiamGias
            //    .Where(g => g.TrangThai == true && g.NgayBatDau <= now && g.NgayKetThuc >= now)
            //    .ToListAsync();
        }

        public async Task<IEnumerable<GiamGia>> GetAllGiamGia()
        {
            return await _db.GiamGias.ToListAsync();
        }

        public async Task<GiamGia> GetByIdGiamGia(Guid id)
        {
            return await _db.GiamGias.FindAsync(id);
        }

        public async Task UpdateGiamGia(GiamGia giamGias)
        {
            try
            {
                _db.Update<GiamGia>(giamGias);
                await _db.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
        //abdahjbdhad
    }
}
