using System.ComponentModel.DataAnnotations;

namespace F4_API.Models
{
    public class ChucVu
    {
        [Key]
        public Guid ChucVuId { get; set; }
        [Required]
        [StringLength(50)]
        [RegularExpression(@"^[a-zA-ZÀÁÂÃÈÉÊÌÍÒÓÔÕÙÚĂĐĨŨƠƯàáâãèéêìíòóôõùúăđĩũơưẠ-ỹ\s0-9]+$", ErrorMessage = "Tên chỉ được chứa chữ cái tiếng Việt, số và khoảng trắng")]
        public string TenChucVu { get; set; } = null!;
        public string? MoTaChucVu { get; set; }
        public bool? TrangThai { get; set; }

        public ICollection<NhanVien>? NhanViens { get; set; }
    }
}
