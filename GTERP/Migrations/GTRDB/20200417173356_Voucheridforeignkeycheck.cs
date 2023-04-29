using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class Voucheridforeignkeycheck : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Acc_VoucherSubs_Acc_ChartOfAccounts_Acc_ChartOfAccountAccId",
                table: "Acc_VoucherSubs");

            migrationBuilder.DropForeignKey(
                name: "FK_Acc_VoucherSubs_Acc_VoucherMains_Acc_VoucherMainVoucherId",
                table: "Acc_VoucherSubs");

            migrationBuilder.DropIndex(
                name: "IX_Acc_VoucherSubs_Acc_ChartOfAccountAccId",
                table: "Acc_VoucherSubs");

            migrationBuilder.DropIndex(
                name: "IX_Acc_VoucherSubs_Acc_VoucherMainVoucherId",
                table: "Acc_VoucherSubs");

            migrationBuilder.DropColumn(
                name: "Acc_ChartOfAccountAccId",
                table: "Acc_VoucherSubs");

            migrationBuilder.DropColumn(
                name: "Acc_VoucherMainVoucherId",
                table: "Acc_VoucherSubs");

            migrationBuilder.CreateIndex(
                name: "IX_Acc_VoucherSubs_AccId",
                table: "Acc_VoucherSubs",
                column: "AccId");

            migrationBuilder.CreateIndex(
                name: "IX_Acc_VoucherSubs_VoucherId",
                table: "Acc_VoucherSubs",
                column: "VoucherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Acc_VoucherSubs_Acc_ChartOfAccounts_AccId",
                table: "Acc_VoucherSubs",
                column: "AccId",
                principalTable: "Acc_ChartOfAccounts",
                principalColumn: "AccId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Acc_VoucherSubs_Acc_VoucherMains_VoucherId",
                table: "Acc_VoucherSubs",
                column: "VoucherId",
                principalTable: "Acc_VoucherMains",
                principalColumn: "VoucherId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Acc_VoucherSubs_Acc_ChartOfAccounts_AccId",
                table: "Acc_VoucherSubs");

            migrationBuilder.DropForeignKey(
                name: "FK_Acc_VoucherSubs_Acc_VoucherMains_VoucherId",
                table: "Acc_VoucherSubs");

            migrationBuilder.DropIndex(
                name: "IX_Acc_VoucherSubs_AccId",
                table: "Acc_VoucherSubs");

            migrationBuilder.DropIndex(
                name: "IX_Acc_VoucherSubs_VoucherId",
                table: "Acc_VoucherSubs");

            migrationBuilder.AddColumn<int>(
                name: "Acc_ChartOfAccountAccId",
                table: "Acc_VoucherSubs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Acc_VoucherMainVoucherId",
                table: "Acc_VoucherSubs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Acc_VoucherSubs_Acc_ChartOfAccountAccId",
                table: "Acc_VoucherSubs",
                column: "Acc_ChartOfAccountAccId");

            migrationBuilder.CreateIndex(
                name: "IX_Acc_VoucherSubs_Acc_VoucherMainVoucherId",
                table: "Acc_VoucherSubs",
                column: "Acc_VoucherMainVoucherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Acc_VoucherSubs_Acc_ChartOfAccounts_Acc_ChartOfAccountAccId",
                table: "Acc_VoucherSubs",
                column: "Acc_ChartOfAccountAccId",
                principalTable: "Acc_ChartOfAccounts",
                principalColumn: "AccId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Acc_VoucherSubs_Acc_VoucherMains_Acc_VoucherMainVoucherId",
                table: "Acc_VoucherSubs",
                column: "Acc_VoucherMainVoucherId",
                principalTable: "Acc_VoucherMains",
                principalColumn: "VoucherId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
