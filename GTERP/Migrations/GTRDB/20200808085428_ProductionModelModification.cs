using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class ProductionModelModification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Production_ItemDescs_ItemDescId",
                table: "Production");

            migrationBuilder.DropIndex(
                name: "IX_Production_ItemDescId",
                table: "Production");

            migrationBuilder.DropColumn(
                name: "ItemDescId",
                table: "Production");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Production",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Production_ProductId",
                table: "Production",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Production_Products_ProductId",
                table: "Production",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Production_Products_ProductId",
                table: "Production");

            migrationBuilder.DropIndex(
                name: "IX_Production_ProductId",
                table: "Production");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Production");

            migrationBuilder.AddColumn<int>(
                name: "ItemDescId",
                table: "Production",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Production_ItemDescId",
                table: "Production",
                column: "ItemDescId");

            migrationBuilder.AddForeignKey(
                name: "FK_Production_ItemDescs_ItemDescId",
                table: "Production",
                column: "ItemDescId",
                principalTable: "ItemDescs",
                principalColumn: "ItemDescId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
