using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class ProductMainGroupLinkwithProductFinal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductMainGroups_ProductGroupMainId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProductGroupMainId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductGroupMainId",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "ProductMainGroupId",
                table: "Products",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductMainGroupId",
                table: "Products",
                column: "ProductMainGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductMainGroups_ProductMainGroupId",
                table: "Products",
                column: "ProductMainGroupId",
                principalTable: "ProductMainGroups",
                principalColumn: "ProductMainGroupId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductMainGroups_ProductMainGroupId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProductMainGroupId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductMainGroupId",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "ProductGroupMainId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductGroupMainId",
                table: "Products",
                column: "ProductGroupMainId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductMainGroups_ProductGroupMainId",
                table: "Products",
                column: "ProductGroupMainId",
                principalTable: "ProductMainGroups",
                principalColumn: "ProductMainGroupId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
