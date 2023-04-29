using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class nullabledepreciationid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_fA_Masters_Acc_ChartOfAccounts_AccId_AccumulatedDepreciation",
                table: "fA_Masters");

            migrationBuilder.DropForeignKey(
                name: "FK_fA_Masters_Acc_ChartOfAccounts_AccId_DepreciationExpense",
                table: "fA_Masters");

            migrationBuilder.AlterColumn<int>(
                name: "AccId_DepreciationExpense",
                table: "fA_Masters",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AccId_AccumulatedDepreciation",
                table: "fA_Masters",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_fA_Masters_Acc_ChartOfAccounts_AccId_AccumulatedDepreciation",
                table: "fA_Masters",
                column: "AccId_AccumulatedDepreciation",
                principalTable: "Acc_ChartOfAccounts",
                principalColumn: "AccId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_fA_Masters_Acc_ChartOfAccounts_AccId_DepreciationExpense",
                table: "fA_Masters",
                column: "AccId_DepreciationExpense",
                principalTable: "Acc_ChartOfAccounts",
                principalColumn: "AccId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_fA_Masters_Acc_ChartOfAccounts_AccId_AccumulatedDepreciation",
                table: "fA_Masters");

            migrationBuilder.DropForeignKey(
                name: "FK_fA_Masters_Acc_ChartOfAccounts_AccId_DepreciationExpense",
                table: "fA_Masters");

            migrationBuilder.AlterColumn<int>(
                name: "AccId_DepreciationExpense",
                table: "fA_Masters",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AccId_AccumulatedDepreciation",
                table: "fA_Masters",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_fA_Masters_Acc_ChartOfAccounts_AccId_AccumulatedDepreciation",
                table: "fA_Masters",
                column: "AccId_AccumulatedDepreciation",
                principalTable: "Acc_ChartOfAccounts",
                principalColumn: "AccId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_fA_Masters_Acc_ChartOfAccounts_AccId_DepreciationExpense",
                table: "fA_Masters",
                column: "AccId_DepreciationExpense",
                principalTable: "Acc_ChartOfAccounts",
                principalColumn: "AccId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
