using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class instnoallloan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InstalmentNo",
                table: "HR_Loan_Data_Welfare",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InstalmentNo",
                table: "HR_Loan_Data_PF",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InstalmentNo",
                table: "HR_Loan_Data_Other",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InstalmentNo",
                table: "HR_Loan_Data_MotorCycle",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InstalmentNo",
                table: "HR_Loan_Data_HouseBuilding",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InstalmentNo",
                table: "HR_Loan_Data_Welfare");

            migrationBuilder.DropColumn(
                name: "InstalmentNo",
                table: "HR_Loan_Data_PF");

            migrationBuilder.DropColumn(
                name: "InstalmentNo",
                table: "HR_Loan_Data_Other");

            migrationBuilder.DropColumn(
                name: "InstalmentNo",
                table: "HR_Loan_Data_MotorCycle");

            migrationBuilder.DropColumn(
                name: "InstalmentNo",
                table: "HR_Loan_Data_HouseBuilding");
        }
    }
}
