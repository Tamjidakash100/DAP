using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class updatemodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cat_PoliceStation");

            migrationBuilder.DropColumn(
                name: "AddByUserId",
                table: "Cat_Designation");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateAdded",
                table: "Cat_SubSection",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdated",
                table: "Cat_SubSection",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DtInput",
                table: "Cat_SubSection",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "PcName",
                table: "Cat_SubSection",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdateByUserId",
                table: "Cat_SubSection",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Cat_SubSection",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateAdded",
                table: "Cat_SubSection");

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "Cat_SubSection");

            migrationBuilder.DropColumn(
                name: "DtInput",
                table: "Cat_SubSection");

            migrationBuilder.DropColumn(
                name: "PcName",
                table: "Cat_SubSection");

            migrationBuilder.DropColumn(
                name: "UpdateByUserId",
                table: "Cat_SubSection");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Cat_SubSection");

            migrationBuilder.AddColumn<string>(
                name: "AddByUserId",
                table: "Cat_Designation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Cat_PoliceStation",
                columns: table => new
                {
                    PStationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cat_DistrictDistId = table.Column<short>(type: "smallint", nullable: true),
                    ComId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DistId = table.Column<int>(type: "int", nullable: false),
                    DtInput = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PStationName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    PStationNameB = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    PcName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateByUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cat_PoliceStation", x => x.PStationId);
                    table.ForeignKey(
                        name: "FK_Cat_PoliceStation_Cat_District_Cat_DistrictDistId",
                        column: x => x.Cat_DistrictDistId,
                        principalTable: "Cat_District",
                        principalColumn: "DistId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cat_PoliceStation_Cat_DistrictDistId",
                table: "Cat_PoliceStation",
                column: "Cat_DistrictDistId");
        }
    }
}
