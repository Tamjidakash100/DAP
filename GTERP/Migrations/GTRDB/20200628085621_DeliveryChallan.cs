using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class DeliveryChallan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "dtTo",
                table: "Cat_ITComputationSetting",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "FiscalYear",
                table: "Cat_ITComputationSetting",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "DeliveryChallan",
                columns: table => new
                {
                    DeliveryChallanId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChallanNo = table.Column<int>(nullable: false),
                    DeliveryDate = table.Column<DateTime>(nullable: false),
                    DeliveryQty = table.Column<float>(nullable: false),
                    DOId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryChallan", x => x.DeliveryChallanId);
                    table.ForeignKey(
                        name: "FK_DeliveryChallan_DeliveryOrder_DOId",
                        column: x => x.DOId,
                        principalTable: "DeliveryOrder",
                        principalColumn: "DOId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryChallan_DOId",
                table: "DeliveryChallan",
                column: "DOId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeliveryChallan");

            migrationBuilder.AlterColumn<DateTime>(
                name: "dtTo",
                table: "Cat_ITComputationSetting",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FiscalYear",
                table: "Cat_ITComputationSetting",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 20,
                oldNullable: true);
        }
    }
}
