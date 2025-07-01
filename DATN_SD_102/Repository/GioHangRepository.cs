using F4_API.DATA;
using F4_API.Models;
using F4_API.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace F4_API.Repository
{
    public class GioHangRepository : IGioHangRepository
    {
        private readonly AppDbContext _dbcontext;

        public GioHangRepository(AppDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task CreateGioHang(GioHang gh)
        {
            try
            {
                _dbcontext.Add<GioHang>(gh);
                await _dbcontext.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task DeleteGioHang(Guid id)
        {
            try
            {
                var ghdel = await _dbcontext.GioHangs.FindAsync(id);
                if (ghdel != null)
                {
                    _dbcontext.Remove<GioHang>(ghdel);
                    await _dbcontext.SaveChangesAsync();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<GioHang>> GetAllGioHang()
        {
            return await _dbcontext.GioHangs.ToListAsync();
        }

        public async Task<GioHang> GetByIdGioHang(Guid id)
        {
            return await _dbcontext.GioHangs.FindAsync(id);
        }

        public async Task UpdateGioHang(GioHang gh)
        {
            try
            {
                _dbcontext.Update<GioHang>(gh);
                await _dbcontext.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<GioHang?> GetGioHangByKhachHangId(Guid khachHangId)
        {
            return await _dbcontext.GioHangs
                .Include(g => g.ChiTiets)
                .ThenInclude(ct => ct.LinhKien)
                .FirstOrDefaultAsync(g => g.KhachHangId == khachHangId);
        }
    }
}
