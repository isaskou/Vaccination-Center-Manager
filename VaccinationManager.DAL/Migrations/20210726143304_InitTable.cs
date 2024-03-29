﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VaccinationManager.DAL.Migrations
{
    public partial class InitTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Adress",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Street = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Number = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    PostalCode = table.Column<int>(type: "int", maxLength: 4, nullable: false),
                    City = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adress", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FifteenHour",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FifteenHour", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InLog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InLog", x => x.Id);
                    table.CheckConstraint("CK_InDate", "InDate>=GetDate()");
                    table.CheckConstraint("CK_Quantity", "Quantity>0");
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Tel = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Email = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Salt = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                    table.CheckConstraint("CK_Email", "Email LIKE '_%@_%'");
                });

            migrationBuilder.CreateTable(
                name: "VaccinType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VaccinType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VaccinProvider",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    AdressId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VaccinProvider", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VaccinProvider_Adress_AdressId",
                        column: x => x.AdressId,
                        principalTable: "Adress",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Patient",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NationalRegister = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AdressId = table.Column<int>(type: "int", nullable: false),
                    MedicalIndication = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    PersonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patient_Adress_AdressId",
                        column: x => x.AdressId,
                        principalTable: "Adress",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Patient_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Staff",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Grade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staff", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Staff_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MedicalStaff",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InamiCode = table.Column<long>(type: "bigint", maxLength: 11, nullable: false),
                    StaffId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalStaff", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicalStaff_Staff_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Staff",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "VaccinationCenter",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    AdressId = table.Column<int>(type: "int", nullable: false),
                    ManagerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VaccinationCenter", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VaccinationCenter_Adress_AdressId",
                        column: x => x.AdressId,
                        principalTable: "Adress",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_VaccinationCenter_MedicalStaff_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "MedicalStaff",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Appointment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FifteenHourId = table.Column<int>(type: "int", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    VaccinTypeId = table.Column<int>(type: "int", nullable: false),
                    CenterId = table.Column<int>(type: "int", nullable: false),
                    InjectionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointment", x => x.Id);
                    table.CheckConstraint("CK_Date", "[Date]>= GETDATE()");
                    table.ForeignKey(
                        name: "FK_Appointment_FifteenHour_FifteenHourId",
                        column: x => x.FifteenHourId,
                        principalTable: "FifteenHour",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Appointment_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patient",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Appointment_VaccinationCenter_CenterId",
                        column: x => x.CenterId,
                        principalTable: "VaccinationCenter",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Appointment_VaccinType_VaccinTypeId",
                        column: x => x.VaccinTypeId,
                        principalTable: "VaccinType",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ScheduleCenter",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Day = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OpenHour = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CloseHour = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CenterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleCenter", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScheduleCenter_VaccinationCenter_CenterId",
                        column: x => x.CenterId,
                        principalTable: "VaccinationCenter",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "VaccinLot",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VaccinTypeId = table.Column<int>(type: "int", nullable: false),
                    ProviderId = table.Column<int>(type: "int", nullable: false),
                    InLogId = table.Column<int>(type: "int", nullable: false),
                    CenterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VaccinLot", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VaccinLot_InLog_InLogId",
                        column: x => x.InLogId,
                        principalTable: "InLog",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_VaccinLot_VaccinationCenter_CenterId",
                        column: x => x.CenterId,
                        principalTable: "VaccinationCenter",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_VaccinLot_VaccinProvider_ProviderId",
                        column: x => x.ProviderId,
                        principalTable: "VaccinProvider",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_VaccinLot_VaccinType_VaccinTypeId",
                        column: x => x.VaccinTypeId,
                        principalTable: "VaccinType",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Injection",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VaccinLotId = table.Column<int>(type: "int", nullable: false),
                    MedicalStaffId = table.Column<int>(type: "int", nullable: false),
                    AppointmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Injection", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Injection_Appointment_AppointmentId",
                        column: x => x.AppointmentId,
                        principalTable: "Appointment",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Injection_MedicalStaff_MedicalStaffId",
                        column: x => x.MedicalStaffId,
                        principalTable: "MedicalStaff",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Injection_VaccinLot_VaccinLotId",
                        column: x => x.VaccinLotId,
                        principalTable: "VaccinLot",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OutLog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OutDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    VaccinLotId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutLog", x => x.Id);
                    table.CheckConstraint("CK_OutDateQuantity", "Quantity >0");
                    table.ForeignKey(
                        name: "FK_OutLog_VaccinLot_VaccinLotId",
                        column: x => x.VaccinLotId,
                        principalTable: "VaccinLot",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Adress",
                columns: new[] { "Id", "City", "District", "Number", "PostalCode", "Street" },
                values: new object[,]
                {
                    { 1, "Court-Saint-Etienne", "BrabantWallon", "2", 1490, "Boucle Joseph Dewez" },
                    { 2, "Charleroi", "Hainaut", "-", 6000, "Esplanade du Conseil de l’Europe" },
                    { 3, "Mons", "Hainaut", "2", 7000, "Avenue Thomas Edison" },
                    { 4, "Ronquières", "Hainaut", "1", 7090, "Rue Rosemont" },
                    { 5, "Tournai", "Hainaut", "2", 7500, "Avenue de Gaulle" },
                    { 6, "Grâce-Hollogne", "Liège", "1", 4460, "Rue de l’Aéroport" },
                    { 7, "Pepinster", "Liège", "1", 4860, "Rue du Paire" },
                    { 8, "Marche-en-Famenne", "Luxembourg", "1", 6900, "Rue des Deux Provinces" },
                    { 9, "Namur", "Namur", "2", 5000, "Avenue Sergent Vrithoff" }
                });

            migrationBuilder.InsertData(
                table: "Person",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Password", "Salt", "Tel", "Token" },
                values: new object[] { 1, "isabel@mail.be", "Isabel", "Skou", new byte[] { 38, 51, 115, 128, 106, 120, 33, 252, 158, 76, 83, 181, 151, 85, 253, 33, 238, 63, 230, 227, 194, 31, 216, 21, 178, 22, 85, 222, 215, 203, 207, 187 }, "1cf03a94-11f8-491f-9da2-a1a82424cdaa", null, null });

            migrationBuilder.InsertData(
                table: "Staff",
                columns: new[] { "Id", "Grade", "PersonId" },
                values: new object[] { 1, "Medecin", 1 });

            migrationBuilder.InsertData(
                table: "MedicalStaff",
                columns: new[] { "Id", "InamiCode", "StaffId" },
                values: new object[] { 1, 12345678910L, 1 });

            migrationBuilder.InsertData(
                table: "VaccinationCenter",
                columns: new[] { "Id", "AdressId", "ManagerId", "Name" },
                values: new object[,]
                {
                    { 1, 1, 1, "PAMexpo" },
                    { 2, 2, 1, "CEME" },
                    { 3, 3, 1, "Lotto Mons Expo" },
                    { 4, 4, 1, "Village Vaccination Ronquières" },
                    { 5, 5, 1, "Hall Sportif de Tournai" },
                    { 6, 6, 1, "Bierset - Liège Airport" },
                    { 7, 7, 1, "Centre sportif de Pepinster" },
                    { 8, 8, 1, "WEX" },
                    { 9, 9, 1, "Namur Expo" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_CenterId",
                table: "Appointment",
                column: "CenterId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_FifteenHourId",
                table: "Appointment",
                column: "FifteenHourId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_PatientId",
                table: "Appointment",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_VaccinTypeId",
                table: "Appointment",
                column: "VaccinTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Injection_AppointmentId",
                table: "Injection",
                column: "AppointmentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Injection_MedicalStaffId",
                table: "Injection",
                column: "MedicalStaffId");

            migrationBuilder.CreateIndex(
                name: "IX_Injection_VaccinLotId",
                table: "Injection",
                column: "VaccinLotId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalStaff_StaffId",
                table: "MedicalStaff",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_OutLog_VaccinLotId",
                table: "OutLog",
                column: "VaccinLotId");

            migrationBuilder.CreateIndex(
                name: "IX_Patient_AdressId",
                table: "Patient",
                column: "AdressId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Patient_PersonId",
                table: "Patient",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_Email",
                table: "Person",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleCenter_CenterId",
                table: "ScheduleCenter",
                column: "CenterId");

            migrationBuilder.CreateIndex(
                name: "IX_Staff_PersonId",
                table: "Staff",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_VaccinationCenter_AdressId",
                table: "VaccinationCenter",
                column: "AdressId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VaccinationCenter_ManagerId",
                table: "VaccinationCenter",
                column: "ManagerId",
                unique: false);

            migrationBuilder.CreateIndex(
                name: "IX_VaccinLot_CenterId",
                table: "VaccinLot",
                column: "CenterId");

            migrationBuilder.CreateIndex(
                name: "IX_VaccinLot_InLogId",
                table: "VaccinLot",
                column: "InLogId");

            migrationBuilder.CreateIndex(
                name: "IX_VaccinLot_ProviderId",
                table: "VaccinLot",
                column: "ProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_VaccinLot_VaccinTypeId",
                table: "VaccinLot",
                column: "VaccinTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_VaccinProvider_AdressId",
                table: "VaccinProvider",
                column: "AdressId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Injection");

            migrationBuilder.DropTable(
                name: "OutLog");

            migrationBuilder.DropTable(
                name: "ScheduleCenter");

            migrationBuilder.DropTable(
                name: "Appointment");

            migrationBuilder.DropTable(
                name: "VaccinLot");

            migrationBuilder.DropTable(
                name: "FifteenHour");

            migrationBuilder.DropTable(
                name: "Patient");

            migrationBuilder.DropTable(
                name: "InLog");

            migrationBuilder.DropTable(
                name: "VaccinationCenter");

            migrationBuilder.DropTable(
                name: "VaccinProvider");

            migrationBuilder.DropTable(
                name: "VaccinType");

            migrationBuilder.DropTable(
                name: "MedicalStaff");

            migrationBuilder.DropTable(
                name: "Adress");

            migrationBuilder.DropTable(
                name: "Staff");

            migrationBuilder.DropTable(
                name: "Person");
        }
    }
}
