using System.ComponentModel.DataAnnotations;

namespace F4_API.Models
{
    public class KhachHang
    {
        [Key]

        public Guid KhachHangId { get; set; }
        public string TenKhachHang { get; set; } = null!;
        public bool GioiTinh { get; set; }
        public string Email { get; set; } = null!;
        public string Sdt { get; set; } = null!;
        public DateTime NgayTao { get; set; }
        public DateTime NgayCapNhatCuoiCung { get; set; }
        public bool TrangThai { get; set; }
        public Guid? TaiKhoanId { get; set; }

        public TaiKhoan? TaiKhoan { get; set; }
        public ICollection<HoaDon>? HoaDons { get; set; }
        public ICollection<GioHang>? GioHangs { get; set; }
        public ICollection<DiaChiKhachHang>? DiaChiKhachHangs { get; set; }
    }
}
