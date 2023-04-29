using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class removepolice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cat_PoliceStation");

            migrationBuilder.AlterColumn<string>(
                name: "comid",
                table: "MenuPermissionMasters",
                maxLength: 128,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "ComId",
                table: "CompanyPermissions",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "comid",
                table: "MenuPermissionMasters",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 128,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ComId",
                table: "CompanyPermissions",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 128);

            migrationBuilder.CreateTable(
                name: "Cat_PoliceStation",
                columns: table => new
                {
                    PStationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
    }
}
