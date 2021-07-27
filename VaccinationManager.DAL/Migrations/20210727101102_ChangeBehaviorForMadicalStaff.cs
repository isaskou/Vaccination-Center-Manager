using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VaccinationManager.DAL.Migrations
{
    public partial class ChangeBehaviorForMadicalStaff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicalStaff_Staff_StaffId",
                table: "MedicalStaff");

            migrationBuilder.UpdateData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Password", "Salt" },
                values: new object[] { new byte[] { 125, 33, 137, 93, 199, 174, 220, 59, 129, 25, 18, 244, 159, 73, 126, 84, 51, 2, 6, 200, 198, 243, 177, 88, 51, 224, 251, 216, 151, 97, 80, 191 }, "f89cf8f7-bec3-47ef-abc4-117c9ac1d8b7" });

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalStaff_Staff_StaffId",
                table: "MedicalStaff",
                column: "StaffId",
                principalTable: "Staff",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicalStaff_Staff_StaffId",
                table: "MedicalStaff");

            migrationBuilder.UpdateData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Password", "Salt" },
                values: new object[] { new byte[] { 25, 63, 201, 131, 112, 197, 228, 194, 41, 68, 41, 81, 1, 41, 143, 63, 253, 157, 41, 3, 135, 160, 173, 171, 243, 130, 106, 117, 62, 195, 141, 89 }, "16f979e2-0ecc-4100-b330-78d61aaf3c22" });

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalStaff_Staff_StaffId",
                table: "MedicalStaff",
                column: "StaffId",
                principalTable: "Staff",
                principalColumn: "Id");
        }
    }
}
