using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class MoreChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IssueMain_Suppliers_SupplierId",
                table: "IssueMain");

            migrationBuilder.DropIndex(
                name: "IX_IssueMain_SupplierId",
                table: "IssueMain");

            migrationBuilder.DropColumn(
                name: "SupplierId",
                table: "IssueMain");

            migrationBuilder.AddColumn<float>(
                name: "Addition",
                table: "IssueMain",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Addition",
                table: "GoodsReceiveMain",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ManualSupplierName",
                table: "GoodsReceiveMain",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Addition",
                table: "IssueMain");

            migrationBuilder.DropColumn(
                name: "Addition",
                table: "GoodsReceiveMain");

            migrationBuilder.DropColumn(
                name: "ManualSupplierName",
                table: "GoodsReceiveMain");

            migrationBuilder.AddColumn<int>(
                name: "SupplierId",
                table: "IssueMain",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_IssueMain_SupplierId",
                table: "IssueMain",
                column: "SupplierId");

            migrationBuilder.AddForeignKey(
                name: "FK_IssueMain_Suppliers_SupplierId",
                table: "IssueMain",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "SupplierId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
