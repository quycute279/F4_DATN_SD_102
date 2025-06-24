using System.ComponentModel.DataAnnotations;

namespace F4_API.Models
{
    public class DanhMuc
    {
        [Key]
        public Guid DanhMucId { get; set; }
        public string TenDanhMuc { get; set; } = null!;
        public string? MoTa { get; set; }

        public ICollection<LinhKien>? LinhKiens { get; set; }
        public ICollection<DanhMuc_LinhKien_ThuocTinh>? ThuocTinhs { get; set; }
    }
}
