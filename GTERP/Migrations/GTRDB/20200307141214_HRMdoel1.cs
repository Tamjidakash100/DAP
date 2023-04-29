using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class HRMdoel1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TblCatArea",
                columns: table => new
                {
                    AreaId = table.Column<short>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AreaName = table.Column<string>(nullable: true),
                    AreaNameShort = table.Column<string>(nullable: true),
                    AreaCode = table.Column<string>(nullable: true),
                    WId = table.Column<Guid>(nullable: false),
                    Pcname = table.Column<string>(nullable: true),
                    LuserId = table.Column<int>(nullable: true),
                    Comid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblCatArea", x => x.AreaId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TblCatArea");
        }
    }
}
