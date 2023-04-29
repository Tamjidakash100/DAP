using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class ProductPriceChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductPrie_Products_ProductId",
                table: "ProductPrie");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductPrie",
                table: "ProductPrie");

            migrationBuilder.RenameTable(
                name: "ProductPrie",
                newName: "ProductPrice");

            migrationBuilder.RenameIndex(
                name: "IX_ProductPrie_ProductId",
                table: "ProductPrice",
                newName: "IX_ProductPrice_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductPrice",
                table: "ProductPrice",
                column: "ProductPrieId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductPrice_Products_ProductId",
                table: "ProductPrice",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductPrice_Products_ProductId",
                table: "ProductPrice");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductPrice",
                table: "ProductPrice");

            migrationBuilder.RenameTable(
                name: "ProductPrice",
                newName: "ProductPrie");

            migrationBuilder.RenameIndex(
                name: "IX_ProductPrice_ProductId",
                table: "ProductPrie",
                newName: "IX_ProductPrie_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductPrie",
                table: "ProductPrie",
                column: "ProductPrieId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductPrie_Products_ProductId",
                table: "ProductPrie",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
