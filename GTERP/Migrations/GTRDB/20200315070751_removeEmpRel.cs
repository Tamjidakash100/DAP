using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class removeEmpRel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HrEmpReleased");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HrEmpReleased",
                columns: table => new
                {
                    ComId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DtPresentLast = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DtReleased = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DtSubmit = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EmpId = table.Column<long>(type: "bigint", nullable: false),
                    IsApproved = table.Column<byte>(type: "tinyint", nullable: false),
                    LuserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pcname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RelId = table.Column<long>(type: "bigint", nullable: false),
                    RelType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HrEmpReleased", x => x.ComId);
                });
        }
    }
}
