using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class categorysubcategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateAdded",
                table: "Suppliers",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdated",
                table: "Suppliers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "userid",
                table: "Suppliers",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "useridUpdate",
                table: "Suppliers",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateAdded",
                table: "SubCategory",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdated",
                table: "SubCategory",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsInActive",
                table: "SubCategory",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "comid",
                table: "SubCategory",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "userid",
                table: "SubCategory",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "useridUpdate",
                table: "SubCategory",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProductName",
                table: "Products",
                maxLength: 300,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<int>(
                name: "AccIdConsumption",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AccIdInventory",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateAdded",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdated",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "MinimumOrderQty",
                table: "Products",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "ProductCode",
                table: "Products",
                maxLength: 15,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ReorderLevelOne",
                table: "Products",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "RetailerPrice",
                table: "Products",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "userid",
                table: "Products",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "useridUpdate",
                table: "Products",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateAdded",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdated",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "userid",
                table: "Customers",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "useridUpdate",
                table: "Customers",
                maxLength: 128,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Inventory",
                columns: table => new
                {
                    InventoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(nullable: false),
                    WareHouseId = table.Column<int>(nullable: false),
                    OpStock = table.Column<decimal>(nullable: false),
                    PurQty = table.Column<decimal>(nullable: false),
                    PurRetQty = table.Column<decimal>(nullable: false),
                    PurExcQty = table.Column<decimal>(nullable: false),
                    SalesQty = table.Column<decimal>(nullable: false),
                    SalesRetQty = table.Column<decimal>(nullable: false),
                    SalesExcQty = table.Column<decimal>(nullable: false),
                    ChallanQty = table.Column<decimal>(nullable: false),
                    EnStock = table.Column<decimal>(nullable: false),
                    CurrentStock = table.Column<decimal>(nullable: false),
                    comid = table.Column<int>(nullable: false),
                    userid = table.Column<string>(maxLength: 128, nullable: true),
                    useridUpdate = table.Column<string>(maxLength: 128, nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: true),
                    OpeningStockDate = table.Column<DateTime>(nullable: true),
                    Remarks = table.Column<string>(maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory", x => x.InventoryId);
                    table.ForeignKey(
                        name: "FK_Inventory_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inventory_Warehouses_WareHouseId",
                        column: x => x.WareHouseId,
                        principalTable: "Warehouses",
                        principalColumn: "WarehouseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_AccIdConsumption",
                table: "Products",
                column: "AccIdConsumption");

            migrationBuilder.CreateIndex(
                name: "IX_Products_AccIdInventory",
                table: "Products",
                column: "AccIdInventory");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_ProductId",
                table: "Inventory",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_WareHouseId",
                table: "Inventory",
                column: "WareHouseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Acc_ChartOfAccounts_AccIdConsumption",
                table: "Products",
                column: "AccIdConsumption",
                principalTable: "Acc_ChartOfAccounts",
                principalColumn: "AccId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Acc_ChartOfAccounts_AccIdInventory",
                table: "Products",
                column: "AccIdInventory",
                principalTable: "Acc_ChartOfAccounts",
                principalColumn: "AccId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Acc_ChartOfAccounts_AccIdConsumption",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Acc_ChartOfAccounts_AccIdInventory",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Inventory");

            migrationBuilder.DropIndex(
                name: "IX_Products_AccIdConsumption",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_AccIdInventory",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DateAdded",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "userid",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "useridUpdate",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "DateAdded",
                table: "SubCategory");

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "SubCategory");

            migrationBuilder.DropColumn(
                name: "IsInActive",
                table: "SubCategory");

            migrationBuilder.DropColumn(
                name: "comid",
                table: "SubCategory");

            migrationBuilder.DropColumn(
                name: "userid",
                table: "SubCategory");

            migrationBuilder.DropColumn(
                name: "useridUpdate",
                table: "SubCategory");

            migrationBuilder.DropColumn(
                name: "AccIdConsumption",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "AccIdInventory",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DateAdded",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "MinimumOrderQty",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductCode",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ReorderLevelOne",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "RetailerPrice",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "userid",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "useridUpdate",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DateAdded",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "userid",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "useridUpdate",
                table: "Customers");

            migrationBuilder.AlterColumn<string>(
                name: "ProductName",
                table: "Products",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 300);
        }
    }
}
