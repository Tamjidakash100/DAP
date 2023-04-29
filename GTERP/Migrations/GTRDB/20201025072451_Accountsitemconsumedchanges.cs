using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class Accountsitemconsumedchanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "isItemInventory",
                table: "Acc_ChartOfAccounts",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<bool>(
                name: "isItemConsumed",
                table: "Acc_ChartOfAccounts",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "isItemInventory",
                table: "Acc_ChartOfAccounts",
                type: "int",
                nullable: false,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<int>(
                name: "isItemConsumed",
                table: "Acc_ChartOfAccounts",
                type: "int",
                nullable: false,
                oldClrType: typeof(bool));
        }
    }
}
