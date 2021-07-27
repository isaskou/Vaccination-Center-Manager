using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VaccinationManager.DAL.Migrations
{
    public partial class IniTable2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_MedicalStaff_StaffId",
                table: "MedicalStaff");

            migrationBuilder.UpdateData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Password", "Salt" },
                values: new object[] { new byte[] { 25, 63, 201, 131, 112, 197, 228, 194, 41, 68, 41, 81, 1, 41, 143, 63, 253, 157, 41, 3, 135, 160, 173, 171, 243, 130, 106, 117, 62, 195, 141, 89 }, "16f979e2-0ecc-4100-b330-78d61aaf3c22" });

            migrationBuilder.CreateIndex(
                name: "IX_MedicalStaff_StaffId",
                table: "MedicalStaff",
                column: "StaffId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_MedicalStaff_StaffId",
                table: "MedicalStaff");

            migrationBuilder.UpdateData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Password", "Salt" },
                values: new object[] { new byte[] { 38, 51, 115, 128, 106, 120, 33, 252, 158, 76, 83, 181, 151, 85, 253, 33, 238, 63, 230, 227, 194, 31, 216, 21, 178, 22, 85, 222, 215, 203, 207, 187 }, "1cf03a94-11f8-491f-9da2-a1a82424cdaa" });

            migrationBuilder.CreateIndex(
                name: "IX_MedicalStaff_StaffId",
                table: "MedicalStaff",
                column: "StaffId");
        }
    }
}
