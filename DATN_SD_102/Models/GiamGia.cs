using System.ComponentModel.DataAnnotations;

namespace F4_API.Models
{
    public class GiamGia
    {
        [Key]
        public Guid GiamGiaId { get; set; }
        [Required]
        [StringLength(50)]
        public string TenGiamGia { get; set; } = null!;
        public string? SanPhamKhuyenMai { get; set; }
        public double PhanTramGiam { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc { get; set; }
        public bool TrangThai { get; set; }

        public ICollection<LKDotGiamGia>? DotGiamGias { get; set; }
    }
}
