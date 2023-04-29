using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class vouchertype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "YearlyVoucherSerialId",
                table: "Acc_VoucherMains");

            migrationBuilder.AddColumn<int>(
                name: "YearlyVoucherTypeWiseSerial",
                table: "Acc_VoucherMains",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "YearlyVoucherTypeWiseSerial",
                table: "Acc_VoucherMains");

            migrationBuilder.AddColumn<int>(
                name: "YearlyVoucherSerialId",
                table: "Acc_VoucherMains",
                type: "int",
                nullable: true);
        }
    }
}
