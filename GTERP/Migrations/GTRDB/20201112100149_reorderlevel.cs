using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class reorderlevel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ReorderLevel",
                columns: table => new
                {
                    ReorderLevelId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WarehouseId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    Quantity = table.Column<float>(nullable: false),
                    Remarks = table.Column<string>(maxLength: 100, nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    ComId = table.Column<string>(maxLength: 80, nullable: true),
                    UserId = table.Column<string>(maxLength: 80, nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    UpdateByUserId = table.Column<string>(maxLength: 80, nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReorderLevel", x => x.ReorderLevelId);
                    table.ForeignKey(
                        name: "FK_ReorderLevel_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReorderLevel_Warehouses_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "WarehouseId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReorderLevel_ProductId",
                table: "ReorderLevel",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ReorderLevel_WarehouseId",
                table: "ReorderLevel",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_ReorderLevel_ComId_ProductId_WarehouseId",
                table: "ReorderLevel",
                columns: new[] { "ComId", "ProductId", "WarehouseId" },
                unique: true,
                filter: "[ComId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReorderLevel");
        }
    }
}
