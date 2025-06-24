using System.ComponentModel.DataAnnotations;

namespace F4_API.Models
{
    public class LinhKien
    {
        [Key]
        public Guid LkId { get; set; }
        public string? TenLinhKien { get; set; }
        public Guid? DanhMucId { get; set; }
        public double? Gia { get; set; }
        public string? MoTa { get; set; }
        public bool? TrangThai { get; set; }

        public DanhMuc? DanhMuc { get; set; }
        public ICollection<LinhKienCT>? ChiTiets { get; set; }
        public ICollection<GioHangCT>? GioHangCTs { get; set; }
        public ICollection<LKDotGiamGia>? DotGiamGias { get; set; }
    }
}
