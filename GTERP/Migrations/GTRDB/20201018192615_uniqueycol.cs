using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class uniqueycol : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_MonthlySalesProductions_ComId_FiscalYearId_FiscalMonthId",
                table: "MonthlySalesProductions",
                columns: new[] { "ComId", "FiscalYearId", "FiscalMonthId" },
                unique: true,
                filter: "[ComId] IS NOT NULL AND [FiscalMonthId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_MonthlySalesProductions_ComId_FiscalYearId_FiscalMonthId",
                table: "MonthlySalesProductions");
        }
    }
}
