using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class paymentportion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "PaymentPortionTaka",
                table: "Acc_GovtSchedule_JapanLoans",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "PaymentPortionYen",
                table: "Acc_GovtSchedule_JapanLoans",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaymentPortionTaka",
                table: "Acc_GovtSchedule_JapanLoans");

            migrationBuilder.DropColumn(
                name: "PaymentPortionYen",
                table: "Acc_GovtSchedule_JapanLoans");
        }
    }
}
