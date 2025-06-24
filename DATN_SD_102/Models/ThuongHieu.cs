using System.ComponentModel.DataAnnotations;

namespace F4_API.Models
{
    public class ThuongHieu
    {
        [Key]
        public Guid ThuongHieuId { get; set; }
        public string TenThuongHieu { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Sdt { get; set; } = null!;
        public string? DiaChi { get; set; }
        public string? MoTa { get; set; }
        public bool TrangThai { get; set; }

        public ICollection<LinhKienCT>? LinhKienCTs { get; set; }
    }
}
