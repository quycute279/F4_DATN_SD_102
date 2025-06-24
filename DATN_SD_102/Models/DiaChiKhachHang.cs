using System.ComponentModel.DataAnnotations;

namespace F4_API.Models
{
    public class DiaChiKhachHang
    {
        [Key]
        public Guid DiaChiKhachHangId { get; set; }
        public string TenDiaChi { get; set; } = null!;
        public string ThanhPho { get; set; } = null!;
        public string QuanHuyen { get; set; } = null!;
        public string PhuongXa { get; set; } = null!;
        public string? MoTa { get; set; }
        public bool TrangThai { get; set; }
        public Guid? KhachHangId { get; set; }

        public KhachHang? KhachHang { get; set; }
    }
}
