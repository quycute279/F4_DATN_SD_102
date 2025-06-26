using System.ComponentModel.DataAnnotations;

namespace F4_API.Models
{
    public class NhanVien
    {
        [Key]

        public Guid NhanVienId { get; set; }
        [Required(ErrorMessage = "Họ tên không được để trống")]
        [StringLength(50, ErrorMessage = "Họ tên tối đa 50 ký tự")]
        [RegularExpression(@"^[a-zA-ZÀÁÂÃÈÉÊÌÍÒÓÔÕÙÚĂĐĨŨƠàáâãèéêìíòóôõùúăđĩũơƯĂẠẢẤẦẨẪẬẮẰẲẴẶẸẺẼỀỀỂẾưăạảấầẩẫậắằẳẵặẹẻẽềềểếỄỆỈỊỌỎỐỒỔỖỘỚỜỞỠỢỤỦỨỪễệỉịọỏốồổỗộớờởỡợụủứừỬỮỰỲỴÝỶỸửữựỳỵỷỹ\s]+$", ErrorMessage = "Họ tên chỉ chứa chữ cái và khoảng trắng")]
        public string HoVaTen { get; set; } = null!;
        public bool GioiTinh { get; set; }
        [Required(ErrorMessage = "Số điện thoại không được để trống")]
        [RegularExpression(@"^(09|03)\d{8}$", ErrorMessage = "Số điện thoại phải bắt đầu bằng 09 hoặc 03 và có đúng 10 số")]
        public string Sdt { get; set; } = null!;
        public string? DiaChi { get; set; } 
        [Required(ErrorMessage = "Email không được để trống")]
        [EmailAddress(ErrorMessage = "Email không đúng định dạng")]
        public string? Email { get; set; }
        public DateTime? NgaySinh { get; set; }
        public DateTime? NgayTao { get; set; }
        public DateTime? NgayCapNhatCuoiCung {  get; set; }
        public bool TrangThai { get; set; }

        public Guid? ChucVuId { get; set; }
        public Guid? TaiKhoanId { get; set; }

        public ChucVu? ChucVu { get; set; }
        public TaiKhoan? TaiKhoan { get; set; }
        public ICollection<NhapHang>? NhapHangs { get; set; }
    }
}
