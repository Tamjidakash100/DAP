using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class technicalmaster : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cat_Meeting",
                columns: table => new
                {
                    MeetingId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Meeting = table.Column<string>(maxLength: 50, nullable: true),
                    MeetingType = table.Column<string>(maxLength: 50, nullable: true),
                    ComId = table.Column<string>(maxLength: 128, nullable: true),
                    UserId = table.Column<string>(maxLength: 128, nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    UpdateByUserId = table.Column<string>(maxLength: 80, nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cat_Meeting", x => x.MeetingId);
                });

            migrationBuilder.CreateTable(
                name: "Technical",
                columns: table => new
                {
                    TechicalId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MeetingType = table.Column<string>(maxLength: 50, nullable: true),
                    MeetingId = table.Column<int>(nullable: false),
                    MeetingName = table.Column<string>(maxLength: 200, nullable: true),
                    MeetingNo = table.Column<string>(maxLength: 50, nullable: true),
                    MeetingDate = table.Column<DateTime>(nullable: true),
                    MeetingTotalQty = table.Column<float>(nullable: true),
                    TrainingName = table.Column<string>(maxLength: 200, nullable: true),
                    TrainingSub = table.Column<string>(maxLength: 200, nullable: true),
                    TrainingPresentQty = table.Column<float>(nullable: true),
                    TrainingDay = table.Column<float>(nullable: true),
                    TrainingHour = table.Column<float>(nullable: true),
                    VisitName = table.Column<string>(maxLength: 200, nullable: true),
                    VisitOrg = table.Column<string>(maxLength: 200, nullable: true),
                    VisitTrainerQty = table.Column<float>(nullable: true),
                    VisitWorkhour = table.Column<float>(nullable: true),
                    VisitTraineeQty = table.Column<float>(nullable: true),
                    VisitOther = table.Column<float>(nullable: true),
                    VisitTotalQty = table.Column<float>(nullable: true),
                    ImportPhosphoric = table.Column<string>(maxLength: 200, nullable: true),
                    ImportChalanNo = table.Column<string>(maxLength: 100, nullable: true),
                    ImportQty = table.Column<float>(nullable: true),
                    ImportDate = table.Column<DateTime>(nullable: true),
                    ImportDensity = table.Column<string>(maxLength: 50, nullable: true),
                    ImportPhosphorusPentoxide = table.Column<string>(maxLength: 50, nullable: true),
                    WasteSampleCollectDate = table.Column<DateTime>(nullable: true),
                    WasteTestNum = table.Column<string>(maxLength: 50, nullable: true),
                    WasteReportSendNum = table.Column<string>(maxLength: 50, nullable: true),
                    WasteTestDate = table.Column<DateTime>(nullable: true),
                    WasteReportSendDate = table.Column<DateTime>(nullable: true),
                    LicenseRcvName = table.Column<string>(maxLength: 100, nullable: true),
                    LicenseCertificateRcvDate = table.Column<DateTime>(nullable: true),
                    LicenseExpireDate = table.Column<DateTime>(nullable: true),
                    LicenseRenewingAuth = table.Column<string>(maxLength: 200, nullable: true),
                    FSName = table.Column<string>(maxLength: 200, nullable: true),
                    FSNum = table.Column<string>(maxLength: 50, nullable: true),
                    FSDate = table.Column<DateTime>(nullable: true),
                    FSLocaiton = table.Column<string>(nullable: true),
                    EGType = table.Column<string>(maxLength: 200, nullable: true),
                    EGNum = table.Column<string>(maxLength: 50, nullable: true),
                    EGRefillDate = table.Column<DateTime>(nullable: true),
                    EGExpireDate = table.Column<DateTime>(nullable: true),
                    EGHydroTest = table.Column<string>(maxLength: 200, nullable: true),
                    dtInput = table.Column<DateTime>(nullable: false),
                    ComId = table.Column<string>(maxLength: 128, nullable: true),
                    UserId = table.Column<string>(maxLength: 128, nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    UpdateByUserId = table.Column<string>(maxLength: 80, nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Technical", x => x.TechicalId);
                    table.ForeignKey(
                        name: "FK_Technical_Cat_Meeting_MeetingId",
                        column: x => x.MeetingId,
                        principalTable: "Cat_Meeting",
                        principalColumn: "MeetingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Technical_MeetingId",
                table: "Technical",
                column: "MeetingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Technical");

            migrationBuilder.DropTable(
                name: "Cat_Meeting");
        }
    }
}
