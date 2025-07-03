using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace F4_API.Migrations
{
    /// <inheritdoc />
    public partial class _3_7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "NhanViens",
                keyColumn: "NhanVienId",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
                columns: new[] { "NgayCapNhatCuoiCung", "NgayTao" },
                values: new object[] { new DateTime(2025, 7, 3, 9, 2, 38, 429, DateTimeKind.Local).AddTicks(2698), new DateTime(2025, 7, 3, 9, 2, 38, 429, DateTimeKind.Local).AddTicks(2698) });

            migrationBuilder.UpdateData(
                table: "TaiKhoans",
                keyColumn: "TaiKhoanId",
                keyValue: new Guid("99999999-9999-9999-9999-999999999999"),
                column: "NgayTaoTaiKhoan",
                value: new DateTime(2025, 7, 3, 9, 2, 38, 429, DateTimeKind.Local).AddTicks(2664));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "NhanViens",
                keyColumn: "NhanVienId",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
                columns: new[] { "NgayCapNhatCuoiCung", "NgayTao" },
                values: new object[] { new DateTime(2025, 7, 2, 22, 43, 15, 589, DateTimeKind.Local).AddTicks(8038), new DateTime(2025, 7, 2, 22, 43, 15, 589, DateTimeKind.Local).AddTicks(8037) });

            migrationBuilder.UpdateData(
                table: "TaiKhoans",
                keyColumn: "TaiKhoanId",
                keyValue: new Guid("99999999-9999-9999-9999-999999999999"),
                column: "NgayTaoTaiKhoan",
                value: new DateTime(2025, 7, 2, 22, 43, 15, 589, DateTimeKind.Local).AddTicks(8000));
        }
    }
}
