using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class HRAttendFixedTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cat_AttStatus",
                columns: table => new
                {
                    AId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AttStatus = table.Column<string>(maxLength: 5, nullable: false),
                    AttStatusDetails = table.Column<string>(maxLength: 25, nullable: true),
                    ComId = table.Column<string>(maxLength: 80, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cat_AttStatus", x => x.AId);
                });

            migrationBuilder.CreateTable(
                name: "HR_AttFixed",
                columns: table => new
                {
                    AttId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComId = table.Column<string>(maxLength: 80, nullable: true),
                    EmpId = table.Column<int>(nullable: false),
                    DtPunchDate = table.Column<DateTime>(nullable: false),
                    ShiftId = table.Column<int>(nullable: false),
                    TimeIn = table.Column<DateTime>(nullable: false),
                    TimeOut = table.Column<DateTime>(nullable: false),
                    Status = table.Column<string>(maxLength: 5, nullable: true),
                    OTHour = table.Column<float>(nullable: false),
                    Remarks = table.Column<string>(maxLength: 50, nullable: true),
                    IsInactive = table.Column<bool>(nullable: false),
                    TimeInPrev = table.Column<DateTime>(nullable: false),
                    TimeOutPrev = table.Column<DateTime>(nullable: false),
                    StatusPrev = table.Column<string>(nullable: true),
                    OTHourPrev = table.Column<float>(nullable: false),
                    PcName = table.Column<string>(maxLength: 80, nullable: true),
                    UserId = table.Column<string>(maxLength: 80, nullable: true),
                    DtTran = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HR_AttFixed", x => x.AttId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cat_AttStatus");

            migrationBuilder.DropTable(
                name: "HR_AttFixed");
        }
    }
}
