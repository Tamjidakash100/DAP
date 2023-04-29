using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class costallonullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CostAllocation_Distribute_CostAllocation_Details_CostAlloSubId",
                table: "CostAllocation_Distribute");

            migrationBuilder.DropForeignKey(
                name: "FK_CostAllocation_Distribute_Acc_ChartOfAccounts_Distribute_AccId",
                table: "CostAllocation_Distribute");

            migrationBuilder.AlterColumn<int>(
                name: "Distribute_AccId",
                table: "CostAllocation_Distribute",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Details_AccId",
                table: "CostAllocation_Distribute",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CostAlloSubId",
                table: "CostAllocation_Distribute",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_CostAllocation_Distribute_CostAllocation_Details_CostAlloSubId",
                table: "CostAllocation_Distribute",
                column: "CostAlloSubId",
                principalTable: "CostAllocation_Details",
                principalColumn: "CostAlloSubId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CostAllocation_Distribute_Acc_ChartOfAccounts_Distribute_AccId",
                table: "CostAllocation_Distribute",
                column: "Distribute_AccId",
                principalTable: "Acc_ChartOfAccounts",
                principalColumn: "AccId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CostAllocation_Distribute_CostAllocation_Details_CostAlloSubId",
                table: "CostAllocation_Distribute");

            migrationBuilder.DropForeignKey(
                name: "FK_CostAllocation_Distribute_Acc_ChartOfAccounts_Distribute_AccId",
                table: "CostAllocation_Distribute");

            migrationBuilder.AlterColumn<int>(
                name: "Distribute_AccId",
                table: "CostAllocation_Distribute",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Details_AccId",
                table: "CostAllocation_Distribute",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CostAlloSubId",
                table: "CostAllocation_Distribute",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CostAllocation_Distribute_CostAllocation_Details_CostAlloSubId",
                table: "CostAllocation_Distribute",
                column: "CostAlloSubId",
                principalTable: "CostAllocation_Details",
                principalColumn: "CostAlloSubId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CostAllocation_Distribute_Acc_ChartOfAccounts_Distribute_AccId",
                table: "CostAllocation_Distribute",
                column: "Distribute_AccId",
                principalTable: "Acc_ChartOfAccounts",
                principalColumn: "AccId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
