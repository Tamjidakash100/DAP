using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class Percentage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_fA_Masters_Acc_ChartOfAccounts_AccId_AccumulateDepreciation",
                table: "fA_Masters");

            migrationBuilder.DropIndex(
                name: "IX_fA_Masters_AccId_AccumulateDepreciation",
                table: "fA_Masters");

            migrationBuilder.DropColumn(
                name: "AccId_AccumulateDepreciation",
                table: "fA_Masters");

            migrationBuilder.DropColumn(
                name: "Parcentage",
                table: "fA_Masters");

            migrationBuilder.AddColumn<int>(
                name: "AccId_AccumulatedDepreciation",
                table: "fA_Masters",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Percentage",
                table: "fA_Masters",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_fA_Masters_AccId_AccumulatedDepreciation",
                table: "fA_Masters",
                column: "AccId_AccumulatedDepreciation");

            migrationBuilder.AddForeignKey(
                name: "FK_fA_Masters_Acc_ChartOfAccounts_AccId_AccumulatedDepreciation",
                table: "fA_Masters",
                column: "AccId_AccumulatedDepreciation",
                principalTable: "Acc_ChartOfAccounts",
                principalColumn: "AccId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_fA_Masters_Acc_ChartOfAccounts_AccId_AccumulatedDepreciation",
                table: "fA_Masters");

            migrationBuilder.DropIndex(
                name: "IX_fA_Masters_AccId_AccumulatedDepreciation",
                table: "fA_Masters");

            migrationBuilder.DropColumn(
                name: "AccId_AccumulatedDepreciation",
                table: "fA_Masters");

            migrationBuilder.DropColumn(
                name: "Percentage",
                table: "fA_Masters");

            migrationBuilder.AddColumn<int>(
                name: "AccId_AccumulateDepreciation",
                table: "fA_Masters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Parcentage",
                table: "fA_Masters",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_fA_Masters_AccId_AccumulateDepreciation",
                table: "fA_Masters",
                column: "AccId_AccumulateDepreciation");

            migrationBuilder.AddForeignKey(
                name: "FK_fA_Masters_Acc_ChartOfAccounts_AccId_AccumulateDepreciation",
                table: "fA_Masters",
                column: "AccId_AccumulateDepreciation",
                principalTable: "Acc_ChartOfAccounts",
                principalColumn: "AccId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
