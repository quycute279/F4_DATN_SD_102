using System.ComponentModel.DataAnnotations;

namespace F4_API.Models
{
    public class HinhAnh
    {
        [Key]
        public Guid HinhAnhId { get; set; }
        public string DuongDan { get; set; }
        public string? TenAnh { get; set; }
        public string? MoTa { get; set; }
        public bool TrangThai { get; set; }
        public Guid? LinhKienCtId { get; set; }
        public virtual LinhKienCT? LinhKien { get; set; }
        //public ICollection<LinhKienCT>? LinhKienCTs { get; set; }
    }
}
