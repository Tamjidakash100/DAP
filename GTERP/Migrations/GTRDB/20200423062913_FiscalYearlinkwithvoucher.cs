using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class FiscalYearlinkwithvoucher : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FiscalMonthId",
                table: "Acc_VoucherMains",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FiscalYearId",
                table: "Acc_VoucherMains",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Acc_VoucherMains_CountryId",
                table: "Acc_VoucherMains",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Acc_VoucherMains_CountryIdLocal",
                table: "Acc_VoucherMains",
                column: "CountryIdLocal");

            migrationBuilder.CreateIndex(
                name: "IX_Acc_VoucherMains_FiscalMonthId",
                table: "Acc_VoucherMains",
                column: "FiscalMonthId");

            migrationBuilder.CreateIndex(
                name: "IX_Acc_VoucherMains_FiscalYearId",
                table: "Acc_VoucherMains",
                column: "FiscalYearId");

            migrationBuilder.AddForeignKey(
                name: "FK_Acc_VoucherMains_Countries_CountryId",
                table: "Acc_VoucherMains",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "CountryId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Acc_VoucherMains_Countries_CountryIdLocal",
                table: "Acc_VoucherMains",
                column: "CountryIdLocal",
                principalTable: "Countries",
                principalColumn: "CountryId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Acc_VoucherMains_Acc_FiscalMonths_FiscalMonthId",
                table: "Acc_VoucherMains",
                column: "FiscalMonthId",
                principalTable: "Acc_FiscalMonths",
                principalColumn: "FiscalMonthId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Acc_VoucherMains_Acc_FiscalYears_FiscalYearId",
                table: "Acc_VoucherMains",
                column: "FiscalYearId",
                principalTable: "Acc_FiscalYears",
                principalColumn: "FiscalYearId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Acc_VoucherMains_Countries_CountryId",
                table: "Acc_VoucherMains");

            migrationBuilder.DropForeignKey(
                name: "FK_Acc_VoucherMains_Countries_CountryIdLocal",
                table: "Acc_VoucherMains");

            migrationBuilder.DropForeignKey(
                name: "FK_Acc_VoucherMains_Acc_FiscalMonths_FiscalMonthId",
                table: "Acc_VoucherMains");

            migrationBuilder.DropForeignKey(
                name: "FK_Acc_VoucherMains_Acc_FiscalYears_FiscalYearId",
                table: "Acc_VoucherMains");

            migrationBuilder.DropIndex(
                name: "IX_Acc_VoucherMains_CountryId",
                table: "Acc_VoucherMains");

            migrationBuilder.DropIndex(
                name: "IX_Acc_VoucherMains_CountryIdLocal",
                table: "Acc_VoucherMains");

            migrationBuilder.DropIndex(
                name: "IX_Acc_VoucherMains_FiscalMonthId",
                table: "Acc_VoucherMains");

            migrationBuilder.DropIndex(
                name: "IX_Acc_VoucherMains_FiscalYearId",
                table: "Acc_VoucherMains");

            migrationBuilder.DropColumn(
                name: "FiscalMonthId",
                table: "Acc_VoucherMains");

            migrationBuilder.DropColumn(
                name: "FiscalYearId",
                table: "Acc_VoucherMains");
        }
    }
}
