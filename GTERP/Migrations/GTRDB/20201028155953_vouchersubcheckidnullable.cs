using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class vouchersubcheckidnullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Acc_VoucherSubChecnos_Acc_VoucherSubs_VoucherSubId",
                table: "Acc_VoucherSubChecnos");

            migrationBuilder.AlterColumn<int>(
                name: "VoucherSubId",
                table: "Acc_VoucherSubChecnos",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "VoucherId",
                table: "Acc_VoucherSubChecnos",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "SRowNo",
                table: "Acc_VoucherSubChecnos",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Acc_VoucherSubChecnos_Acc_VoucherSubs_VoucherSubId",
                table: "Acc_VoucherSubChecnos",
                column: "VoucherSubId",
                principalTable: "Acc_VoucherSubs",
                principalColumn: "VoucherSubId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Acc_VoucherSubChecnos_Acc_VoucherSubs_VoucherSubId",
                table: "Acc_VoucherSubChecnos");

            migrationBuilder.AlterColumn<int>(
                name: "VoucherSubId",
                table: "Acc_VoucherSubChecnos",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "VoucherId",
                table: "Acc_VoucherSubChecnos",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SRowNo",
                table: "Acc_VoucherSubChecnos",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Acc_VoucherSubChecnos_Acc_VoucherSubs_VoucherSubId",
                table: "Acc_VoucherSubChecnos",
                column: "VoucherSubId",
                principalTable: "Acc_VoucherSubs",
                principalColumn: "VoucherSubId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
