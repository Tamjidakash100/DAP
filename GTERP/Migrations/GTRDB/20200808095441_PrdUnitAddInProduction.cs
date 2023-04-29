using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class PrdUnitAddInProduction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Production_Unit_UnitId",
                table: "Production");

            migrationBuilder.DropIndex(
                name: "IX_Production_UnitId",
                table: "Production");

            migrationBuilder.DropColumn(
                name: "UnitId",
                table: "Production");

            migrationBuilder.AddColumn<int>(
                name: "PrdUnitId",
                table: "Production",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Production_PrdUnitId",
                table: "Production",
                column: "PrdUnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_Production_PrdUnits_PrdUnitId",
                table: "Production",
                column: "PrdUnitId",
                principalTable: "PrdUnits",
                principalColumn: "PrdUnitId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Production_PrdUnits_PrdUnitId",
                table: "Production");

            migrationBuilder.DropIndex(
                name: "IX_Production_PrdUnitId",
                table: "Production");

            migrationBuilder.DropColumn(
                name: "PrdUnitId",
                table: "Production");

            migrationBuilder.AddColumn<int>(
                name: "UnitId",
                table: "Production",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Production_UnitId",
                table: "Production",
                column: "UnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_Production_Unit_UnitId",
                table: "Production",
                column: "UnitId",
                principalTable: "Unit",
                principalColumn: "UnitId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
