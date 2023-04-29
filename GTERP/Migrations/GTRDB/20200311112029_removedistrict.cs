using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class removedistrict : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cat_District");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cat_District",
                columns: table => new
                {
                    DistId = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DistName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    DistNameShort = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    DtInput = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PcName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateByUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cat_District", x => x.DistId);
                });
        }
    }
}
