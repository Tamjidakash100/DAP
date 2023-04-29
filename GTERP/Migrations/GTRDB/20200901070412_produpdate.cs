using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class produpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FiscalMonthId",
                table: "Production",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FiscalYearId",
                table: "Production",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Production_FiscalMonthId",
                table: "Production",
                column: "FiscalMonthId");

            migrationBuilder.CreateIndex(
                name: "IX_Production_FiscalYearId",
                table: "Production",
                column: "FiscalYearId");

            migrationBuilder.AddForeignKey(
                name: "FK_Production_Acc_FiscalMonths_FiscalMonthId",
                table: "Production",
                column: "FiscalMonthId",
                principalTable: "Acc_FiscalMonths",
                principalColumn: "FiscalMonthId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Production_Acc_FiscalYears_FiscalYearId",
                table: "Production",
                column: "FiscalYearId",
                principalTable: "Acc_FiscalYears",
                principalColumn: "FiscalYearId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Production_Acc_FiscalMonths_FiscalMonthId",
                table: "Production");

            migrationBuilder.DropForeignKey(
                name: "FK_Production_Acc_FiscalYears_FiscalYearId",
                table: "Production");

            migrationBuilder.DropIndex(
                name: "IX_Production_FiscalMonthId",
                table: "Production");

            migrationBuilder.DropIndex(
                name: "IX_Production_FiscalYearId",
                table: "Production");

            migrationBuilder.DropColumn(
                name: "FiscalMonthId",
                table: "Production");

            migrationBuilder.DropColumn(
                name: "FiscalYearId",
                table: "Production");
        }
    }
}
