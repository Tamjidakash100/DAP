using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class monthlysalesproductionaccid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MonthlySalesProductions_Acc_ChartOfAccounts_AccId",
                table: "MonthlySalesProductions");

            migrationBuilder.AlterColumn<int>(
                name: "AccId",
                table: "MonthlySalesProductions",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MonthlySalesProductions_Acc_ChartOfAccounts_AccId",
                table: "MonthlySalesProductions",
                column: "AccId",
                principalTable: "Acc_ChartOfAccounts",
                principalColumn: "AccId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MonthlySalesProductions_Acc_ChartOfAccounts_AccId",
                table: "MonthlySalesProductions");

            migrationBuilder.AlterColumn<int>(
                name: "AccId",
                table: "MonthlySalesProductions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_MonthlySalesProductions_Acc_ChartOfAccounts_AccId",
                table: "MonthlySalesProductions",
                column: "AccId",
                principalTable: "Acc_ChartOfAccounts",
                principalColumn: "AccId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
