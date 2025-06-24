using System.ComponentModel.DataAnnotations;

namespace F4_API.Models
{
    public class GioHangCT
    {
        [Key]
        public Guid GioHangCTId { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }
        public bool TrangThai { get; set; }
        public DateTime NgayTao { get; set; }
        public Guid? GioHangId { get; set; }
        public Guid? LkId { get; set; }

        public GioHang? GioHang { get; set; }
        public LinhKien? LinhKien { get; set; }
    }
}
