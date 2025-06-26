using System.ComponentModel.DataAnnotations;

namespace F4_API.Models
{
    public class DanhMuc
    {
        [Key]
        public Guid DanhMucId { get; set; }
        [Required]
        [StringLength(50)]
        [RegularExpression(@"^[a-zA-ZÀÁÂÃÈÉÊÌÍÒÓÔÕÙÚĂĐĨŨƠƯàáâãèéêìíòóôõùúăđĩũơưẠ-ỹ\s0-9]+$", ErrorMessage = "Tên chỉ được chứa chữ cái tiếng Việt, số và khoảng trắng")]
        public string TenDanhMuc { get; set; } = null!;
        public string? MoTa { get; set; }

        public ICollection<LinhKien>? LinhKiens { get; set; }
        public ICollection<DanhMuc_LinhKien_ThuocTinh>? ThuocTinhs { get; set; }
    }
}
