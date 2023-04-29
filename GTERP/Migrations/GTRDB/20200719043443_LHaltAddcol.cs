using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class LHaltAddcol : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ReferenceNo",
                table: "HR_LvEncashment",
                maxLength: 40,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OtherLoanType",
                table: "HR_Loan_IncreaseInfo",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProposedManPower",
                table: "Cat_Designation",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReferenceNo",
                table: "HR_LvEncashment");

            migrationBuilder.DropColumn(
                name: "OtherLoanType",
                table: "HR_Loan_IncreaseInfo");

            migrationBuilder.DropColumn(
                name: "ProposedManPower",
                table: "Cat_Designation");
        }
    }
}
