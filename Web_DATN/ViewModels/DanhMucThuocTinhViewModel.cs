using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Web_DATN.ViewModels
{
    public class DanhMucThuocTinhViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Tên thuộc tính không được để trống.")]
        public string TenThuocTinh { get; set; } = string.Empty;

        [Required(ErrorMessage = "Vui lòng chọn danh mục.")]
        public Guid? DanhMucId { get; set; }

        public bool TrangThai { get; set; }

        public List<SelectListItem>? DanhMucs { get; set; }
    }
}
