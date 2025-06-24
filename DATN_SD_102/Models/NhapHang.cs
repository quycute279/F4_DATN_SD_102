using System.ComponentModel.DataAnnotations;

namespace F4_API.Models
{
    public class NhapHang
    {
        [Key]
        public Guid NhapHangId { get; set; }
        public DateTime NgayNhap { get; set; }
        public string NhaCungCap { get; set; } = null!;
        public Guid? NhanVienId { get; set; }

        public NhanVien? NhanVien { get; set; }
        public ICollection<ChiTietNhapHang>? ChiTiets { get; set; }
    }
}
