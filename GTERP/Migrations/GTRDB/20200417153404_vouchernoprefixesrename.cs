using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class vouchernoprefixesrename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VoucherNoPrefixes_Acc_VoucherTypes_vVoucherTypesVoucherTypeId",
                table: "VoucherNoPrefixes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VoucherNoPrefixes",
                table: "VoucherNoPrefixes");

            migrationBuilder.RenameTable(
                name: "VoucherNoPrefixes",
                newName: "Acc_VoucherNoPrefixes");

            migrationBuilder.RenameIndex(
                name: "IX_VoucherNoPrefixes_vVoucherTypesVoucherTypeId",
                table: "Acc_VoucherNoPrefixes",
                newName: "IX_Acc_VoucherNoPrefixes_vVoucherTypesVoucherTypeId");

            migrationBuilder.AlterColumn<string>(
                name: "comid",
                table: "UserTransactionLogs",
                maxLength: 128,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Acc_VoucherNoPrefixes",
                table: "Acc_VoucherNoPrefixes",
                column: "VoucherNoPrefixId");

            migrationBuilder.AddForeignKey(
                name: "FK_Acc_VoucherNoPrefixes_Acc_VoucherTypes_vVoucherTypesVoucherTypeId",
                table: "Acc_VoucherNoPrefixes",
                column: "vVoucherTypesVoucherTypeId",
                principalTable: "Acc_VoucherTypes",
                principalColumn: "VoucherTypeId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Acc_VoucherNoPrefixes_Acc_VoucherTypes_vVoucherTypesVoucherTypeId",
                table: "Acc_VoucherNoPrefixes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Acc_VoucherNoPrefixes",
                table: "Acc_VoucherNoPrefixes");

            migrationBuilder.RenameTable(
                name: "Acc_VoucherNoPrefixes",
                newName: "VoucherNoPrefixes");

            migrationBuilder.RenameIndex(
                name: "IX_Acc_VoucherNoPrefixes_vVoucherTypesVoucherTypeId",
                table: "VoucherNoPrefixes",
                newName: "IX_VoucherNoPrefixes_vVoucherTypesVoucherTypeId");

            migrationBuilder.AlterColumn<int>(
                name: "comid",
                table: "UserTransactionLogs",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 128,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_VoucherNoPrefixes",
                table: "VoucherNoPrefixes",
                column: "VoucherNoPrefixId");

            migrationBuilder.AddForeignKey(
                name: "FK_VoucherNoPrefixes_Acc_VoucherTypes_vVoucherTypesVoucherTypeId",
                table: "VoucherNoPrefixes",
                column: "vVoucherTypesVoucherTypeId",
                principalTable: "Acc_VoucherTypes",
                principalColumn: "VoucherTypeId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
