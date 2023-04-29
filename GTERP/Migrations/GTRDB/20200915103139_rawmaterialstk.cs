using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class rawmaterialstk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RawMaterialStock",
                columns: table => new
                {
                    StockId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WarehouseId = table.Column<int>(nullable: true),
                    ProductId = table.Column<int>(nullable: true),
                    FiscalYearId = table.Column<int>(nullable: false),
                    FiscalMonthId = table.Column<int>(nullable: true),
                    ReceiveQty = table.Column<float>(nullable: false),
                    StockQty = table.Column<float>(nullable: false),
                    SendQty = table.Column<float>(nullable: false),
                    DtInput = table.Column<DateTime>(nullable: false),
                    Remarks = table.Column<string>(maxLength: 300, nullable: true),
                    AddedbyUserId = table.Column<string>(maxLength: 128, nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    UpdatedbyUserId = table.Column<string>(maxLength: 128, nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: true),
                    ComId = table.Column<string>(maxLength: 128, nullable: true),
                    UserId = table.Column<string>(maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RawMaterialStock", x => x.StockId);
                    table.ForeignKey(
                        name: "FK_RawMaterialStock_Acc_FiscalMonths_FiscalMonthId",
                        column: x => x.FiscalMonthId,
                        principalTable: "Acc_FiscalMonths",
                        principalColumn: "FiscalMonthId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RawMaterialStock_Acc_FiscalYears_FiscalYearId",
                        column: x => x.FiscalYearId,
                        principalTable: "Acc_FiscalYears",
                        principalColumn: "FiscalYearId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RawMaterialStock_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RawMaterialStock_Warehouses_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "WarehouseId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RawMaterialStock_FiscalMonthId",
                table: "RawMaterialStock",
                column: "FiscalMonthId");

            migrationBuilder.CreateIndex(
                name: "IX_RawMaterialStock_FiscalYearId",
                table: "RawMaterialStock",
                column: "FiscalYearId");

            migrationBuilder.CreateIndex(
                name: "IX_RawMaterialStock_ProductId",
                table: "RawMaterialStock",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_RawMaterialStock_WarehouseId",
                table: "RawMaterialStock",
                column: "WarehouseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RawMaterialStock");
        }
    }
}
