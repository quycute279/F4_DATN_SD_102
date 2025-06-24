using System.ComponentModel.DataAnnotations;

namespace F4_API.Models
{
    public class DanhMuc_LinhKien_ThuocTinh
    {
        [Key]
        public Guid ThuocTinh { get; set; }
        public Guid? DanhMucId { get; set; }
        public string? TenThuocTinh { get; set; }
        public string? DonVi { get; set; }

        public DanhMuc? DanhMuc { get; set; }
        public ICollection<LinhKienCT>? LinhKienCTs { get; set; }
    }
}
