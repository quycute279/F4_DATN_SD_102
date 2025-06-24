using System.ComponentModel.DataAnnotations;

namespace F4_API.Models
{
    public class HinhThucThanhToan
    {
        [Key]

        public Guid HinhThucThanhToanId { get; set; }
        public string TenHinhThuc { get; set; } = null!;
        public string? MoTa { get; set; }

        public ICollection<HoaDon>? HoaDons { get; set; }
    }
}
