using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class LastUpdateMarch15 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HrEmpReleased",
                columns: table => new
                {
                    ComId = table.Column<string>(nullable: false),
                    RelId = table.Column<long>(nullable: false),
                    EmpId = table.Column<long>(nullable: false),
                    DtReleased = table.Column<DateTime>(nullable: true),
                    Remarks = table.Column<string>(nullable: true),
                    WId = table.Column<Guid>(nullable: true),
                    Pcname = table.Column<string>(nullable: true),
                    LuserId = table.Column<string>(nullable: true),
                    RelType = table.Column<string>(nullable: true),
                    IsApproved = table.Column<byte>(nullable: false),
                    DtPresentLast = table.Column<DateTime>(nullable: true),
                    DtSubmit = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HrEmpReleased", x => x.ComId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HrEmpReleased");
        }
    }
}
