using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace F4_API.Migrations
{
    /// <inheritdoc />
    public partial class _2_7_L2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChucVus",
                columns: table => new
                {
                    ChucVuId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenChucVu = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MoTaChucVu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrangThai = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChucVus", x => x.ChucVuId);
                });

            migrationBuilder.CreateTable(
                name: "Combos",
                columns: table => new
                {
                    ComboId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GiaTien = table.Column<double>(type: "float", nullable: false),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Combos", x => x.ComboId);
                });

            migrationBuilder.CreateTable(
                name: "DanhMucs",
                columns: table => new
                {
                    DanhMucId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenDanhMuc = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhMucs", x => x.DanhMucId);
                });

            migrationBuilder.CreateTable(
                name: "GiamGias",
                columns: table => new
                {
                    GiamGiaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenGiamGia = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SanPhamKhuyenMai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhanTramGiam = table.Column<double>(type: "float", nullable: false),
                    NgayBatDau = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayKetThuc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GiamGias", x => x.GiamGiaId);
                });

            migrationBuilder.CreateTable(
                name: "HinhThucThanhToans",
                columns: table => new
                {
                    HinhThucThanhToanId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenHinhThuc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HinhThucThanhToans", x => x.HinhThucThanhToanId);
                });

            migrationBuilder.CreateTable(
                name: "TaiKhoans",
                columns: table => new
                {
                    TaiKhoanId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayTaoTaiKhoan = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaiKhoans", x => x.TaiKhoanId);
                });

            migrationBuilder.CreateTable(
                name: "ThuongHieus",
                columns: table => new
                {
                    ThuongHieuId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenThuongHieu = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sdt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThuongHieus", x => x.ThuongHieuId);
                });

            migrationBuilder.CreateTable(
                name: "DanhMuc_LinhKien_ThuocTinhs",
                columns: table => new
                {
                    ThuocTinh = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DanhMucId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TenThuocTinh = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DonVi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhMuc_LinhKien_ThuocTinhs", x => x.ThuocTinh);
                    table.ForeignKey(
                        name: "FK_DanhMuc_LinhKien_ThuocTinhs_DanhMucs_DanhMucId",
                        column: x => x.DanhMucId,
                        principalTable: "DanhMucs",
                        principalColumn: "DanhMucId");
                });

            migrationBuilder.CreateTable(
                name: "LinhKiens",
                columns: table => new
                {
                    LkId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenLinhKien = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DanhMucId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Gia = table.Column<double>(type: "float", nullable: true),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrangThai = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinhKiens", x => x.LkId);
                    table.ForeignKey(
                        name: "FK_LinhKiens_DanhMucs_DanhMucId",
                        column: x => x.DanhMucId,
                        principalTable: "DanhMucs",
                        principalColumn: "DanhMucId");
                });

            migrationBuilder.CreateTable(
                name: "KhachHangs",
                columns: table => new
                {
                    KhachHangId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenKhachHang = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    GioiTinh = table.Column<bool>(type: "bit", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sdt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayCapNhatCuoiCung = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false),
                    TaiKhoanId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhachHangs", x => x.KhachHangId);
                    table.ForeignKey(
                        name: "FK_KhachHangs_TaiKhoans_TaiKhoanId",
                        column: x => x.TaiKhoanId,
                        principalTable: "TaiKhoans",
                        principalColumn: "TaiKhoanId");
                });

            migrationBuilder.CreateTable(
                name: "NhanViens",
                columns: table => new
                {
                    NhanVienId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HoVaTen = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    GioiTinh = table.Column<bool>(type: "bit", nullable: false),
                    Sdt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NgayCapNhatCuoiCung = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false),
                    ChucVuId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TaiKhoanId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhanViens", x => x.NhanVienId);
                    table.ForeignKey(
                        name: "FK_NhanViens_ChucVus_ChucVuId",
                        column: x => x.ChucVuId,
                        principalTable: "ChucVus",
                        principalColumn: "ChucVuId");
                    table.ForeignKey(
                        name: "FK_NhanViens_TaiKhoans_TaiKhoanId",
                        column: x => x.TaiKhoanId,
                        principalTable: "TaiKhoans",
                        principalColumn: "TaiKhoanId");
                });

            migrationBuilder.CreateTable(
                name: "Vouchers",
                columns: table => new
                {
                    VoucherId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenVoucher = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NgayBatDau = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayKetThuc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PhanTram = table.Column<float>(type: "real", nullable: false),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    IdTaiKhoan = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TaiKhoanId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vouchers", x => x.VoucherId);
                    table.ForeignKey(
                        name: "FK_Vouchers_TaiKhoans_TaiKhoanId",
                        column: x => x.TaiKhoanId,
                        principalTable: "TaiKhoans",
                        principalColumn: "TaiKhoanId");
                });

            migrationBuilder.CreateTable(
                name: "LinhKienCTs",
                columns: table => new
                {
                    LkctId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LkId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ThuocTinhId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    GiaTri = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HinhAnhId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ThuongHieuId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoLuongTonKho = table.Column<int>(type: "int", nullable: true),
                    TrangThai = table.Column<bool>(type: "bit", nullable: true),
                    LinhKienLkId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinhKienCTs", x => x.LkctId);
                    table.ForeignKey(
                        name: "FK_LinhKienCTs_DanhMuc_LinhKien_ThuocTinhs_ThuocTinhId",
                        column: x => x.ThuocTinhId,
                        principalTable: "DanhMuc_LinhKien_ThuocTinhs",
                        principalColumn: "ThuocTinh");
                    table.ForeignKey(
                        name: "FK_LinhKienCTs_LinhKiens_LinhKienLkId",
                        column: x => x.LinhKienLkId,
                        principalTable: "LinhKiens",
                        principalColumn: "LkId");
                    table.ForeignKey(
                        name: "FK_LinhKienCTs_ThuongHieus_ThuongHieuId",
                        column: x => x.ThuongHieuId,
                        principalTable: "ThuongHieus",
                        principalColumn: "ThuongHieuId");
                });

            migrationBuilder.CreateTable(
                name: "LKDotGiamGias",
                columns: table => new
                {
                    LKDotGiamGiaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LkId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    GiamGiaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LinhKienLkId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LKDotGiamGias", x => x.LKDotGiamGiaId);
                    table.ForeignKey(
                        name: "FK_LKDotGiamGias_GiamGias_GiamGiaId",
                        column: x => x.GiamGiaId,
                        principalTable: "GiamGias",
                        principalColumn: "GiamGiaId");
                    table.ForeignKey(
                        name: "FK_LKDotGiamGias_LinhKiens_LinhKienLkId",
                        column: x => x.LinhKienLkId,
                        principalTable: "LinhKiens",
                        principalColumn: "LkId");
                });

            migrationBuilder.CreateTable(
                name: "DiaChiKhachHangs",
                columns: table => new
                {
                    DiaChiKhachHangId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenDiaChi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThanhPho = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuanHuyen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhuongXa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false),
                    KhachHangId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiaChiKhachHangs", x => x.DiaChiKhachHangId);
                    table.ForeignKey(
                        name: "FK_DiaChiKhachHangs_KhachHangs_KhachHangId",
                        column: x => x.KhachHangId,
                        principalTable: "KhachHangs",
                        principalColumn: "KhachHangId");
                });

            migrationBuilder.CreateTable(
                name: "GioHangs",
                columns: table => new
                {
                    GioHangId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    KhachHangId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GioHangs", x => x.GioHangId);
                    table.ForeignKey(
                        name: "FK_GioHangs_KhachHangs_KhachHangId",
                        column: x => x.KhachHangId,
                        principalTable: "KhachHangs",
                        principalColumn: "KhachHangId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NhapHangs",
                columns: table => new
                {
                    NhapHangId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NgayNhap = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NhaCungCap = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NhanVienId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhapHangs", x => x.NhapHangId);
                    table.ForeignKey(
                        name: "FK_NhapHangs_NhanViens_NhanVienId",
                        column: x => x.NhanVienId,
                        principalTable: "NhanViens",
                        principalColumn: "NhanVienId");
                });

            migrationBuilder.CreateTable(
                name: "HoaDons",
                columns: table => new
                {
                    HoaDonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TaiKhoanId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    VoucherId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    KhachHangId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    HinhThucThanhToanId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TenKhachHang = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoDienThoaiKh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailKh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayNhanHang = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TienShip = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TongTienSauKhiGiam = table.Column<double>(type: "float", nullable: false),
                    TrangThai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoaDons", x => x.HoaDonId);
                    table.ForeignKey(
                        name: "FK_HoaDons_HinhThucThanhToans_HinhThucThanhToanId",
                        column: x => x.HinhThucThanhToanId,
                        principalTable: "HinhThucThanhToans",
                        principalColumn: "HinhThucThanhToanId");
                    table.ForeignKey(
                        name: "FK_HoaDons_KhachHangs_KhachHangId",
                        column: x => x.KhachHangId,
                        principalTable: "KhachHangs",
                        principalColumn: "KhachHangId");
                    table.ForeignKey(
                        name: "FK_HoaDons_TaiKhoans_TaiKhoanId",
                        column: x => x.TaiKhoanId,
                        principalTable: "TaiKhoans",
                        principalColumn: "TaiKhoanId");
                    table.ForeignKey(
                        name: "FK_HoaDons_Vouchers_VoucherId",
                        column: x => x.VoucherId,
                        principalTable: "Vouchers",
                        principalColumn: "VoucherId");
                });

            migrationBuilder.CreateTable(
                name: "ComboChiTiets",
                columns: table => new
                {
                    ComboChiTietId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ComboId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LinhKienId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SoLuong = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComboChiTiets", x => x.ComboChiTietId);
                    table.ForeignKey(
                        name: "FK_ComboChiTiets_Combos_ComboId",
                        column: x => x.ComboId,
                        principalTable: "Combos",
                        principalColumn: "ComboId");
                    table.ForeignKey(
                        name: "FK_ComboChiTiets_LinhKienCTs_LinhKienId",
                        column: x => x.LinhKienId,
                        principalTable: "LinhKienCTs",
                        principalColumn: "LkctId");
                });

            migrationBuilder.CreateTable(
                name: "HinhAnhs",
                columns: table => new
                {
                    HinhAnhId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DuongDan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenAnh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false),
                    LinhKienCtId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HinhAnhs", x => x.HinhAnhId);
                    table.ForeignKey(
                        name: "FK_HinhAnhs_LinhKienCTs_LinhKienCtId",
                        column: x => x.LinhKienCtId,
                        principalTable: "LinhKienCTs",
                        principalColumn: "LkctId");
                });

            migrationBuilder.CreateTable(
                name: "GioHangCTs",
                columns: table => new
                {
                    GioHangCTId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    DonGia = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GioHangId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LkId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LinhKienLkId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GioHangCTs", x => x.GioHangCTId);
                    table.ForeignKey(
                        name: "FK_GioHangCTs_GioHangs_GioHangId",
                        column: x => x.GioHangId,
                        principalTable: "GioHangs",
                        principalColumn: "GioHangId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GioHangCTs_LinhKiens_LinhKienLkId",
                        column: x => x.LinhKienLkId,
                        principalTable: "LinhKiens",
                        principalColumn: "LkId");
                });

            migrationBuilder.CreateTable(
                name: "ChiTietNhapHangs",
                columns: table => new
                {
                    ChiTietNhapHangId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LinhKienCTId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    GiaTien = table.Column<double>(type: "float", nullable: false),
                    NhapHangId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietNhapHangs", x => x.ChiTietNhapHangId);
                    table.ForeignKey(
                        name: "FK_ChiTietNhapHangs_LinhKienCTs_LinhKienCTId",
                        column: x => x.LinhKienCTId,
                        principalTable: "LinhKienCTs",
                        principalColumn: "LkctId");
                    table.ForeignKey(
                        name: "FK_ChiTietNhapHangs_NhapHangs_NhapHangId",
                        column: x => x.NhapHangId,
                        principalTable: "NhapHangs",
                        principalColumn: "NhapHangId");
                });

            migrationBuilder.CreateTable(
                name: "HoaDonCTs",
                columns: table => new
                {
                    HoaDonChiTietId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LkctId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    HoaDonId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SoLuongSanPham = table.Column<int>(type: "int", nullable: true),
                    Gia = table.Column<double>(type: "float", nullable: true),
                    ComboId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LinhKienCTLkctId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoaDonCTs", x => x.HoaDonChiTietId);
                    table.ForeignKey(
                        name: "FK_HoaDonCTs_Combos_ComboId",
                        column: x => x.ComboId,
                        principalTable: "Combos",
                        principalColumn: "ComboId");
                    table.ForeignKey(
                        name: "FK_HoaDonCTs_HoaDons_HoaDonId",
                        column: x => x.HoaDonId,
                        principalTable: "HoaDons",
                        principalColumn: "HoaDonId");
                    table.ForeignKey(
                        name: "FK_HoaDonCTs_LinhKienCTs_LinhKienCTLkctId",
                        column: x => x.LinhKienCTLkctId,
                        principalTable: "LinhKienCTs",
                        principalColumn: "LkctId");
                });

            migrationBuilder.InsertData(
                table: "ChucVus",
                columns: new[] { "ChucVuId", "MoTaChucVu", "TenChucVu", "TrangThai" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), "Quản trị hệ thống", "Admin", true },
                    { new Guid("22222222-2222-2222-2222-222222222222"), "Nhân viên bán hàng", "NhanVien", true }
                });

            migrationBuilder.InsertData(
                table: "DanhMucs",
                columns: new[] { "DanhMucId", "MoTa", "TenDanhMuc", "TrangThai" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), "Trung tâm xử lý dữ liệu chính của máy tính.", "CPU (Vi xử lý)", true },
                    { new Guid("00000000-0000-0000-0000-000000000002"), "Kết nối các linh kiện lại với nhau, cung cấp nguồn và tín hiệu.", "Mainboard (Bo mạch chủ)", true },
                    { new Guid("00000000-0000-0000-0000-000000000003"), "Lưu trữ dữ liệu tạm thời khi máy hoạt động, càng nhiều RAM thì xử lý đa nhiệm càng tốt.", "RAM (Bộ nhớ tạm)", true },
                    { new Guid("00000000-0000-0000-0000-000000000004"), "Lưu trữ hệ điều hành, phần mềm, dữ liệu người dùng.", "Ổ cứng (SSD/HDD)", true },
                    { new Guid("00000000-0000-0000-0000-000000000005"), "Cung cấp điện năng cho toàn bộ hệ thống.", "Nguồn (PSU)", true },
                    { new Guid("00000000-0000-0000-0000-000000000006"), "Bảo vệ linh kiện, hỗ trợ tản nhiệt, định hình hệ thống.", "Case (Vỏ máy tính)", true },
                    { new Guid("00000000-0000-0000-0000-000000000007"), "Dùng cho xử lý đồ họa, gaming, thiết kế, dựng phim. Một số CPU đã tích hợp GPU sẵn.", "Card đồ họa (GPU)", true },
                    { new Guid("00000000-0000-0000-0000-000000000008"), "Có thể là tản nhiệt khí hoặc nước, dùng cho CPU hoặc cả hệ thống.", "Tản nhiệt (Cooling)", true }
                });

            migrationBuilder.InsertData(
                table: "TaiKhoans",
                columns: new[] { "TaiKhoanId", "NgayTaoTaiKhoan", "Password", "Username" },
                values: new object[] { new Guid("99999999-9999-9999-9999-999999999999"), new DateTime(2025, 7, 2, 22, 43, 15, 589, DateTimeKind.Local).AddTicks(8000), "admin123", "admin" });

            migrationBuilder.InsertData(
                table: "DanhMuc_LinhKien_ThuocTinhs",
                columns: new[] { "ThuocTinh", "DanhMucId", "DonVi", "TenThuocTinh", "TrangThai" },
                values: new object[,]
                {
                    { new Guid("11111111-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000001"), "Nhân", "Số nhân", true },
                    { new Guid("11111111-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000001"), "Luồng", "Số luồng", true },
                    { new Guid("11111111-0000-0000-0000-000000000003"), new Guid("00000000-0000-0000-0000-000000000001"), "GHz", "Xung nhịp", true },
                    { new Guid("22222222-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000002"), null, "Socket", true },
                    { new Guid("22222222-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000002"), null, "Chipset", true },
                    { new Guid("33333333-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000003"), "GB", "Dung lượng", true },
                    { new Guid("33333333-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000003"), "MHz", "Bus", true },
                    { new Guid("44444444-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000004"), null, "Loại", true },
                    { new Guid("44444444-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000004"), "GB", "Dung lượng", true },
                    { new Guid("55555555-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000005"), "W", "Công suất", true },
                    { new Guid("66666666-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000006"), null, "Loại vỏ", true },
                    { new Guid("77777777-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000007"), "GB", "Dung lượng VRAM", true },
                    { new Guid("88888888-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000008"), null, "Loại tản", true }
                });

            migrationBuilder.InsertData(
                table: "NhanViens",
                columns: new[] { "NhanVienId", "ChucVuId", "DiaChi", "Email", "GioiTinh", "HoVaTen", "NgayCapNhatCuoiCung", "NgaySinh", "NgayTao", "Sdt", "TaiKhoanId", "TrangThai" },
                values: new object[] { new Guid("88888888-8888-8888-8888-888888888888"), new Guid("11111111-1111-1111-1111-111111111111"), "Tòa nhà FPT Polytechnic, phố Trịnh Văn Bô, phường Phương Canh, quận Nam Từ Liêm, TP. Hà Nội", "admin@shop.com", false, "Nguyễn Văn Quản Trị", new DateTime(2025, 7, 2, 22, 43, 15, 589, DateTimeKind.Local).AddTicks(8038), new DateTime(1995, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 2, 22, 43, 15, 589, DateTimeKind.Local).AddTicks(8037), "0987654321", new Guid("99999999-9999-9999-9999-999999999999"), true });

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietNhapHangs_LinhKienCTId",
                table: "ChiTietNhapHangs",
                column: "LinhKienCTId");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietNhapHangs_NhapHangId",
                table: "ChiTietNhapHangs",
                column: "NhapHangId");

            migrationBuilder.CreateIndex(
                name: "IX_ComboChiTiets_ComboId",
                table: "ComboChiTiets",
                column: "ComboId");

            migrationBuilder.CreateIndex(
                name: "IX_ComboChiTiets_LinhKienId",
                table: "ComboChiTiets",
                column: "LinhKienId");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMuc_LinhKien_ThuocTinhs_DanhMucId",
                table: "DanhMuc_LinhKien_ThuocTinhs",
                column: "DanhMucId");

            migrationBuilder.CreateIndex(
                name: "IX_DiaChiKhachHangs_KhachHangId",
                table: "DiaChiKhachHangs",
                column: "KhachHangId");

            migrationBuilder.CreateIndex(
                name: "IX_GioHangCTs_GioHangId",
                table: "GioHangCTs",
                column: "GioHangId");

            migrationBuilder.CreateIndex(
                name: "IX_GioHangCTs_LinhKienLkId",
                table: "GioHangCTs",
                column: "LinhKienLkId");

            migrationBuilder.CreateIndex(
                name: "IX_GioHangs_KhachHangId",
                table: "GioHangs",
                column: "KhachHangId");

            migrationBuilder.CreateIndex(
                name: "IX_HinhAnhs_LinhKienCtId",
                table: "HinhAnhs",
                column: "LinhKienCtId");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDonCTs_ComboId",
                table: "HoaDonCTs",
                column: "ComboId");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDonCTs_HoaDonId",
                table: "HoaDonCTs",
                column: "HoaDonId");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDonCTs_LinhKienCTLkctId",
                table: "HoaDonCTs",
                column: "LinhKienCTLkctId");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDons_HinhThucThanhToanId",
                table: "HoaDons",
                column: "HinhThucThanhToanId");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDons_KhachHangId",
                table: "HoaDons",
                column: "KhachHangId");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDons_TaiKhoanId",
                table: "HoaDons",
                column: "TaiKhoanId");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDons_VoucherId",
                table: "HoaDons",
                column: "VoucherId");

            migrationBuilder.CreateIndex(
                name: "IX_KhachHangs_TaiKhoanId",
                table: "KhachHangs",
                column: "TaiKhoanId");

            migrationBuilder.CreateIndex(
                name: "IX_LinhKienCTs_LinhKienLkId",
                table: "LinhKienCTs",
                column: "LinhKienLkId");

            migrationBuilder.CreateIndex(
                name: "IX_LinhKienCTs_ThuocTinhId",
                table: "LinhKienCTs",
                column: "ThuocTinhId");

            migrationBuilder.CreateIndex(
                name: "IX_LinhKienCTs_ThuongHieuId",
                table: "LinhKienCTs",
                column: "ThuongHieuId");

            migrationBuilder.CreateIndex(
                name: "IX_LinhKiens_DanhMucId",
                table: "LinhKiens",
                column: "DanhMucId");

            migrationBuilder.CreateIndex(
                name: "IX_LKDotGiamGias_GiamGiaId",
                table: "LKDotGiamGias",
                column: "GiamGiaId");

            migrationBuilder.CreateIndex(
                name: "IX_LKDotGiamGias_LinhKienLkId",
                table: "LKDotGiamGias",
                column: "LinhKienLkId");

            migrationBuilder.CreateIndex(
                name: "IX_NhanViens_ChucVuId",
                table: "NhanViens",
                column: "ChucVuId");

            migrationBuilder.CreateIndex(
                name: "IX_NhanViens_TaiKhoanId",
                table: "NhanViens",
                column: "TaiKhoanId");

            migrationBuilder.CreateIndex(
                name: "IX_NhapHangs_NhanVienId",
                table: "NhapHangs",
                column: "NhanVienId");

            migrationBuilder.CreateIndex(
                name: "IX_Vouchers_TaiKhoanId",
                table: "Vouchers",
                column: "TaiKhoanId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChiTietNhapHangs");

            migrationBuilder.DropTable(
                name: "ComboChiTiets");

            migrationBuilder.DropTable(
                name: "DiaChiKhachHangs");

            migrationBuilder.DropTable(
                name: "GioHangCTs");

            migrationBuilder.DropTable(
                name: "HinhAnhs");

            migrationBuilder.DropTable(
                name: "HoaDonCTs");

            migrationBuilder.DropTable(
                name: "LKDotGiamGias");

            migrationBuilder.DropTable(
                name: "NhapHangs");

            migrationBuilder.DropTable(
                name: "GioHangs");

            migrationBuilder.DropTable(
                name: "Combos");

            migrationBuilder.DropTable(
                name: "HoaDons");

            migrationBuilder.DropTable(
                name: "LinhKienCTs");

            migrationBuilder.DropTable(
                name: "GiamGias");

            migrationBuilder.DropTable(
                name: "NhanViens");

            migrationBuilder.DropTable(
                name: "HinhThucThanhToans");

            migrationBuilder.DropTable(
                name: "KhachHangs");

            migrationBuilder.DropTable(
                name: "Vouchers");

            migrationBuilder.DropTable(
                name: "DanhMuc_LinhKien_ThuocTinhs");

            migrationBuilder.DropTable(
                name: "LinhKiens");

            migrationBuilder.DropTable(
                name: "ThuongHieus");

            migrationBuilder.DropTable(
                name: "ChucVus");

            migrationBuilder.DropTable(
                name: "TaiKhoans");

            migrationBuilder.DropTable(
                name: "DanhMucs");
        }
    }
}
