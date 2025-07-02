using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace F4_API.Migrations
{
    /// <inheritdoc />
    public partial class _2_7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "DanhMuc_LinhKien_ThuocTinhs",
                columns: new[] { "ThuocTinh", "DanhMucId", "DonVi", "TenThuocTinh" },
                values: new object[,]
                {
                    { new Guid("11111111-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000001"), "Nhân", "Số nhân" },
                    { new Guid("11111111-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000001"), "Luồng", "Số luồng" },
                    { new Guid("11111111-0000-0000-0000-000000000003"), new Guid("00000000-0000-0000-0000-000000000001"), "GHz", "Xung nhịp" },
                    { new Guid("22222222-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000002"), null, "Socket" },
                    { new Guid("22222222-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000002"), null, "Chipset" },
                    { new Guid("33333333-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000003"), "GB", "Dung lượng" },
                    { new Guid("33333333-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000003"), "MHz", "Bus" },
                    { new Guid("44444444-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000004"), null, "Loại" },
                    { new Guid("44444444-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000004"), "GB", "Dung lượng" },
                    { new Guid("55555555-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000005"), "W", "Công suất" },
                    { new Guid("66666666-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000006"), null, "Loại vỏ" },
                    { new Guid("77777777-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000007"), "GB", "Dung lượng VRAM" },
                    { new Guid("88888888-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000008"), null, "Loại tản" }
                });

            migrationBuilder.UpdateData(
                table: "NhanViens",
                keyColumn: "NhanVienId",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
                columns: new[] { "NgayCapNhatCuoiCung", "NgayTao" },
                values: new object[] { new DateTime(2025, 7, 2, 12, 28, 30, 758, DateTimeKind.Local).AddTicks(9766), new DateTime(2025, 7, 2, 12, 28, 30, 758, DateTimeKind.Local).AddTicks(9765) });

            migrationBuilder.UpdateData(
                table: "TaiKhoans",
                keyColumn: "TaiKhoanId",
                keyValue: new Guid("99999999-9999-9999-9999-999999999999"),
                column: "NgayTaoTaiKhoan",
                value: new DateTime(2025, 7, 2, 12, 28, 30, 758, DateTimeKind.Local).AddTicks(9703));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DanhMuc_LinhKien_ThuocTinhs",
                keyColumn: "ThuocTinh",
                keyValue: new Guid("11111111-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "DanhMuc_LinhKien_ThuocTinhs",
                keyColumn: "ThuocTinh",
                keyValue: new Guid("11111111-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "DanhMuc_LinhKien_ThuocTinhs",
                keyColumn: "ThuocTinh",
                keyValue: new Guid("11111111-0000-0000-0000-000000000003"));

            migrationBuilder.DeleteData(
                table: "DanhMuc_LinhKien_ThuocTinhs",
                keyColumn: "ThuocTinh",
                keyValue: new Guid("22222222-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "DanhMuc_LinhKien_ThuocTinhs",
                keyColumn: "ThuocTinh",
                keyValue: new Guid("22222222-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "DanhMuc_LinhKien_ThuocTinhs",
                keyColumn: "ThuocTinh",
                keyValue: new Guid("33333333-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "DanhMuc_LinhKien_ThuocTinhs",
                keyColumn: "ThuocTinh",
                keyValue: new Guid("33333333-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "DanhMuc_LinhKien_ThuocTinhs",
                keyColumn: "ThuocTinh",
                keyValue: new Guid("44444444-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "DanhMuc_LinhKien_ThuocTinhs",
                keyColumn: "ThuocTinh",
                keyValue: new Guid("44444444-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "DanhMuc_LinhKien_ThuocTinhs",
                keyColumn: "ThuocTinh",
                keyValue: new Guid("55555555-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "DanhMuc_LinhKien_ThuocTinhs",
                keyColumn: "ThuocTinh",
                keyValue: new Guid("66666666-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "DanhMuc_LinhKien_ThuocTinhs",
                keyColumn: "ThuocTinh",
                keyValue: new Guid("77777777-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "DanhMuc_LinhKien_ThuocTinhs",
                keyColumn: "ThuocTinh",
                keyValue: new Guid("88888888-0000-0000-0000-000000000001"));

            migrationBuilder.UpdateData(
                table: "NhanViens",
                keyColumn: "NhanVienId",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
                columns: new[] { "NgayCapNhatCuoiCung", "NgayTao" },
                values: new object[] { new DateTime(2025, 7, 1, 20, 58, 18, 443, DateTimeKind.Local).AddTicks(1740), new DateTime(2025, 7, 1, 20, 58, 18, 443, DateTimeKind.Local).AddTicks(1738) });

            migrationBuilder.UpdateData(
                table: "TaiKhoans",
                keyColumn: "TaiKhoanId",
                keyValue: new Guid("99999999-9999-9999-9999-999999999999"),
                column: "NgayTaoTaiKhoan",
                value: new DateTime(2025, 7, 1, 20, 58, 18, 443, DateTimeKind.Local).AddTicks(1503));
        }
    }
}
