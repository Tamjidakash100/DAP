using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class BuidingTypeAsad2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cat_BuildingType",
                columns: table => new
                {
                    BId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuildingName = table.Column<string>(maxLength: 30, nullable: false),
                    BuildingShortName = table.Column<string>(maxLength: 30, nullable: true),
                    BuildingNameB = table.Column<string>(maxLength: 30, nullable: true),
                    ComId = table.Column<string>(nullable: true),
                    PcName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(maxLength: 128, nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    UpdateByUserId = table.Column<string>(nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: true),
                    DtInput = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cat_BuildingType", x => x.BId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cat_BuildingType");
        }
    }
}
