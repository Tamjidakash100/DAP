using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class ProcessData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HrEmpReleased");

            migrationBuilder.CreateTable(
                name: "HR_Emp_Released",
                columns: table => new
                {
                    RelId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComId = table.Column<string>(maxLength: 80, nullable: true),
                    EmpId = table.Column<int>(nullable: false),
                    DtReleased = table.Column<DateTime>(nullable: true),
                    Remarks = table.Column<string>(maxLength: 120, nullable: true),
                    RelType = table.Column<string>(maxLength: 30, nullable: true),
                    IsApproved = table.Column<bool>(nullable: false),
                    DtPresentLast = table.Column<DateTime>(nullable: true),
                    DtSubmit = table.Column<DateTime>(nullable: true),
                    PcName = table.Column<string>(maxLength: 80, nullable: true),
                    UserId = table.Column<string>(maxLength: 80, nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    UpdateByUserId = table.Column<string>(maxLength: 80, nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HR_Emp_Released", x => x.RelId);
                    table.ForeignKey(
                        name: "FK_HR_Emp_Released_HR_Emp_Info_EmpId",
                        column: x => x.EmpId,
                        principalTable: "HR_Emp_Info",
                        principalColumn: "EmpId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HR_ProcessedData",
                columns: table => new
                {
                    PId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComId = table.Column<string>(maxLength: 80, nullable: true),
                    EmpId = table.Column<int>(nullable: false),
                    EmpCode = table.Column<string>(maxLength: 15, nullable: true),
                    DtPunchDate = table.Column<DateTime>(nullable: false),
                    ShiftId = table.Column<int>(nullable: false),
                    DeptId = table.Column<int>(nullable: false),
                    SectId = table.Column<int>(nullable: false),
                    TimeIn = table.Column<DateTime>(nullable: false),
                    TimeOut = table.Column<DateTime>(nullable: false),
                    Late = table.Column<DateTime>(nullable: true),
                    Status = table.Column<string>(maxLength: 5, nullable: true),
                    RegHour = table.Column<float>(nullable: false),
                    OTHour = table.Column<float>(nullable: false),
                    OTHourDed = table.Column<float>(nullable: false),
                    ROT = table.Column<float>(nullable: false),
                    EOT = table.Column<float>(nullable: false),
                    StaffOT = table.Column<float>(nullable: false),
                    IsLunchDay = table.Column<float>(nullable: false),
                    IsNightShift = table.Column<float>(nullable: false),
                    ShiftIn = table.Column<DateTime>(nullable: true),
                    Remarks = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HR_ProcessedData", x => x.PId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_Released_EmpId",
                table: "HR_Emp_Released",
                column: "EmpId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HR_Emp_Released");

            migrationBuilder.DropTable(
                name: "HR_ProcessedData");

            migrationBuilder.CreateTable(
                name: "HrEmpReleased",
                columns: table => new
                {
                    RelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DtPresentLast = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DtReleased = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DtSubmit = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EmpId = table.Column<int>(type: "int", nullable: false),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false),
                    PcName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RelType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: true),
                    UpdateByUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HrEmpReleased", x => x.RelId);
                    table.ForeignKey(
                        name: "FK_HrEmpReleased_HR_Emp_Info_EmpId",
                        column: x => x.EmpId,
                        principalTable: "HR_Emp_Info",
                        principalColumn: "EmpId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HrEmpReleased_EmpId",
                table: "HrEmpReleased",
                column: "EmpId");
        }
    }
}
