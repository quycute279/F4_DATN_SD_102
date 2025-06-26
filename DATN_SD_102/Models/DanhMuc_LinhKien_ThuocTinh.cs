using System.ComponentModel.DataAnnotations;

namespace F4_API.Models
{
    public class DanhMuc_LinhKien_ThuocTinh
    {
        [Key]
        public Guid ThuocTinh { get; set; }
        public Guid? DanhMucId { get; set; }
        [Required]
        [StringLength(50)]
        [RegularExpression(@"^[a-zA-ZÀÁÂÃÈÉÊÌÍÒÓÔÕÙÚĂĐĨŨƠƯàáâãèéêìíòóôõùúăđĩũơưẠ-ỹ\s0-9]+$", ErrorMessage = "Tên chỉ được chứa chữ cái tiếng Việt, số và khoảng trắng")]
        public string? TenThuocTinh { get; set; }
        public string? DonVi { get; set; }

        public DanhMuc? DanhMuc { get; set; }
        public ICollection<LinhKienCT>? LinhKienCTs { get; set; }
    }
}
