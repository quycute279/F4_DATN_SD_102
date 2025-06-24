using System.ComponentModel.DataAnnotations;

namespace F4_API.Models
{
    public class TaiKhoan
    {
        [Key]
        public Guid TaiKhoanId { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public DateTime NgayTaoTaiKhoan { get; set; }

        public ICollection<NhanVien>? NhanViens { get; set; }
        public ICollection<KhachHang>? KhachHangs { get; set; }
        public ICollection<Voucher>? Vouchers { get; set; }
        public ICollection<HoaDon>? HoaDons { get; set; }
    }
}
