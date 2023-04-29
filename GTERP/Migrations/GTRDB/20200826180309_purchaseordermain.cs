using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class purchaseordermain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Department",
                table: "PurchaseOrderMain");

            migrationBuilder.AddColumn<int>(
                name: "DeptId",
                table: "PurchaseOrderMain",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderMain_DeptId",
                table: "PurchaseOrderMain",
                column: "DeptId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseOrderMain_Cat_Department_DeptId",
                table: "PurchaseOrderMain",
                column: "DeptId",
                principalTable: "Cat_Department",
                principalColumn: "DeptId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseOrderMain_Cat_Department_DeptId",
                table: "PurchaseOrderMain");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseOrderMain_DeptId",
                table: "PurchaseOrderMain");

            migrationBuilder.DropColumn(
                name: "DeptId",
                table: "PurchaseOrderMain");

            migrationBuilder.AddColumn<string>(
                name: "Department",
                table: "PurchaseOrderMain",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
