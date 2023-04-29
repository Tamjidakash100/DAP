using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class checknoclearing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Acc_VoucherSubCheckno_Clearings",
                columns: table => new
                {
                    VoucherSubCheckNoClearingId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VoucherSubCheckId = table.Column<int>(nullable: false),
                    dtChkClear = table.Column<DateTime>(nullable: false),
                    isClear = table.Column<bool>(nullable: false),
                    Remarks = table.Column<string>(nullable: true),
                    userid = table.Column<string>(maxLength: 128, nullable: true),
                    comid = table.Column<string>(maxLength: 128, nullable: true),
                    useridUpdate = table.Column<string>(maxLength: 128, nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acc_VoucherSubCheckno_Clearings", x => x.VoucherSubCheckNoClearingId);
                    table.ForeignKey(
                        name: "FK_Acc_VoucherSubCheckno_Clearings_Acc_VoucherSubChecnos_VoucherSubCheckId",
                        column: x => x.VoucherSubCheckId,
                        principalTable: "Acc_VoucherSubChecnos",
                        principalColumn: "VoucherSubCheckId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Acc_VoucherSubCheckno_Clearings_VoucherSubCheckId",
                table: "Acc_VoucherSubCheckno_Clearings",
                column: "VoucherSubCheckId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Acc_VoucherSubCheckno_Clearings");
        }
    }
}
