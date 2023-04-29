using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class distpolice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cat_District",
                columns: table => new
                {
                    DistId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DistName = table.Column<string>(maxLength: 25, nullable: false),
                    DistNameShort = table.Column<string>(maxLength: 15, nullable: true),
                    PcName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    UpdateByUserId = table.Column<string>(nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: true),
                    DtInput = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cat_District", x => x.DistId);
                });

            migrationBuilder.CreateTable(
                name: "Cat_PoliceStation",
                columns: table => new
                {
                    PStationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PStationName = table.Column<string>(maxLength: 30, nullable: false),
                    PStationNameB = table.Column<string>(maxLength: 30, nullable: true),
                    DistId = table.Column<int>(nullable: false),
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
                    table.PrimaryKey("PK_Cat_PoliceStation", x => x.PStationId);
                    table.ForeignKey(
                        name: "FK_Cat_PoliceStation_Cat_District_DistId",
                        column: x => x.DistId,
                        principalTable: "Cat_District",
                        principalColumn: "DistId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cat_PoliceStation_DistId",
                table: "Cat_PoliceStation",
                column: "DistId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cat_PoliceStation");

            migrationBuilder.DropTable(
                name: "Cat_District");
        }
    }
}
