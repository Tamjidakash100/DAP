using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class technicalmodelrem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuditInfo");

            migrationBuilder.DropTable(
                name: "Cat_FireSafetyLocation");

            migrationBuilder.DropTable(
                name: "Tech_FireSafety");

            migrationBuilder.DropTable(
                name: "Tech_ImportAcid");

            migrationBuilder.DropTable(
                name: "Tech_Inspection");

            migrationBuilder.DropTable(
                name: "Tech_License");

            migrationBuilder.DropTable(
                name: "Tech_Meeting");

            migrationBuilder.DropTable(
                name: "Tech_Training");

            migrationBuilder.DropTable(
                name: "Tech_WasteMgt");

            migrationBuilder.DropTable(
                name: "Cat_AuditObjType");

            migrationBuilder.DropTable(
                name: "Cat_AuditType");

            migrationBuilder.DropTable(
                name: "Cat_AuditYear");

            migrationBuilder.DropTable(
                name: "Cat_FireSafetyItem");

            migrationBuilder.DropTable(
                name: "Cat_FireSafetyType");

            migrationBuilder.DropTable(
                name: "Cat_Inspection");

            migrationBuilder.DropTable(
                name: "Cat_InspectionInst");

            migrationBuilder.DropTable(
                name: "Cat_LicenseAuth");

            migrationBuilder.DropTable(
                name: "Cat_License");

            migrationBuilder.DropTable(
                name: "Cat_Meeting");

            migrationBuilder.DropTable(
                name: "Cat_Training");

            migrationBuilder.DropTable(
                name: "Cat_TrainingSub");

            migrationBuilder.DropTable(
                name: "Cat_Waste");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cat_AuditObjType",
                columns: table => new
                {
                    AuditObjTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuditObjType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ComId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateByUserId = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cat_AuditObjType", x => x.AuditObjTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Cat_AuditType",
                columns: table => new
                {
                    AuditTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuditType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ComId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateByUserId = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cat_AuditType", x => x.AuditTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Cat_AuditYear",
                columns: table => new
                {
                    AuditYearId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuditYear = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ComId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateByUserId = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cat_AuditYear", x => x.AuditYearId);
                });

            migrationBuilder.CreateTable(
                name: "Cat_FireSafetyItem",
                columns: table => new
                {
                    FireSafetyItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ItemName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UpdateByUserId = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cat_FireSafetyItem", x => x.FireSafetyItemId);
                });

            migrationBuilder.CreateTable(
                name: "Cat_FireSafetyLocation",
                columns: table => new
                {
                    FireSafetyLocationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SafetyLocationName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UpdateByUserId = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cat_FireSafetyLocation", x => x.FireSafetyLocationId);
                });

            migrationBuilder.CreateTable(
                name: "Cat_FireSafetyType",
                columns: table => new
                {
                    FireSafetyTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SafetyType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UpdateByUserId = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cat_FireSafetyType", x => x.FireSafetyTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Cat_Inspection",
                columns: table => new
                {
                    InspectionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InspectionName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UpdateByUserId = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cat_Inspection", x => x.InspectionId);
                });

            migrationBuilder.CreateTable(
                name: "Cat_InspectionInst",
                columns: table => new
                {
                    InspectionInstId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InspectionInstitute = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UpdateByUserId = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cat_InspectionInst", x => x.InspectionInstId);
                });

            migrationBuilder.CreateTable(
                name: "Cat_License",
                columns: table => new
                {
                    LicenseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LicenseNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UpdateByUserId = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cat_License", x => x.LicenseId);
                });

            migrationBuilder.CreateTable(
                name: "Cat_LicenseAuth",
                columns: table => new
                {
                    LicenseAuthId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LicenseAuth = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UpdateByUserId = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cat_LicenseAuth", x => x.LicenseAuthId);
                });

            migrationBuilder.CreateTable(
                name: "Cat_Meeting",
                columns: table => new
                {
                    MeetingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MeetingName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UpdateByUserId = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cat_Meeting", x => x.MeetingId);
                });

            migrationBuilder.CreateTable(
                name: "Cat_Training",
                columns: table => new
                {
                    TrainingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TrainingName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UpdateByUserId = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cat_Training", x => x.TrainingId);
                });

            migrationBuilder.CreateTable(
                name: "Cat_TrainingSub",
                columns: table => new
                {
                    TrainingSubId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TrainingSubName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UpdateByUserId = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cat_TrainingSub", x => x.TrainingSubId);
                });

            migrationBuilder.CreateTable(
                name: "Cat_Waste",
                columns: table => new
                {
                    WasteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UpdateByUserId = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cat_Waste", x => x.WasteId);
                });

            migrationBuilder.CreateTable(
                name: "Tech_ImportAcid",
                columns: table => new
                {
                    Tech_ImportAcidId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChallanNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ComId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Density = table.Column<float>(type: "real", nullable: false),
                    DtDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ImportAcidItemId = table.Column<int>(type: "int", nullable: true),
                    Percent = table.Column<float>(type: "real", nullable: false),
                    Quantity = table.Column<float>(type: "real", nullable: false),
                    UpdateByUserId = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tech_ImportAcid", x => x.Tech_ImportAcidId);
                    table.ForeignKey(
                        name: "FK_Tech_ImportAcid_Products_ImportAcidItemId",
                        column: x => x.ImportAcidItemId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AuditInfo",
                columns: table => new
                {
                    AuditInfoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdvAudit = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AuditNum = table.Column<int>(type: "int", nullable: false),
                    AuditObjTypeId = table.Column<int>(type: "int", nullable: true),
                    AuditTypeId = table.Column<int>(type: "int", nullable: true),
                    AuditYearId = table.Column<int>(type: "int", nullable: true),
                    CollecttAudit = table.Column<int>(type: "int", nullable: false),
                    ComId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DraftAudit = table.Column<int>(type: "int", nullable: false),
                    GenAudit = table.Column<int>(type: "int", nullable: false),
                    UpdateByUserId = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditInfo", x => x.AuditInfoId);
                    table.ForeignKey(
                        name: "FK_AuditInfo_Cat_AuditObjType_AuditObjTypeId",
                        column: x => x.AuditObjTypeId,
                        principalTable: "Cat_AuditObjType",
                        principalColumn: "AuditObjTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AuditInfo_Cat_AuditType_AuditTypeId",
                        column: x => x.AuditTypeId,
                        principalTable: "Cat_AuditType",
                        principalColumn: "AuditTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AuditInfo_Cat_AuditYear_AuditYearId",
                        column: x => x.AuditYearId,
                        principalTable: "Cat_AuditYear",
                        principalColumn: "AuditYearId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tech_FireSafety",
                columns: table => new
                {
                    Tech_FireSafetyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeptId = table.Column<int>(type: "int", nullable: true),
                    DtDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtExpired = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtRefill = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FireSafetyItemId = table.Column<int>(type: "int", nullable: true),
                    FireSafetyTypeId = table.Column<int>(type: "int", nullable: true),
                    HydroTest = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Location = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Quantity = table.Column<float>(type: "real", nullable: false),
                    UpdateByUserId = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tech_FireSafety", x => x.Tech_FireSafetyId);
                    table.ForeignKey(
                        name: "FK_Tech_FireSafety_Cat_Department_DeptId",
                        column: x => x.DeptId,
                        principalTable: "Cat_Department",
                        principalColumn: "DeptId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tech_FireSafety_Cat_FireSafetyItem_FireSafetyItemId",
                        column: x => x.FireSafetyItemId,
                        principalTable: "Cat_FireSafetyItem",
                        principalColumn: "FireSafetyItemId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tech_FireSafety_Cat_FireSafetyType_FireSafetyTypeId",
                        column: x => x.FireSafetyTypeId,
                        principalTable: "Cat_FireSafetyType",
                        principalColumn: "FireSafetyTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tech_Inspection",
                columns: table => new
                {
                    Tech_InspectionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeptId = table.Column<int>(type: "int", nullable: true),
                    InspectionId = table.Column<int>(type: "int", nullable: true),
                    InspectionInstId = table.Column<int>(type: "int", nullable: true),
                    OtherNum = table.Column<int>(type: "int", nullable: false),
                    TeacherNum = table.Column<int>(type: "int", nullable: false),
                    TraineeNum = table.Column<int>(type: "int", nullable: false),
                    TtlNum = table.Column<int>(type: "int", nullable: false),
                    UpdateByUserId = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tech_Inspection", x => x.Tech_InspectionId);
                    table.ForeignKey(
                        name: "FK_Tech_Inspection_Cat_Department_DeptId",
                        column: x => x.DeptId,
                        principalTable: "Cat_Department",
                        principalColumn: "DeptId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tech_Inspection_Cat_Inspection_InspectionId",
                        column: x => x.InspectionId,
                        principalTable: "Cat_Inspection",
                        principalColumn: "InspectionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tech_Inspection_Cat_InspectionInst_InspectionInstId",
                        column: x => x.InspectionInstId,
                        principalTable: "Cat_InspectionInst",
                        principalColumn: "InspectionInstId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tech_License",
                columns: table => new
                {
                    Tech_LicenseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeptId = table.Column<int>(type: "int", nullable: true),
                    DtApply = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtExpired = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtLicenseRecptRenew = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LicenseAuthId = table.Column<int>(type: "int", nullable: true),
                    LicenseId = table.Column<int>(type: "int", nullable: true),
                    UpdateByUserId = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tech_License", x => x.Tech_LicenseId);
                    table.ForeignKey(
                        name: "FK_Tech_License_Cat_Department_DeptId",
                        column: x => x.DeptId,
                        principalTable: "Cat_Department",
                        principalColumn: "DeptId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tech_License_Cat_LicenseAuth_LicenseAuthId",
                        column: x => x.LicenseAuthId,
                        principalTable: "Cat_LicenseAuth",
                        principalColumn: "LicenseAuthId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tech_License_Cat_License_LicenseId",
                        column: x => x.LicenseId,
                        principalTable: "Cat_License",
                        principalColumn: "LicenseId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tech_Meeting",
                columns: table => new
                {
                    Tech_MeetingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeptId = table.Column<int>(type: "int", nullable: true),
                    DtMeeting = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MeetingId = table.Column<int>(type: "int", nullable: true),
                    MeetingNum = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    TtlMeeting = table.Column<float>(type: "real", nullable: false),
                    UpdateByUserId = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tech_Meeting", x => x.Tech_MeetingId);
                    table.ForeignKey(
                        name: "FK_Tech_Meeting_Cat_Department_DeptId",
                        column: x => x.DeptId,
                        principalTable: "Cat_Department",
                        principalColumn: "DeptId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tech_Meeting_Cat_Meeting_MeetingId",
                        column: x => x.MeetingId,
                        principalTable: "Cat_Meeting",
                        principalColumn: "MeetingId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tech_Training",
                columns: table => new
                {
                    Tech_TrainingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DayNum = table.Column<int>(type: "int", nullable: false),
                    DeptId = table.Column<int>(type: "int", nullable: true),
                    DtTraining = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ParticipantName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TrainingId = table.Column<int>(type: "int", nullable: true),
                    TrainingSubId = table.Column<int>(type: "int", nullable: true),
                    UpdateByUserId = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    WorkingHr = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tech_Training", x => x.Tech_TrainingId);
                    table.ForeignKey(
                        name: "FK_Tech_Training_Cat_Department_DeptId",
                        column: x => x.DeptId,
                        principalTable: "Cat_Department",
                        principalColumn: "DeptId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tech_Training_Cat_Training_TrainingId",
                        column: x => x.TrainingId,
                        principalTable: "Cat_Training",
                        principalColumn: "TrainingId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tech_Training_Cat_TrainingSub_TrainingSubId",
                        column: x => x.TrainingSubId,
                        principalTable: "Cat_TrainingSub",
                        principalColumn: "TrainingSubId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tech_WasteMgt",
                columns: table => new
                {
                    Tech_WasteMgtId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DtSampleCollect = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtSendRpt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtTest = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SendRptNum = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TestNum = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UpdateByUserId = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    WasteId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tech_WasteMgt", x => x.Tech_WasteMgtId);
                    table.ForeignKey(
                        name: "FK_Tech_WasteMgt_Cat_Waste_WasteId",
                        column: x => x.WasteId,
                        principalTable: "Cat_Waste",
                        principalColumn: "WasteId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuditInfo_AuditObjTypeId",
                table: "AuditInfo",
                column: "AuditObjTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AuditInfo_AuditTypeId",
                table: "AuditInfo",
                column: "AuditTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AuditInfo_AuditYearId",
                table: "AuditInfo",
                column: "AuditYearId");

            migrationBuilder.CreateIndex(
                name: "IX_Tech_FireSafety_DeptId",
                table: "Tech_FireSafety",
                column: "DeptId");

            migrationBuilder.CreateIndex(
                name: "IX_Tech_FireSafety_FireSafetyItemId",
                table: "Tech_FireSafety",
                column: "FireSafetyItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Tech_FireSafety_FireSafetyTypeId",
                table: "Tech_FireSafety",
                column: "FireSafetyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Tech_ImportAcid_ImportAcidItemId",
                table: "Tech_ImportAcid",
                column: "ImportAcidItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Tech_Inspection_DeptId",
                table: "Tech_Inspection",
                column: "DeptId");

            migrationBuilder.CreateIndex(
                name: "IX_Tech_Inspection_InspectionId",
                table: "Tech_Inspection",
                column: "InspectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Tech_Inspection_InspectionInstId",
                table: "Tech_Inspection",
                column: "InspectionInstId");

            migrationBuilder.CreateIndex(
                name: "IX_Tech_License_DeptId",
                table: "Tech_License",
                column: "DeptId");

            migrationBuilder.CreateIndex(
                name: "IX_Tech_License_LicenseAuthId",
                table: "Tech_License",
                column: "LicenseAuthId");

            migrationBuilder.CreateIndex(
                name: "IX_Tech_License_LicenseId",
                table: "Tech_License",
                column: "LicenseId");

            migrationBuilder.CreateIndex(
                name: "IX_Tech_Meeting_DeptId",
                table: "Tech_Meeting",
                column: "DeptId");

            migrationBuilder.CreateIndex(
                name: "IX_Tech_Meeting_MeetingId",
                table: "Tech_Meeting",
                column: "MeetingId");

            migrationBuilder.CreateIndex(
                name: "IX_Tech_Training_DeptId",
                table: "Tech_Training",
                column: "DeptId");

            migrationBuilder.CreateIndex(
                name: "IX_Tech_Training_TrainingId",
                table: "Tech_Training",
                column: "TrainingId");

            migrationBuilder.CreateIndex(
                name: "IX_Tech_Training_TrainingSubId",
                table: "Tech_Training",
                column: "TrainingSubId");

            migrationBuilder.CreateIndex(
                name: "IX_Tech_WasteMgt_WasteId",
                table: "Tech_WasteMgt",
                column: "WasteId");
        }
    }
}
