using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class issueuniqe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_IssueMain_ComId_IssueNo_FiscalYearId",
                table: "IssueMain");

            migrationBuilder.CreateIndex(
                name: "IX_IssueMain_IssueNo_FiscalYearId_ComId",
                table: "IssueMain",
                columns: new[] { "IssueNo", "FiscalYearId", "ComId" },
                unique: true,
                filter: "[FiscalYearId] IS NOT NULL AND [ComId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_IssueMain_IssueNo_FiscalYearId_ComId",
                table: "IssueMain");

            migrationBuilder.CreateIndex(
                name: "IX_IssueMain_ComId_IssueNo_FiscalYearId",
                table: "IssueMain",
                columns: new[] { "ComId", "IssueNo", "FiscalYearId" },
                unique: true,
                filter: "[ComId] IS NOT NULL AND [FiscalYearId] IS NOT NULL");
        }
    }
}
