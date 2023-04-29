using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class gatepass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GatePassSubId",
                table: "DeliveryChallan",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "GatePass",
                columns: table => new
                {
                    GatePassId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GatePassNo = table.Column<int>(nullable: false),
                    GatePassFrom = table.Column<string>(nullable: true),
                    TruckNumber = table.Column<string>(nullable: true),
                    DriverName = table.Column<string>(nullable: true),
                    DriverMobile = table.Column<string>(nullable: true),
                    FiscalYearId = table.Column<int>(nullable: false),
                    FiscalMonthId = table.Column<int>(nullable: false),
                    DistrictId = table.Column<int>(nullable: false),
                    PoliceStationId = table.Column<int>(nullable: false),
                    ComId = table.Column<string>(maxLength: 128, nullable: true),
                    UserId = table.Column<string>(maxLength: 128, nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: true),
                    UpdateByUserId = table.Column<string>(maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GatePass", x => x.GatePassId);
                });

            migrationBuilder.CreateTable(
                name: "GatePassSub",
                columns: table => new
                {
                    GatePassSubId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TruckLoadQty = table.Column<int>(nullable: false),
                    DeliveryChallanId = table.Column<int>(nullable: false),
                    GatePassId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GatePassSub", x => x.GatePassSubId);
                    table.ForeignKey(
                        name: "FK_GatePassSub_GatePass_GatePassId",
                        column: x => x.GatePassId,
                        principalTable: "GatePass",
                        principalColumn: "GatePassId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryChallan_GatePassSubId",
                table: "DeliveryChallan",
                column: "GatePassSubId");

            migrationBuilder.CreateIndex(
                name: "IX_GatePassSub_GatePassId",
                table: "GatePassSub",
                column: "GatePassId");

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryChallan_GatePassSub_GatePassSubId",
                table: "DeliveryChallan",
                column: "GatePassSubId",
                principalTable: "GatePassSub",
                principalColumn: "GatePassSubId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryChallan_GatePassSub_GatePassSubId",
                table: "DeliveryChallan");

            migrationBuilder.DropTable(
                name: "GatePassSub");

            migrationBuilder.DropTable(
                name: "GatePass");

            migrationBuilder.DropIndex(
                name: "IX_DeliveryChallan_GatePassSubId",
                table: "DeliveryChallan");

            migrationBuilder.DropColumn(
                name: "GatePassSubId",
                table: "DeliveryChallan");
        }
    }
}
