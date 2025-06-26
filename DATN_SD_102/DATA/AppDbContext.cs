using F4_API.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace F4_API.DATA
{
    public class AppDbContext :DbContext
    {
        protected AppDbContext()
        {
        }
       

        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=.\SQLEXPRESS;Initial Catalog=DATN_SD_102;Trusted_Connection=True;Integrated Security=True;TrustServerCertificate=True");
        }


        public DbSet<TaiKhoan> TaiKhoans { get; set; }
        public DbSet<ChucVu> ChucVus { get; set; }
        public DbSet<NhanVien> NhanViens { get; set; }
        public DbSet<KhachHang> KhachHangs { get; set; }
        public DbSet<HinhThucThanhToan> HinhThucThanhToans { get; set; }
        public DbSet<Voucher> Vouchers { get; set; }
        public DbSet<DanhMuc> DanhMucs { get; set; }
        public DbSet<DanhMuc_LinhKien_ThuocTinh> DanhMuc_LinhKien_ThuocTinhs { get; set; }
        public DbSet<LinhKien> LinhKiens { get; set; }
        public DbSet<LinhKienCT> LinhKienCTs { get; set; }
        public DbSet<Combo> Combos { get; set; }
        public DbSet<ComboChiTiet> ComboChiTiets { get; set; }
        public DbSet<GioHang> GioHangs { get; set; }
        public DbSet<GioHangCT> GioHangCTs { get; set; }
        public DbSet<HoaDon> HoaDons { get; set; }
        public DbSet<HoaDonCT> HoaDonCTs { get; set; }
        public DbSet<DiaChiKhachHang> DiaChiKhachHangs { get; set; }
        public DbSet<NhapHang> NhapHangs { get; set; }
        public DbSet<ChiTietNhapHang> ChiTietNhapHangs { get; set; }
        public DbSet<HinhAnh> HinhAnhs { get; set; }
        public DbSet<ThuongHieu> ThuongHieus { get; set; }
        public DbSet<GiamGia> GiamGias { get; set; }
        public DbSet<LKDotGiamGia> LKDotGiamGias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Khóa chính phức hợp (nếu cần bạn có thể định nghĩa ở đây)
            modelBuilder.Entity<ComboChiTiet>()
                .HasKey(x => x.ComboChiTietId);

            modelBuilder.Entity<GioHangCT>()
                .HasKey(x => x.GioHangCTId);

            modelBuilder.Entity<HoaDonCT>()
                .HasKey(x => x.HoaDonChiTietId);

            modelBuilder.Entity<ChiTietNhapHang>()
                .HasKey(x => x.ChiTietNhapHangId);

            modelBuilder.Entity<LKDotGiamGia>()
                .HasKey(x => x.LKDotGiamGiaId);

            // Tùy chỉnh các mối quan hệ nếu cần
            modelBuilder.Entity<ComboChiTiet>()
                .HasOne(x => x.LinhKienCT)
                .WithMany()
                .HasForeignKey(x => x.LinhKienId);

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ChucVu>().HasData(
             new ChucVu
             {
                 ChucVuId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                 TenChucVu = "Admin",
                 MoTaChucVu = "Quản trị hệ thống",
                 TrangThai = true,
             },
             new ChucVu
             {
                 ChucVuId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                 TenChucVu = "NhanVien",
                 MoTaChucVu = "Nhân viên bán hàng",
                 TrangThai = true
             });
            var adminTaiKhoanId = Guid.Parse("99999999-9999-9999-9999-999999999999");

            modelBuilder.Entity<TaiKhoan>().HasData(new TaiKhoan
            {
                TaiKhoanId = adminTaiKhoanId,
                Username = "admin",
                Password = "admin123",
                NgayTaoTaiKhoan = DateTime.Now
            });





            modelBuilder.Entity<NhanVien>().HasData(new NhanVien
            {
                NhanVienId = Guid.Parse("88888888-8888-8888-8888-888888888888"),
                HoVaTen = "Nguyễn Văn Quản Trị",
                Sdt = "0987654321",
                DiaChi = "Tòa nhà FPT Polytechnic, phố Trịnh Văn Bô, phường Phương Canh, quận Nam Từ Liêm, TP. Hà Nội",
                Email = "admin@shop.com",
                NgaySinh = new DateTime(1995, 1, 1),
                NgayTao = DateTime.Now,
                NgayCapNhatCuoiCung = DateTime.Now,
                TrangThai = true,
                TaiKhoanId = adminTaiKhoanId,
                ChucVuId = Guid.Parse("11111111-1111-1111-1111-111111111111")
            });
        }
    }
}
