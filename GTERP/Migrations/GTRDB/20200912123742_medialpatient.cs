using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class medialpatient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medical_Master_Cat_MedicalDiagnosis_DiagId",
                table: "Medical_Master");

            migrationBuilder.DropTable(
                name: "LabourStrike");

            migrationBuilder.DropIndex(
                name: "IX_Medical_Master_DiagId",
                table: "Medical_Master");

            migrationBuilder.DropColumn(
                name: "DiagId",
                table: "Medical_Master");

            migrationBuilder.DropColumn(
                name: "MoneyLoss",
                table: "DownTime");

            migrationBuilder.DropColumn(
                name: "ProductionLoss",
                table: "DownTime");

            migrationBuilder.AlterColumn<string>(
                name: "BP",
                table: "Medical_Master",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AddColumn<string>(
                name: "Patient",
                table: "Medical_Details",
                maxLength: 30,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Patient",
                table: "Medical_Details");

            migrationBuilder.AlterColumn<float>(
                name: "BP",
                table: "Medical_Master",
                type: "real",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DiagId",
                table: "Medical_Master",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "MoneyLoss",
                table: "DownTime",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "ProductionLoss",
                table: "DownTime",
                type: "real",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "LabourStrike",
                columns: table => new
                {
                    LabourStrikeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddedbyUserId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FromTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    MoneyLoss = table.Column<float>(type: "real", nullable: true),
                    PrdUnitId = table.Column<int>(type: "int", nullable: false),
                    ProductionLoss = table.Column<float>(type: "real", nullable: true),
                    ReasonId = table.Column<int>(type: "int", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    StrikeDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ToTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    UpdatedbyUserId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    comid = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    userid = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LabourStrike", x => x.LabourStrikeId);
                    table.ForeignKey(
                        name: "FK_LabourStrike_PrdUnits_PrdUnitId",
                        column: x => x.PrdUnitId,
                        principalTable: "PrdUnits",
                        principalColumn: "PrdUnitId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LabourStrike_DownTimeReason_ReasonId",
                        column: x => x.ReasonId,
                        principalTable: "DownTimeReason",
                        principalColumn: "DownTimeReasonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Medical_Master_DiagId",
                table: "Medical_Master",
                column: "DiagId");

            migrationBuilder.CreateIndex(
                name: "IX_LabourStrike_PrdUnitId",
                table: "LabourStrike",
                column: "PrdUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_LabourStrike_ReasonId",
                table: "LabourStrike",
                column: "ReasonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Medical_Master_Cat_MedicalDiagnosis_DiagId",
                table: "Medical_Master",
                column: "DiagId",
                principalTable: "Cat_MedicalDiagnosis",
                principalColumn: "DiagId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
