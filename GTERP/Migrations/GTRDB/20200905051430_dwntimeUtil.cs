using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class dwntimeUtil : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReasonId",
                table: "LabourStrike",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "DownTimeReason",
                columns: table => new
                {
                    DownTimeReasonId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Reason = table.Column<string>(maxLength: 300, nullable: true),
                    DtInput = table.Column<DateTime>(nullable: false),
                    Remarks = table.Column<string>(maxLength: 300, nullable: true),
                    AddedbyUserId = table.Column<string>(maxLength: 128, nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    UpdatedbyUserId = table.Column<string>(maxLength: 128, nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: true),
                    ComId = table.Column<string>(maxLength: 128, nullable: true),
                    UserId = table.Column<string>(maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DownTimeReason", x => x.DownTimeReasonId);
                });

            migrationBuilder.CreateTable(
                name: "UseUtilities",
                columns: table => new
                {
                    UtilitiesId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrdUnitId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    RawMaterialId = table.Column<int>(nullable: false),
                    FiscalYearId = table.Column<int>(nullable: false),
                    DtInput = table.Column<DateTime>(nullable: false),
                    Remarks = table.Column<string>(maxLength: 300, nullable: true),
                    StdDesignVal = table.Column<float>(nullable: true),
                    FiscalYearBudgetVal = table.Column<float>(nullable: true),
                    AddedbyUserId = table.Column<string>(maxLength: 128, nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    UpdatedbyUserId = table.Column<string>(maxLength: 128, nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: true),
                    ComId = table.Column<string>(maxLength: 128, nullable: true),
                    UserId = table.Column<string>(maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UseUtilities", x => x.UtilitiesId);
                    table.ForeignKey(
                        name: "FK_UseUtilities_Acc_FiscalYears_FiscalYearId",
                        column: x => x.FiscalYearId,
                        principalTable: "Acc_FiscalYears",
                        principalColumn: "FiscalYearId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UseUtilities_PrdUnits_PrdUnitId",
                        column: x => x.PrdUnitId,
                        principalTable: "PrdUnits",
                        principalColumn: "PrdUnitId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UseUtilities_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UseUtilities_Products_RawMaterialId",
                        column: x => x.RawMaterialId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LabourStrike_ReasonId",
                table: "LabourStrike",
                column: "ReasonId");

            migrationBuilder.CreateIndex(
                name: "IX_UseUtilities_FiscalYearId",
                table: "UseUtilities",
                column: "FiscalYearId");

            migrationBuilder.CreateIndex(
                name: "IX_UseUtilities_PrdUnitId",
                table: "UseUtilities",
                column: "PrdUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_UseUtilities_ProductId",
                table: "UseUtilities",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_UseUtilities_RawMaterialId",
                table: "UseUtilities",
                column: "RawMaterialId");

            migrationBuilder.AddForeignKey(
                name: "FK_LabourStrike_DownTimeReason_ReasonId",
                table: "LabourStrike",
                column: "ReasonId",
                principalTable: "DownTimeReason",
                principalColumn: "DownTimeReasonId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LabourStrike_DownTimeReason_ReasonId",
                table: "LabourStrike");

            migrationBuilder.DropTable(
                name: "DownTimeReason");

            migrationBuilder.DropTable(
                name: "UseUtilities");

            migrationBuilder.DropIndex(
                name: "IX_LabourStrike_ReasonId",
                table: "LabourStrike");

            migrationBuilder.DropColumn(
                name: "ReasonId",
                table: "LabourStrike");
        }
    }
}
