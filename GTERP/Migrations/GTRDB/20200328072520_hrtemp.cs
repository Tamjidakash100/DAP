using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class hrtemp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HR_ProssType",
                columns: table => new
                {
                    ProssId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComId = table.Column<string>(maxLength: 80, nullable: true),
                    ProssDt = table.Column<DateTime>(nullable: false),
                    DaySts = table.Column<string>(maxLength: 10, nullable: true),
                    DayStsB = table.Column<string>(maxLength: 10, nullable: true),
                    IsLock = table.Column<string>(nullable: true),
                    PcName = table.Column<string>(maxLength: 80, nullable: true),
                    UserId = table.Column<string>(maxLength: 80, nullable: true),
                    DtTran = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HR_ProssType", x => x.ProssId);
                });

            migrationBuilder.CreateTable(
                name: "HR_TempCount",
                columns: table => new
                {
                    TId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpId = table.Column<string>(maxLength: 50, nullable: true),
                    ComId = table.Column<string>(maxLength: 80, nullable: true),
                    Cnt = table.Column<float>(nullable: false),
                    Cnt1 = table.Column<float>(nullable: false),
                    Code = table.Column<string>(maxLength: 50, nullable: true),
                    Code1 = table.Column<string>(maxLength: 50, nullable: true),
                    DateTime1 = table.Column<DateTime>(nullable: false),
                    DateTime2 = table.Column<DateTime>(nullable: false),
                    DateTime3 = table.Column<DateTime>(nullable: false),
                    Vchr = table.Column<string>(maxLength: 50, nullable: true),
                    Vchr1 = table.Column<string>(maxLength: 50, nullable: true),
                    Vchr2 = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HR_TempCount", x => x.TId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HR_ProssType");

            migrationBuilder.DropTable(
                name: "HR_TempCount");
        }
    }
}
