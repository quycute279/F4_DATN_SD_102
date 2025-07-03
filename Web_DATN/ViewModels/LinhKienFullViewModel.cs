using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Web_DATN.ViewModels
{
    public class LinhKienFullViewModel
    {
        public Guid? LinhKienId { get; set; }

        [Required(ErrorMessage = "Tên linh kiện không được để trống")]
        public string TenLinhKien { get; set; } = null!;

        [Required(ErrorMessage = "Vui lòng chọn danh mục")]
        public Guid DanhMucId { get; set; }

        [Required(ErrorMessage = "Giá không được để trống")]
        public double Gia { get; set; }

        public string? MoTa { get; set; }

        public bool TrangThai { get; set; } = true;

        public List<SelectListItem> DanhMucs { get; set; } = new List<SelectListItem>();

        public List<LinhKienThuocTinhCreateViewModel> ThuocTinhs { get; set; } = new List<LinhKienThuocTinhCreateViewModel>();
    }

    public class LinhKienThuocTinhCreateViewModel
    {
        [Required(ErrorMessage = "Vui lòng chọn thuộc tính")]
        public Guid ThuocTinhId { get; set; }

        [Required(ErrorMessage = "Giá trị không được để trống")]
        public string GiaTri { get; set; } = string.Empty;

        public string? MoTa { get; set; }

        public bool TrangThai { get; set; } = true;

        // Dùng để hiển thị tên thuộc tính (không cần gửi khi submit)
        public string? TenThuocTinh { get; set; }
    }
}
