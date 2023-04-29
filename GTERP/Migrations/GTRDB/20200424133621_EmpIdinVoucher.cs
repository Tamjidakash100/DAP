using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class EmpIdinVoucher : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmpId",
                table: "Acc_VoucherSubs",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Acc_VoucherSubs_EmpId",
                table: "Acc_VoucherSubs",
                column: "EmpId");

            migrationBuilder.AddForeignKey(
                name: "FK_Acc_VoucherSubs_HR_Emp_Info_EmpId",
                table: "Acc_VoucherSubs",
                column: "EmpId",
                principalTable: "HR_Emp_Info",
                principalColumn: "EmpId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Acc_VoucherSubs_HR_Emp_Info_EmpId",
                table: "Acc_VoucherSubs");

            migrationBuilder.DropIndex(
                name: "IX_Acc_VoucherSubs_EmpId",
                table: "Acc_VoucherSubs");

            migrationBuilder.DropColumn(
                name: "EmpId",
                table: "Acc_VoucherSubs");
        }
    }
}
