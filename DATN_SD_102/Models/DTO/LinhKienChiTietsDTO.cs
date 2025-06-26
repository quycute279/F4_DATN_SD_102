using System.ComponentModel.DataAnnotations;

namespace F4_API.Models.DTO
{
    public class LinhKienChiTietsDTO
    {
        [Key]
        public Guid LkctId { get; set; }
        public Guid? LkId { get; set; }
        public Guid? ThuocTinhId { get; set; }
        public string? GiaTri { get; set; }
        public Guid? HinhAnhId { get; set; }
        public Guid? ThuongHieuId { get; set; }
        public string? MoTa { get; set; }
        public bool? TrangThai { get; set; }
    }
}
