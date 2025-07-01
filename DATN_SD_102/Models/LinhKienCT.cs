using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace F4_API.Models
{
    public class LinhKienCT
    {
        [Key]
        public Guid LkctId { get; set; }
        public Guid? LkId { get; set; }
        public Guid? ThuocTinhId { get; set; }
        public string? GiaTri { get; set; }
        public Guid? HinhAnhId { get; set; }
        public Guid? ThuongHieuId { get; set; }
        public string? MoTa { get; set; }
        public int? SoLuongTonKho { get; set; }
        public bool? TrangThai { get; set; }

        public virtual ICollection<HinhAnh>? HinhAnhs { get; set; } = new List<HinhAnh>();
        public DanhMuc_LinhKien_ThuocTinh? ThuocTinh { get; set; }
        public ThuongHieu? ThuongHieu { get; set; }
    }
}
