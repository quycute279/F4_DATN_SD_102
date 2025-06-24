using F4_API.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace F4_API.DATA
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

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
        }
    }
}
