using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Web_DATN.ViewModels
{
    public class LinhKienFullViewModel
    {
        public Guid? LinhKienId { get; set; }

        [Required]
        public string TenLinhKien { get; set; }

        [Required]
        public Guid DanhMucId { get; set; }

        public double Gia { get; set; }
        public string? MoTa { get; set; }
        public bool TrangThai { get; set; }

        public List<SelectListItem>? DanhMucs { get; set; }

        public List<LinhKienChiTietCreateViewModel> ThuocTinhs { get; set; } = new();
    }

    public class LinhKienChiTietCreateViewModel
    {
        [Required]
        public Guid ThuocTinhId { get; set; }

        public string GiaTri { get; set; } = string.Empty;

        public string? MoTa { get; set; }
        public bool? TrangThai { get; set; }

        public List<SelectListItem>? DanhSachThuocTinh { get; set; }
    }
}
