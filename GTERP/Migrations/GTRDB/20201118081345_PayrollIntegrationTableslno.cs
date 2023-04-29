using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class PayrollIntegrationTableslno : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SLNo",
                table: "Cat_PayrollIntegrationSummary",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsCredit",
                table: "Cat_PayrollIntegration_Settings",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDebit",
                table: "Cat_PayrollIntegration_Settings",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "SLNo",
                table: "Cat_PayrollIntegration_Settings",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SLNo",
                table: "Cat_PayrollIntegrationSummary");

            migrationBuilder.DropColumn(
                name: "IsCredit",
                table: "Cat_PayrollIntegration_Settings");

            migrationBuilder.DropColumn(
                name: "IsDebit",
                table: "Cat_PayrollIntegration_Settings");

            migrationBuilder.DropColumn(
                name: "SLNo",
                table: "Cat_PayrollIntegration_Settings");
        }
    }
}
