using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace F4_API.Models
{
    public class HoaDon
    {
        [Key]
        public Guid HoaDonId { get; set; }
        public Guid? TaiKhoanId { get; set; }
        public Guid? VoucherId { get; set; }
        public Guid? KhachHangId { get; set; }
        public Guid? HinhThucThanhToanId { get; set; }
        public string TenKhachHang { get; set; } = null!;
        public string SoDienThoaiKh { get; set; } = null!;
        public string EmailKh { get; set; } = null!;
        public DateTime NgayTao { get; set; }
        public DateTime NgayNhanHang { get; set; }
        public decimal? TienShip {  get; set; }
        public double TongTienSauKhiGiam { get; set; }
        public string TrangThai { get; set; }
        public string? GhiChu { get; set; }

        public TaiKhoan? TaiKhoan { get; set; }
        public Voucher? Voucher { get; set; }
        public KhachHang? KhachHang { get; set; }
        public HinhThucThanhToan? HinhThucThanhToan { get; set; }
        public ICollection<HoaDonCT>? ChiTiets { get; set; }
    }
}
