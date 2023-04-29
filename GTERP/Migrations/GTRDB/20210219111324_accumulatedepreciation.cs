using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class accumulatedepreciation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AccumulatedDepId",
                table: "Acc_ChartOfAccounts",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Acc_ChartOfAccounts_AccumulatedDepId",
                table: "Acc_ChartOfAccounts",
                column: "AccumulatedDepId");

            migrationBuilder.AddForeignKey(
                name: "FK_Acc_ChartOfAccounts_Acc_ChartOfAccounts_AccumulatedDepId",
                table: "Acc_ChartOfAccounts",
                column: "AccumulatedDepId",
                principalTable: "Acc_ChartOfAccounts",
                principalColumn: "AccId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Acc_ChartOfAccounts_Acc_ChartOfAccounts_AccumulatedDepId",
                table: "Acc_ChartOfAccounts");

            migrationBuilder.DropIndex(
                name: "IX_Acc_ChartOfAccounts_AccumulatedDepId",
                table: "Acc_ChartOfAccounts");

            migrationBuilder.DropColumn(
                name: "AccumulatedDepId",
                table: "Acc_ChartOfAccounts");
        }
    }
}
