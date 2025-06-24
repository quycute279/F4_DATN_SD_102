using System.ComponentModel.DataAnnotations;

namespace F4_API.Models
{
    public class ChiTietNhapHang
    {
        [Key]
        public Guid ChiTietNhapHangId { get; set; }
        public Guid? LinhKienCTId { get; set; }
        public int SoLuong { get; set; }
        public double GiaTien { get; set; }
        public Guid? NhapHangId { get; set; }

        public LinhKienCT? LinhKienCT { get; set; }
        public NhapHang? NhapHang { get; set; }
    }
}
