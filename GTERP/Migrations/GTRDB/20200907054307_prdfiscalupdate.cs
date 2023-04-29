using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class prdfiscalupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FiscalMonthId",
                table: "UseUtilities",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FiscalMonthId",
                table: "SalesTargetSetup",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FiscalMonthId",
                table: "ProductionTargetSetup",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PINatureId",
                table: "COM_ProformaInvoices",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DownTime",
                columns: table => new
                {
                    DownTimeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrdUnitId = table.Column<int>(nullable: false),
                    ReasonId = table.Column<int>(nullable: false),
                    FiscalYearId = table.Column<int>(nullable: true),
                    FiscalMonthId = table.Column<int>(nullable: true),
                    StrikeDate = table.Column<DateTime>(nullable: false),
                    FromTime = table.Column<TimeSpan>(nullable: false),
                    ToTime = table.Column<TimeSpan>(nullable: false),
                    ProductionLoss = table.Column<float>(nullable: true),
                    MoneyLoss = table.Column<float>(nullable: true),
                    Remarks = table.Column<string>(maxLength: 300, nullable: true),
                    AddedbyUserId = table.Column<string>(maxLength: 128, nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    UpdatedbyUserId = table.Column<string>(maxLength: 128, nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: true),
                    comid = table.Column<string>(maxLength: 128, nullable: true),
                    userid = table.Column<string>(maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DownTime", x => x.DownTimeId);
                    table.ForeignKey(
                        name: "FK_DownTime_Acc_FiscalMonths_FiscalMonthId",
                        column: x => x.FiscalMonthId,
                        principalTable: "Acc_FiscalMonths",
                        principalColumn: "FiscalMonthId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DownTime_Acc_FiscalYears_FiscalYearId",
                        column: x => x.FiscalYearId,
                        principalTable: "Acc_FiscalYears",
                        principalColumn: "FiscalYearId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DownTime_PrdUnits_PrdUnitId",
                        column: x => x.PrdUnitId,
                        principalTable: "PrdUnits",
                        principalColumn: "PrdUnitId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DownTime_DownTimeReason_ReasonId",
                        column: x => x.ReasonId,
                        principalTable: "DownTimeReason",
                        principalColumn: "DownTimeReasonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PINature",
                columns: table => new
                {
                    PINatureId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PINatureName = table.Column<string>(maxLength: 100, nullable: false),
                    PINatureShortName = table.Column<string>(maxLength: 100, nullable: false),
                    comid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PINature", x => x.PINatureId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UseUtilities_FiscalMonthId",
                table: "UseUtilities",
                column: "FiscalMonthId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesTargetSetup_FiscalMonthId",
                table: "SalesTargetSetup",
                column: "FiscalMonthId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductionTargetSetup_FiscalMonthId",
                table: "ProductionTargetSetup",
                column: "FiscalMonthId");

            migrationBuilder.CreateIndex(
                name: "IX_COM_ProformaInvoices_PINatureId",
                table: "COM_ProformaInvoices",
                column: "PINatureId");

            migrationBuilder.CreateIndex(
                name: "IX_DownTime_FiscalMonthId",
                table: "DownTime",
                column: "FiscalMonthId");

            migrationBuilder.CreateIndex(
                name: "IX_DownTime_FiscalYearId",
                table: "DownTime",
                column: "FiscalYearId");

            migrationBuilder.CreateIndex(
                name: "IX_DownTime_PrdUnitId",
                table: "DownTime",
                column: "PrdUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_DownTime_ReasonId",
                table: "DownTime",
                column: "ReasonId");

            migrationBuilder.AddForeignKey(
                name: "FK_COM_ProformaInvoices_PINature_PINatureId",
                table: "COM_ProformaInvoices",
                column: "PINatureId",
                principalTable: "PINature",
                principalColumn: "PINatureId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductionTargetSetup_Acc_FiscalMonths_FiscalMonthId",
                table: "ProductionTargetSetup",
                column: "FiscalMonthId",
                principalTable: "Acc_FiscalMonths",
                principalColumn: "FiscalMonthId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesTargetSetup_Acc_FiscalMonths_FiscalMonthId",
                table: "SalesTargetSetup",
                column: "FiscalMonthId",
                principalTable: "Acc_FiscalMonths",
                principalColumn: "FiscalMonthId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UseUtilities_Acc_FiscalMonths_FiscalMonthId",
                table: "UseUtilities",
                column: "FiscalMonthId",
                principalTable: "Acc_FiscalMonths",
                principalColumn: "FiscalMonthId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_COM_ProformaInvoices_PINature_PINatureId",
                table: "COM_ProformaInvoices");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductionTargetSetup_Acc_FiscalMonths_FiscalMonthId",
                table: "ProductionTargetSetup");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesTargetSetup_Acc_FiscalMonths_FiscalMonthId",
                table: "SalesTargetSetup");

            migrationBuilder.DropForeignKey(
                name: "FK_UseUtilities_Acc_FiscalMonths_FiscalMonthId",
                table: "UseUtilities");

            migrationBuilder.DropTable(
                name: "DownTime");

            migrationBuilder.DropTable(
                name: "PINature");

            migrationBuilder.DropIndex(
                name: "IX_UseUtilities_FiscalMonthId",
                table: "UseUtilities");

            migrationBuilder.DropIndex(
                name: "IX_SalesTargetSetup_FiscalMonthId",
                table: "SalesTargetSetup");

            migrationBuilder.DropIndex(
                name: "IX_ProductionTargetSetup_FiscalMonthId",
                table: "ProductionTargetSetup");

            migrationBuilder.DropIndex(
                name: "IX_COM_ProformaInvoices_PINatureId",
                table: "COM_ProformaInvoices");

            migrationBuilder.DropColumn(
                name: "FiscalMonthId",
                table: "UseUtilities");

            migrationBuilder.DropColumn(
                name: "FiscalMonthId",
                table: "SalesTargetSetup");

            migrationBuilder.DropColumn(
                name: "FiscalMonthId",
                table: "ProductionTargetSetup");

            migrationBuilder.DropColumn(
                name: "PINatureId",
                table: "COM_ProformaInvoices");
        }
    }
}
