using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class vouchernoprefixes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VoucherNoPrefixs_VoucherTypes_VoucherTypeId",
                table: "VoucherNoPrefixs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VoucherNoPrefixs",
                table: "VoucherNoPrefixs");

            migrationBuilder.RenameTable(
                name: "VoucherNoPrefixs",
                newName: "VoucherNoPrefixes");

            migrationBuilder.RenameIndex(
                name: "IX_VoucherNoPrefixs_VoucherTypeId",
                table: "VoucherNoPrefixes",
                newName: "IX_VoucherNoPrefixes_VoucherTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VoucherNoPrefixes",
                table: "VoucherNoPrefixes",
                column: "VoucherNoPrefixId");

            migrationBuilder.AddForeignKey(
                name: "FK_VoucherNoPrefixes_VoucherTypes_VoucherTypeId",
                table: "VoucherNoPrefixes",
                column: "VoucherTypeId",
                principalTable: "VoucherTypes",
                principalColumn: "VoucherTypeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VoucherNoPrefixes_VoucherTypes_VoucherTypeId",
                table: "VoucherNoPrefixes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VoucherNoPrefixes",
                table: "VoucherNoPrefixes");

            migrationBuilder.RenameTable(
                name: "VoucherNoPrefixes",
                newName: "VoucherNoPrefixs");

            migrationBuilder.RenameIndex(
                name: "IX_VoucherNoPrefixes_VoucherTypeId",
                table: "VoucherNoPrefixs",
                newName: "IX_VoucherNoPrefixs_VoucherTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VoucherNoPrefixs",
                table: "VoucherNoPrefixs",
                column: "VoucherNoPrefixId");

            migrationBuilder.AddForeignKey(
                name: "FK_VoucherNoPrefixs_VoucherTypes_VoucherTypeId",
                table: "VoucherNoPrefixs",
                column: "VoucherTypeId",
                principalTable: "VoucherTypes",
                principalColumn: "VoucherTypeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
