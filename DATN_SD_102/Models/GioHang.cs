using System.ComponentModel.DataAnnotations;

namespace F4_API.Models
{
    public class GioHang
    {
        [Key]
        public Guid GioHangId { get; set; }
        public Guid KhachHangId { get; set; }
        public DateTime NgayTao { get; set; }

        public KhachHang? KhachHang { get; set; }
        public ICollection<GioHangCT>? ChiTiets { get; set; }
    }
}
