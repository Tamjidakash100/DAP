using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class uniquekey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_IssueMain_ComId_IssueNo",
                table: "IssueMain");

            migrationBuilder.CreateIndex(
                name: "IX_IssueMain_ComId_IssueNo_FiscalYearId",
                table: "IssueMain",
                columns: new[] { "ComId", "IssueNo", "FiscalYearId" },
                unique: true,
                filter: "[ComId] IS NOT NULL AND [FiscalYearId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_IssueMain_ComId_IssueNo_FiscalYearId",
                table: "IssueMain");

            migrationBuilder.CreateIndex(
                name: "IX_IssueMain_ComId_IssueNo",
                table: "IssueMain",
                columns: new[] { "ComId", "IssueNo" },
                unique: true,
                filter: "[ComId] IS NOT NULL");
        }
    }
}
