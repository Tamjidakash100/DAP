using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class allfiscalyear : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FiscalMonthId",
                table: "StoreRequisitionMain",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FiscalYearId",
                table: "StoreRequisitionMain",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FiscalMonthId",
                table: "PurchaseOrderMain",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SLno",
                table: "MenuPermissionDetails",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "isDefault",
                table: "MenuPermissionDetails",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "FiscalMonthId",
                table: "IssueMain",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FiscalYearId",
                table: "IssueMain",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FiscalMonthId",
                table: "GoodsReceiveMain",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FiscalYearId",
                table: "GoodsReceiveMain",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FYNameBangla",
                table: "Acc_FiscalYears",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "QtrNameBangla",
                table: "Acc_FiscalQtrs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MonthNameBangla",
                table: "Acc_FiscalMonths",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HyearNameBangla",
                table: "Acc_FiscalHalfYears",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StoreRequisitionMain_FiscalMonthId",
                table: "StoreRequisitionMain",
                column: "FiscalMonthId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreRequisitionMain_FiscalYearId",
                table: "StoreRequisitionMain",
                column: "FiscalYearId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderMain_FiscalMonthId",
                table: "PurchaseOrderMain",
                column: "FiscalMonthId");

            migrationBuilder.CreateIndex(
                name: "IX_IssueMain_FiscalMonthId",
                table: "IssueMain",
                column: "FiscalMonthId");

            migrationBuilder.CreateIndex(
                name: "IX_IssueMain_FiscalYearId",
                table: "IssueMain",
                column: "FiscalYearId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsReceiveMain_FiscalMonthId",
                table: "GoodsReceiveMain",
                column: "FiscalMonthId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsReceiveMain_FiscalYearId",
                table: "GoodsReceiveMain",
                column: "FiscalYearId");

            migrationBuilder.AddForeignKey(
                name: "FK_GoodsReceiveMain_Acc_FiscalMonths_FiscalMonthId",
                table: "GoodsReceiveMain",
                column: "FiscalMonthId",
                principalTable: "Acc_FiscalMonths",
                principalColumn: "FiscalMonthId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GoodsReceiveMain_Acc_FiscalYears_FiscalYearId",
                table: "GoodsReceiveMain",
                column: "FiscalYearId",
                principalTable: "Acc_FiscalYears",
                principalColumn: "FiscalYearId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_IssueMain_Acc_FiscalMonths_FiscalMonthId",
                table: "IssueMain",
                column: "FiscalMonthId",
                principalTable: "Acc_FiscalMonths",
                principalColumn: "FiscalMonthId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_IssueMain_Acc_FiscalYears_FiscalYearId",
                table: "IssueMain",
                column: "FiscalYearId",
                principalTable: "Acc_FiscalYears",
                principalColumn: "FiscalYearId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseOrderMain_Acc_FiscalMonths_FiscalMonthId",
                table: "PurchaseOrderMain",
                column: "FiscalMonthId",
                principalTable: "Acc_FiscalMonths",
                principalColumn: "FiscalMonthId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StoreRequisitionMain_Acc_FiscalMonths_FiscalMonthId",
                table: "StoreRequisitionMain",
                column: "FiscalMonthId",
                principalTable: "Acc_FiscalMonths",
                principalColumn: "FiscalMonthId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StoreRequisitionMain_Acc_FiscalYears_FiscalYearId",
                table: "StoreRequisitionMain",
                column: "FiscalYearId",
                principalTable: "Acc_FiscalYears",
                principalColumn: "FiscalYearId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GoodsReceiveMain_Acc_FiscalMonths_FiscalMonthId",
                table: "GoodsReceiveMain");

            migrationBuilder.DropForeignKey(
                name: "FK_GoodsReceiveMain_Acc_FiscalYears_FiscalYearId",
                table: "GoodsReceiveMain");

            migrationBuilder.DropForeignKey(
                name: "FK_IssueMain_Acc_FiscalMonths_FiscalMonthId",
                table: "IssueMain");

            migrationBuilder.DropForeignKey(
                name: "FK_IssueMain_Acc_FiscalYears_FiscalYearId",
                table: "IssueMain");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseOrderMain_Acc_FiscalMonths_FiscalMonthId",
                table: "PurchaseOrderMain");

            migrationBuilder.DropForeignKey(
                name: "FK_StoreRequisitionMain_Acc_FiscalMonths_FiscalMonthId",
                table: "StoreRequisitionMain");

            migrationBuilder.DropForeignKey(
                name: "FK_StoreRequisitionMain_Acc_FiscalYears_FiscalYearId",
                table: "StoreRequisitionMain");

            migrationBuilder.DropIndex(
                name: "IX_StoreRequisitionMain_FiscalMonthId",
                table: "StoreRequisitionMain");

            migrationBuilder.DropIndex(
                name: "IX_StoreRequisitionMain_FiscalYearId",
                table: "StoreRequisitionMain");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseOrderMain_FiscalMonthId",
                table: "PurchaseOrderMain");

            migrationBuilder.DropIndex(
                name: "IX_IssueMain_FiscalMonthId",
                table: "IssueMain");

            migrationBuilder.DropIndex(
                name: "IX_IssueMain_FiscalYearId",
                table: "IssueMain");

            migrationBuilder.DropIndex(
                name: "IX_GoodsReceiveMain_FiscalMonthId",
                table: "GoodsReceiveMain");

            migrationBuilder.DropIndex(
                name: "IX_GoodsReceiveMain_FiscalYearId",
                table: "GoodsReceiveMain");

            migrationBuilder.DropColumn(
                name: "FiscalMonthId",
                table: "StoreRequisitionMain");

            migrationBuilder.DropColumn(
                name: "FiscalYearId",
                table: "StoreRequisitionMain");

            migrationBuilder.DropColumn(
                name: "FiscalMonthId",
                table: "PurchaseOrderMain");

            migrationBuilder.DropColumn(
                name: "SLno",
                table: "MenuPermissionDetails");

            migrationBuilder.DropColumn(
                name: "isDefault",
                table: "MenuPermissionDetails");

            migrationBuilder.DropColumn(
                name: "FiscalMonthId",
                table: "IssueMain");

            migrationBuilder.DropColumn(
                name: "FiscalYearId",
                table: "IssueMain");

            migrationBuilder.DropColumn(
                name: "FiscalMonthId",
                table: "GoodsReceiveMain");

            migrationBuilder.DropColumn(
                name: "FiscalYearId",
                table: "GoodsReceiveMain");

            migrationBuilder.DropColumn(
                name: "FYNameBangla",
                table: "Acc_FiscalYears");

            migrationBuilder.DropColumn(
                name: "QtrNameBangla",
                table: "Acc_FiscalQtrs");

            migrationBuilder.DropColumn(
                name: "MonthNameBangla",
                table: "Acc_FiscalMonths");

            migrationBuilder.DropColumn(
                name: "HyearNameBangla",
                table: "Acc_FiscalHalfYears");
        }
    }
}
