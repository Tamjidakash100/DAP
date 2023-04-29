using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class purchaserequisitionsectid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SectId",
                table: "PurchaseRequisitionMain",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseRequisitionMain_SectId",
                table: "PurchaseRequisitionMain",
                column: "SectId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseRequisitionMain_Cat_Section_SectId",
                table: "PurchaseRequisitionMain",
                column: "SectId",
                principalTable: "Cat_Section",
                principalColumn: "SectId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseRequisitionMain_Cat_Section_SectId",
                table: "PurchaseRequisitionMain");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseRequisitionMain_SectId",
                table: "PurchaseRequisitionMain");

            migrationBuilder.DropColumn(
                name: "SectId",
                table: "PurchaseRequisitionMain");
        }
    }
}
