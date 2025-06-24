using System.ComponentModel.DataAnnotations;

namespace F4_API.Models
{
    public class NhanVien
    {
        [Key]

        public Guid NhanVienId { get; set; }
        public string HoVaTen { get; set; } = null!;
        public bool GioiTinh { get; set; }
        public string Sdt { get; set; } = null!;
        public string DiaChi { get; set; } = null!;
        public string? Email { get; set; }
        public DateTime NgaySinh { get; set; }
        public bool TrangThai { get; set; }

        public Guid? ChucVuId { get; set; }
        public Guid? TaiKhoanId { get; set; }

        public ChucVu? ChucVu { get; set; }
        public TaiKhoan? TaiKhoan { get; set; }
        public ICollection<NhapHang>? NhapHangs { get; set; }
    }
}
