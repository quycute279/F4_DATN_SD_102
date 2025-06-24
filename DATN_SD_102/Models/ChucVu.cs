using System.ComponentModel.DataAnnotations;

namespace F4_API.Models
{
    public class ChucVu
    {
        [Key]
        public Guid ChucVuId { get; set; }
        public string TenChucVu { get; set; } = null!;
        public string? MoTaChucVu { get; set; }
        public bool? TrangThai { get; set; }

        public ICollection<NhanVien>? NhanViens { get; set; }
    }
}
