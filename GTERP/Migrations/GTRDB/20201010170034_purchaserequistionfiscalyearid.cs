using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class purchaserequistionfiscalyearid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SLno",
                table: "MenuPermissionDetails",
                newName: "SLNo");

            migrationBuilder.AddColumn<int>(
                name: "FiscalMonthId",
                table: "PurchaseRequisitionMain",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FiscalYearId",
                table: "PurchaseRequisitionMain",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseRequisitionMain_FiscalMonthId",
                table: "PurchaseRequisitionMain",
                column: "FiscalMonthId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseRequisitionMain_FiscalYearId",
                table: "PurchaseRequisitionMain",
                column: "FiscalYearId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseRequisitionMain_Acc_FiscalMonths_FiscalMonthId",
                table: "PurchaseRequisitionMain",
                column: "FiscalMonthId",
                principalTable: "Acc_FiscalMonths",
                principalColumn: "FiscalMonthId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseRequisitionMain_Acc_FiscalYears_FiscalYearId",
                table: "PurchaseRequisitionMain",
                column: "FiscalYearId",
                principalTable: "Acc_FiscalYears",
                principalColumn: "FiscalYearId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseRequisitionMain_Acc_FiscalMonths_FiscalMonthId",
                table: "PurchaseRequisitionMain");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseRequisitionMain_Acc_FiscalYears_FiscalYearId",
                table: "PurchaseRequisitionMain");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseRequisitionMain_FiscalMonthId",
                table: "PurchaseRequisitionMain");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseRequisitionMain_FiscalYearId",
                table: "PurchaseRequisitionMain");

            migrationBuilder.DropColumn(
                name: "FiscalMonthId",
                table: "PurchaseRequisitionMain");

            migrationBuilder.DropColumn(
                name: "FiscalYearId",
                table: "PurchaseRequisitionMain");

            migrationBuilder.RenameColumn(
                name: "SLNo",
                table: "MenuPermissionDetails",
                newName: "SLno");
        }
    }
}
