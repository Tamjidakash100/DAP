using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class bomupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WarehouseId",
                table: "BOMSub",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PrdUnitId",
                table: "BOMMain",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BOMSub_WarehouseId",
                table: "BOMSub",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_BOMMain_PrdUnitId",
                table: "BOMMain",
                column: "PrdUnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_BOMMain_PrdUnits_PrdUnitId",
                table: "BOMMain",
                column: "PrdUnitId",
                principalTable: "PrdUnits",
                principalColumn: "PrdUnitId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BOMSub_Warehouses_WarehouseId",
                table: "BOMSub",
                column: "WarehouseId",
                principalTable: "Warehouses",
                principalColumn: "WarehouseId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BOMMain_PrdUnits_PrdUnitId",
                table: "BOMMain");

            migrationBuilder.DropForeignKey(
                name: "FK_BOMSub_Warehouses_WarehouseId",
                table: "BOMSub");

            migrationBuilder.DropIndex(
                name: "IX_BOMSub_WarehouseId",
                table: "BOMSub");

            migrationBuilder.DropIndex(
                name: "IX_BOMMain_PrdUnitId",
                table: "BOMMain");

            migrationBuilder.DropColumn(
                name: "WarehouseId",
                table: "BOMSub");

            migrationBuilder.DropColumn(
                name: "PrdUnitId",
                table: "BOMMain");
        }
    }
}
