using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class checknoclearingclelar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Acc_VoucherSubCheckno_Clearings");

            migrationBuilder.AddColumn<string>(
                name: "dtChkClear",
                table: "Acc_VoucherSubChecnos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "dtChkTo",
                table: "Acc_VoucherSubChecnos",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isClear",
                table: "Acc_VoucherSubChecnos",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "dtChkClear",
                table: "Acc_VoucherSubChecnos");

            migrationBuilder.DropColumn(
                name: "dtChkTo",
                table: "Acc_VoucherSubChecnos");

            migrationBuilder.DropColumn(
                name: "isClear",
                table: "Acc_VoucherSubChecnos");

            migrationBuilder.CreateTable(
                name: "Acc_VoucherSubCheckno_Clearings",
                columns: table => new
                {
                    VoucherSubCheckNoClearingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VoucherSubCheckId = table.Column<int>(type: "int", nullable: false),
                    comid = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    dtChkClear = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isClear = table.Column<bool>(type: "bit", nullable: false),
                    userid = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    useridUpdate = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true)
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
    }
}
