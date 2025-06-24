using System.ComponentModel.DataAnnotations;

namespace F4_API.Models
{
    public class Combo
    {
        [Key]
        public Guid ComboId { get; set; }
        public string Ten { get; set; } = null!;
        public string? MoTa { get; set; }
        public DateTime? NgayTao { get; set; }
        public double GiaTien { get; set; }
        public bool TrangThai { get; set; }

        public ICollection<ComboChiTiet>? ChiTiets { get; set; }
        public ICollection<HoaDonCT>? HoaDonCTs { get; set; }
    }
}
