using F4_API.Models;

namespace F4_API.Repository.IRepository
{
    public interface IVoucherRepository
    {
        Task<List<Voucher>> GetAll();
        Task<Voucher> GetById(Guid id);
        Task Create(Voucher voucher);
        Task Update(Voucher voucher);
        Task<bool> Delete(Guid id);
    }
}
