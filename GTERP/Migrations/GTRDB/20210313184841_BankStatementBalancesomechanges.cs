using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class BankStatementBalancesomechanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Acc_BankStatementBalances");

            migrationBuilder.AddColumn<double>(
                name: "AddAmount",
                table: "Acc_BankStatementBalances",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "BankStatementAmount",
                table: "Acc_BankStatementBalances",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "CashBookStatementAmount",
                table: "Acc_BankStatementBalances",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "LessAmount",
                table: "Acc_BankStatementBalances",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddAmount",
                table: "Acc_BankStatementBalances");

            migrationBuilder.DropColumn(
                name: "BankStatementAmount",
                table: "Acc_BankStatementBalances");

            migrationBuilder.DropColumn(
                name: "CashBookStatementAmount",
                table: "Acc_BankStatementBalances");

            migrationBuilder.DropColumn(
                name: "LessAmount",
                table: "Acc_BankStatementBalances");

            migrationBuilder.AddColumn<double>(
                name: "Amount",
                table: "Acc_BankStatementBalances",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
