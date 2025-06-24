using System.ComponentModel.DataAnnotations;

namespace F4_API.Models
{
    public class Voucher
    {
        [Key]
        public Guid VoucherId { get; set; }
        public string TenVoucher { get; set; } = null!;
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc { get; set; }
        public double PhanTram { get; set; }
        public bool TrangThai { get; set; }
        public int SoLuong { get; set; }
        public Guid? TaiKhoanId { get; set; }

        public TaiKhoan? TaiKhoan { get; set; }
        public ICollection<HoaDon>? HoaDons { get; set; }
    }
}
