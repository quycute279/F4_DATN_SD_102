using System.ComponentModel.DataAnnotations;

namespace F4_API.Models
{
    public class ThuongHieu
    {
        [Key]
        public Guid ThuongHieuId { get; set; }
        [Required(ErrorMessage = "Họ tên không được để trống")]
        [StringLength(100, ErrorMessage = "Họ tên tối đa 100 ký tự")]
        public string TenThuongHieu { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Sdt { get; set; } = null!;
        public string? DiaChi { get; set; }
        public string? MoTa { get; set; }
        public bool TrangThai { get; set; }

        public ICollection<LinhKienCT>? LinhKienCTs { get; set; }
    }
}
