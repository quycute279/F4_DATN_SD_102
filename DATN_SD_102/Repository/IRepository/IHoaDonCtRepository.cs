using F4_API.Models;

namespace F4_API.Repository.IRepository
{
    public interface IHoaDonCtRepository
    {
        Task<IEnumerable<HoaDonCT>> GetAllHDCTAsync();
        Task<IEnumerable<HoaDonCT>> GetByHoaDonChiTietIdAsync(Guid hdctID);
        Task<HoaDonCT> GetByIdHDCTAsync(Guid IdCTHD);
        Task<HoaDonCT> GetByHoaDonChiTietvaLinhKienCTAsync(Guid hdctID, Guid LkctId);
    }
}
