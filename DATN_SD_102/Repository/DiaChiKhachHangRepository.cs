using F4_API.DATA;
using F4_API.Models;
using F4_API.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace F4_API.Repository
{
    public class DiaChiKhachHangRepository : IDiaChiKhachHangRepository
    {
        private readonly AppDbContext _appDbContext;
        public DiaChiKhachHangRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task Add(DiaChiKhachHang diaChiKhachHang)
        {
            try
            {
                _appDbContext.DiaChiKhachHangs.Add(diaChiKhachHang);
                await _appDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task DeleteById(Guid id)
        {
            try
            {
                var deleId = await _appDbContext.DiaChiKhachHangs.FindAsync(id);
                if (deleId != null)
                {
                    _appDbContext.DiaChiKhachHangs.Remove(deleId);
                    await _appDbContext.SaveChangesAsync();
                }
            }
            catch(Exception ex) 
            {
                throw;
            }
        }

        public async Task<IEnumerable<DiaChiKhachHang>> GetAll()
        {
            return await _appDbContext.DiaChiKhachHangs.ToListAsync();
        }

        public async Task<DiaChiKhachHang> GetById(Guid id)
        {
            return await _appDbContext.DiaChiKhachHangs.FindAsync(id);
        }

        public async Task Update(DiaChiKhachHang diaChiKhachHang)
        {
            try
            {
                _appDbContext.DiaChiKhachHangs.Update(diaChiKhachHang);
                await _appDbContext.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }
    }
}
