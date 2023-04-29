using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class costcalculatedproductidnotnull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CostCalculated_Products_ProductId",
                table: "CostCalculated");

            migrationBuilder.DropForeignKey(
                name: "FK_CostCalculated_Warehouses_WarehouseId",
                table: "CostCalculated");

            migrationBuilder.AlterColumn<int>(
                name: "WarehouseId",
                table: "CostCalculated",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "CostCalculated",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CostCalculated_Products_ProductId",
                table: "CostCalculated",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Restrict);

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
                name: "FK_CostCalculated_Products_ProductId",
                table: "CostCalculated");

            migrationBuilder.DropForeignKey(
                name: "FK_CostCalculated_Warehouses_WarehouseId",
                table: "CostCalculated");

            migrationBuilder.AlterColumn<int>(
                name: "WarehouseId",
                table: "CostCalculated",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "CostCalculated",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_CostCalculated_Products_ProductId",
                table: "CostCalculated",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CostCalculated_Warehouses_WarehouseId",
                table: "CostCalculated",
                column: "WarehouseId",
                principalTable: "Warehouses",
                principalColumn: "WarehouseId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
