using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class datetimeupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "dtChk",
                table: "Acc_VoucherSubChecnos",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Acc_VoucherSubChecnos_AccId",
                table: "Acc_VoucherSubChecnos",
                column: "AccId");

            migrationBuilder.AddForeignKey(
                name: "FK_Acc_VoucherSubChecnos_Acc_ChartOfAccounts_AccId",
                table: "Acc_VoucherSubChecnos",
                column: "AccId",
                principalTable: "Acc_ChartOfAccounts",
                principalColumn: "AccId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Acc_VoucherSubChecnos_Acc_ChartOfAccounts_AccId",
                table: "Acc_VoucherSubChecnos");

            migrationBuilder.DropIndex(
                name: "IX_Acc_VoucherSubChecnos_AccId",
                table: "Acc_VoucherSubChecnos");

            migrationBuilder.AlterColumn<string>(
                name: "dtChk",
                table: "Acc_VoucherSubChecnos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldNullable: true);
        }
    }
}
