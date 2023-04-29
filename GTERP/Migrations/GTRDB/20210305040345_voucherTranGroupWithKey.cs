using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class voucherTranGroupWithKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IntegrationRemarks",
                table: "Cat_Integration_Setting_Mains",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Advance",
                table: "Bill_Main",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "VoucherTranGroupId",
                table: "Acc_VoucherMains",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VoucherTranGroupList",
                table: "Acc_VoucherMains",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "VoucherTranGroups",
                columns: table => new
                {
                    VoucherTranGroupId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VoucherTranGroupName = table.Column<string>(maxLength: 100, nullable: false),
                    userid = table.Column<string>(maxLength: 128, nullable: true),
                    isDelete = table.Column<bool>(nullable: false),
                    comid = table.Column<string>(maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VoucherTranGroups", x => x.VoucherTranGroupId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Acc_VoucherMains_VoucherTranGroupId",
                table: "Acc_VoucherMains",
                column: "VoucherTranGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Acc_VoucherMains_VoucherTranGroups_VoucherTranGroupId",
                table: "Acc_VoucherMains",
                column: "VoucherTranGroupId",
                principalTable: "VoucherTranGroups",
                principalColumn: "VoucherTranGroupId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Acc_VoucherMains_VoucherTranGroups_VoucherTranGroupId",
                table: "Acc_VoucherMains");

            migrationBuilder.DropTable(
                name: "VoucherTranGroups");

            migrationBuilder.DropIndex(
                name: "IX_Acc_VoucherMains_VoucherTranGroupId",
                table: "Acc_VoucherMains");

            migrationBuilder.DropColumn(
                name: "IntegrationRemarks",
                table: "Cat_Integration_Setting_Mains");

            migrationBuilder.DropColumn(
                name: "Advance",
                table: "Bill_Main");

            migrationBuilder.DropColumn(
                name: "VoucherTranGroupId",
                table: "Acc_VoucherMains");

            migrationBuilder.DropColumn(
                name: "VoucherTranGroupList",
                table: "Acc_VoucherMains");
        }
    }
}
