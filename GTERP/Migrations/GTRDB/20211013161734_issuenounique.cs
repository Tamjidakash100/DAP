using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class issuenounique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_StoreRequisitionMain_ComId_SRNo",
                table: "StoreRequisitionMain");

            migrationBuilder.AddColumn<int>(
                name: "AccId",
                table: "MonthlySalesProductions",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StoreRequisitionMain_ComId_FiscalYearId_SRNo",
                table: "StoreRequisitionMain",
                columns: new[] { "ComId", "FiscalYearId", "SRNo" },
                unique: true,
                filter: "[ComId] IS NOT NULL AND [FiscalYearId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_MonthlySalesProductions_AccId",
                table: "MonthlySalesProductions",
                column: "AccId");

            migrationBuilder.AddForeignKey(
                name: "FK_MonthlySalesProductions_Acc_ChartOfAccounts_AccId",
                table: "MonthlySalesProductions",
                column: "AccId",
                principalTable: "Acc_ChartOfAccounts",
                principalColumn: "AccId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MonthlySalesProductions_Acc_ChartOfAccounts_AccId",
                table: "MonthlySalesProductions");

            migrationBuilder.DropIndex(
                name: "IX_StoreRequisitionMain_ComId_FiscalYearId_SRNo",
                table: "StoreRequisitionMain");

            migrationBuilder.DropIndex(
                name: "IX_MonthlySalesProductions_AccId",
                table: "MonthlySalesProductions");

            migrationBuilder.DropColumn(
                name: "AccId",
                table: "MonthlySalesProductions");

            migrationBuilder.CreateIndex(
                name: "IX_StoreRequisitionMain_ComId_SRNo",
                table: "StoreRequisitionMain",
                columns: new[] { "ComId", "SRNo" },
                unique: true,
                filter: "[ComId] IS NOT NULL");
        }
    }
}
