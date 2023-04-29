using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class PoliceStationPostOffice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "Cat_PostOffice",
                columns: table => new
                {
                    POId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    POName = table.Column<string>(maxLength: 40, nullable: false),
                    POCode = table.Column<string>(maxLength: 40, nullable: true),
                    PONameB = table.Column<string>(maxLength: 40, nullable: true),
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
                    table.PrimaryKey("PK_Cat_PostOffice", x => x.POId);
                    table.ForeignKey(
                        name: "FK_Cat_PostOffice_Cat_District_DistId",
                        column: x => x.DistId,
                        principalTable: "Cat_District",
                        principalColumn: "DistId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cat_PoliceStation_DistId",
                table: "Cat_PoliceStation",
                column: "DistId");

            migrationBuilder.CreateIndex(
                name: "IX_Cat_PostOffice_DistId",
                table: "Cat_PostOffice",
                column: "DistId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cat_PoliceStation");

            migrationBuilder.DropTable(
                name: "Cat_PostOffice");
        }
    }
}
