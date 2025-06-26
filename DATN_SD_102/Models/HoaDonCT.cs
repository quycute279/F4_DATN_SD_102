using System.ComponentModel.DataAnnotations;

namespace F4_API.Models
{
    public class HoaDonCT
    {
        [Key]
        public Guid HoaDonChiTietId { get; set; }
        public Guid? LkctId { get; set; }
        public Guid? HoaDonId { get; set; }
        public int? SoLuongSanPham { get; set; }
        public double? Gia { get; set; }
        public Guid? ComboId { get; set; }

        public HoaDon? HoaDon { get; set; }
        public Combo? Combo { get; set; }
        public LinhKienCT? LinhKienCT { get; set; }
    }
}
