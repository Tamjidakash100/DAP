using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class trangroupidinrowlevel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VoucherTranGroupIdRow",
                table: "Acc_VoucherSubs",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Acc_VoucherSubs_VoucherTranGroupIdRow",
                table: "Acc_VoucherSubs",
                column: "VoucherTranGroupIdRow");

            migrationBuilder.AddForeignKey(
                name: "FK_Acc_VoucherSubs_VoucherTranGroups_VoucherTranGroupIdRow",
                table: "Acc_VoucherSubs",
                column: "VoucherTranGroupIdRow",
                principalTable: "VoucherTranGroups",
                principalColumn: "VoucherTranGroupId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Acc_VoucherSubs_VoucherTranGroups_VoucherTranGroupIdRow",
                table: "Acc_VoucherSubs");

            migrationBuilder.DropIndex(
                name: "IX_Acc_VoucherSubs_VoucherTranGroupIdRow",
                table: "Acc_VoucherSubs");

            migrationBuilder.DropColumn(
                name: "VoucherTranGroupIdRow",
                table: "Acc_VoucherSubs");
        }
    }
}
