using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class ProductPrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "GoodsReceiveQty",
                table: "Inventory",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "IssueQty",
                table: "Inventory",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "ProductPrie",
                columns: table => new
                {
                    ProductPrieId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(nullable: false),
                    PriceDate = table.Column<DateTime>(nullable: true),
                    cPrice = table.Column<decimal>(nullable: false),
                    sPrice = table.Column<decimal>(nullable: false),
                    RowNo = table.Column<int>(nullable: false),
                    SourceId = table.Column<int>(nullable: true),
                    Source = table.Column<string>(nullable: true),
                    comid = table.Column<string>(maxLength: 128, nullable: false),
                    userid = table.Column<string>(maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductPrie", x => x.ProductPrieId);
                    table.ForeignKey(
                        name: "FK_ProductPrie_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductPrie_ProductId",
                table: "ProductPrie",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductPrie");

            migrationBuilder.DropColumn(
                name: "GoodsReceiveQty",
                table: "Inventory");

            migrationBuilder.DropColumn(
                name: "IssueQty",
                table: "Inventory");
        }
    }
}
