using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class depreciationrate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DepreciationRate",
                table: "Acc_ChartOfAccounts",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Remarks",
                table: "Acc_ChartOfAccounts",
                maxLength: 100,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DepreciationRate",
                table: "Acc_ChartOfAccounts");

            migrationBuilder.DropColumn(
                name: "Remarks",
                table: "Acc_ChartOfAccounts");
        }
    }
}
