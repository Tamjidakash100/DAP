using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class fa0000999988 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Acc_ChartOfAccountAccId",
                table: "fA_Masters",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_fA_Masters_Acc_ChartOfAccountAccId",
                table: "fA_Masters",
                column: "Acc_ChartOfAccountAccId");

            migrationBuilder.AddForeignKey(
                name: "FK_fA_Masters_Acc_ChartOfAccounts_Acc_ChartOfAccountAccId",
                table: "fA_Masters",
                column: "Acc_ChartOfAccountAccId",
                principalTable: "Acc_ChartOfAccounts",
                principalColumn: "AccId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_fA_Masters_Acc_ChartOfAccounts_Acc_ChartOfAccountAccId",
                table: "fA_Masters");

            migrationBuilder.DropIndex(
                name: "IX_fA_Masters_Acc_ChartOfAccountAccId",
                table: "fA_Masters");

            migrationBuilder.DropColumn(
                name: "Acc_ChartOfAccountAccId",
                table: "fA_Masters");
        }
    }
}
