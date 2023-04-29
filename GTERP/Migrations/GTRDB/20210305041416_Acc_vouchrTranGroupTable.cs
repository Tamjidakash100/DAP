using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class Acc_vouchrTranGroupTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Acc_VoucherTranGroups",
                columns: table => new
                {
                    VoucherTranId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VoucherId = table.Column<int>(nullable: false),
                    VoucherTranGroupId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acc_VoucherTranGroups", x => x.VoucherTranId);
                    table.ForeignKey(
                        name: "FK_Acc_VoucherTranGroups_Acc_VoucherMains_VoucherId",
                        column: x => x.VoucherId,
                        principalTable: "Acc_VoucherMains",
                        principalColumn: "VoucherId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Acc_VoucherTranGroups_VoucherTranGroups_VoucherTranGroupId",
                        column: x => x.VoucherTranGroupId,
                        principalTable: "VoucherTranGroups",
                        principalColumn: "VoucherTranGroupId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Acc_VoucherTranGroups_VoucherId",
                table: "Acc_VoucherTranGroups",
                column: "VoucherId");

            migrationBuilder.CreateIndex(
                name: "IX_Acc_VoucherTranGroups_VoucherTranGroupId",
                table: "Acc_VoucherTranGroups",
                column: "VoucherTranGroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Acc_VoucherTranGroups");
        }
    }
}
