using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class costcalculatedaddwarehouseid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WarehouseId",
                table: "CostCalculated",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isSubStore",
                table: "CostCalculated",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_CostCalculated_WarehouseId",
                table: "CostCalculated",
                column: "WarehouseId");

            migrationBuilder.AddForeignKey(
                name: "FK_CostCalculated_Warehouses_WarehouseId",
                table: "CostCalculated",
                column: "WarehouseId",
                principalTable: "Warehouses",
                principalColumn: "WarehouseId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CostCalculated_Warehouses_WarehouseId",
                table: "CostCalculated");

            migrationBuilder.DropIndex(
                name: "IX_CostCalculated_WarehouseId",
                table: "CostCalculated");

            migrationBuilder.DropColumn(
                name: "WarehouseId",
                table: "CostCalculated");

            migrationBuilder.DropColumn(
                name: "isSubStore",
                table: "CostCalculated");
        }
    }
}
