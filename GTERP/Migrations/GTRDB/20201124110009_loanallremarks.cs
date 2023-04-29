using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class loanallremarks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Remarks",
                table: "HR_Loan_Welfare",
                maxLength: 300,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Remarks",
                table: "HR_Loan_PF",
                maxLength: 300,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Remarks",
                table: "HR_Loan_Other",
                maxLength: 300,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Remarks",
                table: "HR_Loan_MotorCycle",
                maxLength: 300,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Remarks",
                table: "HR_Loan_HouseBuilding",
                maxLength: 300,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Remarks",
                table: "HR_Loan_Welfare");

            migrationBuilder.DropColumn(
                name: "Remarks",
                table: "HR_Loan_PF");

            migrationBuilder.DropColumn(
                name: "Remarks",
                table: "HR_Loan_Other");

            migrationBuilder.DropColumn(
                name: "Remarks",
                table: "HR_Loan_MotorCycle");

            migrationBuilder.DropColumn(
                name: "Remarks",
                table: "HR_Loan_HouseBuilding");
        }
    }
}
