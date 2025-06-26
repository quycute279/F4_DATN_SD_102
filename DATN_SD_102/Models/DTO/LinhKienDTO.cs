using System.ComponentModel.DataAnnotations;

namespace F4_API.Models.DTO
{
    public class LinhKienDTO
    {
        public Guid LkId { get; set; }
        public string? TenLinhKien { get; set; }
        public Guid? DanhMucId { get; set; }
        public double? Gia { get; set; }
        public string? MoTa { get; set; }
        public bool? TrangThai { get; set; }
        public List<LinhKienChiTietsDTO> linhKienCTs { get; set; } = new();

    }
}
