using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class DebitCreditAccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreditAccId",
                table: "HR_Emp_PF_OPBal",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DebitAccId",
                table: "HR_Emp_PF_OPBal",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_PF_OPBal_CreditAccId",
                table: "HR_Emp_PF_OPBal",
                column: "CreditAccId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_PF_OPBal_DebitAccId",
                table: "HR_Emp_PF_OPBal",
                column: "DebitAccId");

            migrationBuilder.AddForeignKey(
                name: "FK_HR_Emp_PF_OPBal_PF_ChartOfAccounts_CreditAccId",
                table: "HR_Emp_PF_OPBal",
                column: "CreditAccId",
                principalTable: "PF_ChartOfAccounts",
                principalColumn: "AccId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HR_Emp_PF_OPBal_PF_ChartOfAccounts_DebitAccId",
                table: "HR_Emp_PF_OPBal",
                column: "DebitAccId",
                principalTable: "PF_ChartOfAccounts",
                principalColumn: "AccId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HR_Emp_PF_OPBal_PF_ChartOfAccounts_CreditAccId",
                table: "HR_Emp_PF_OPBal");

            migrationBuilder.DropForeignKey(
                name: "FK_HR_Emp_PF_OPBal_PF_ChartOfAccounts_DebitAccId",
                table: "HR_Emp_PF_OPBal");

            migrationBuilder.DropIndex(
                name: "IX_HR_Emp_PF_OPBal_CreditAccId",
                table: "HR_Emp_PF_OPBal");

            migrationBuilder.DropIndex(
                name: "IX_HR_Emp_PF_OPBal_DebitAccId",
                table: "HR_Emp_PF_OPBal");

            migrationBuilder.DropColumn(
                name: "CreditAccId",
                table: "HR_Emp_PF_OPBal");

            migrationBuilder.DropColumn(
                name: "DebitAccId",
                table: "HR_Emp_PF_OPBal");
        }
    }
}
