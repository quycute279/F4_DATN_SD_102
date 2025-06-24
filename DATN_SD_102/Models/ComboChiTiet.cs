using System.ComponentModel.DataAnnotations;

namespace F4_API.Models
{
    public class ComboChiTiet
    {
        [Key]
        public Guid ComboChiTietId { get; set; }
        public Guid? ComboId { get; set; }
        public Guid? LinhKienId { get; set; }
        public int SoLuong { get; set; }

        public Combo? Combo { get; set; }
        public LinhKienCT? LinhKienCT { get; set; }
    }
}
