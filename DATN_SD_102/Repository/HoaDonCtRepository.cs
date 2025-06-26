using F4_API.DATA;
using F4_API.Models;
using F4_API.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace F4_API.Repository
{
    public class HoaDonCtRepository : IHoaDonCtRepository
    {
        private readonly AppDbContext _contextApp;

        public HoaDonCtRepository(AppDbContext contextApp)
        {
            _contextApp = contextApp;
        }

        public async Task<IEnumerable<HoaDonCT>> GetAllHDCTAsync()
        {
            return await _contextApp.HoaDonCTs
                 .Include(x => x.LinhKienCT)
                 .Include(x => x.HoaDon)
                 .ToListAsync();
        }

        public async Task<IEnumerable<HoaDonCT>> GetByHoaDonChiTietIdAsync(Guid hdctID)
        {
            return await _contextApp.HoaDonCTs
              .Where(x => x.HoaDonChiTietId == hdctID)
              .Include(x => x.LinhKienCT)
              .Include(x => x.HoaDon)
              .ToListAsync();
        }

        public async Task<HoaDonCT> GetByHoaDonChiTietvaLinhKienCTAsync(Guid hdctID, Guid LkctId)
        {
            return await _contextApp.HoaDonCTs
              .Include(x => x.LinhKienCT)
              .Include(x => x.HoaDon)
              .FirstOrDefaultAsync(x => x.HoaDonId == hdctID && x.LkctId == LkctId);
        }

        public async Task<HoaDonCT> GetByIdHDCTAsync(Guid IdCTHD)
        {
            return await _contextApp.HoaDonCTs
                 .Include(x => x.LinhKienCT)
                 .Include(x => x.HoaDon)
                 .FirstOrDefaultAsync(x => x.HoaDonChiTietId == IdCTHD);
        }
    }
}
