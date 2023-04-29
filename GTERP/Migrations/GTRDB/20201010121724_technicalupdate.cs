using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class technicalupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tech_ImportAcid_Cat_ImportAcidItem_ImportAcidItemId",
                table: "Tech_ImportAcid");

            migrationBuilder.DropForeignKey(
                name: "FK_Tech_Meeting_Cat_MeetingNum_MeetingNumId",
                table: "Tech_Meeting");

            migrationBuilder.DropTable(
                name: "Cat_ImportAcidItem");

            migrationBuilder.DropTable(
                name: "Cat_MeetingNum");

            migrationBuilder.DropIndex(
                name: "IX_Tech_Meeting_MeetingNumId",
                table: "Tech_Meeting");

            migrationBuilder.DropColumn(
                name: "MeetingNumId",
                table: "Tech_Meeting");

            migrationBuilder.DropColumn(
                name: "TrainingSub",
                table: "Cat_TrainingSub");

            migrationBuilder.DropColumn(
                name: "FireSafetyType",
                table: "Cat_FireSafetyType");

            migrationBuilder.DropColumn(
                name: "FireSafetyLocation",
                table: "Cat_FireSafetyLocation");

            migrationBuilder.DropColumn(
                name: "FireSafetyItem",
                table: "Cat_FireSafetyItem");

            migrationBuilder.AddColumn<string>(
                name: "MeetingNum",
                table: "Tech_Meeting",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TrainingSubName",
                table: "Cat_TrainingSub",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "TrainingName",
                table: "Cat_Training",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MeetingName",
                table: "Cat_Meeting",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LicenseAuth",
                table: "Cat_LicenseAuth",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "License",
                table: "Cat_License",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "InspectionInstitute",
                table: "Cat_InspectionInst",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "InspectionName",
                table: "Cat_Inspection",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SafetyType",
                table: "Cat_FireSafetyType",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SafetyLocationName",
                table: "Cat_FireSafetyLocation",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ItemName",
                table: "Cat_FireSafetyItem",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Tech_ImportAcid_Products_ImportAcidItemId",
                table: "Tech_ImportAcid",
                column: "ImportAcidItemId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tech_ImportAcid_Products_ImportAcidItemId",
                table: "Tech_ImportAcid");

            migrationBuilder.DropColumn(
                name: "MeetingNum",
                table: "Tech_Meeting");

            migrationBuilder.DropColumn(
                name: "TrainingSubName",
                table: "Cat_TrainingSub");

            migrationBuilder.DropColumn(
                name: "SafetyType",
                table: "Cat_FireSafetyType");

            migrationBuilder.DropColumn(
                name: "SafetyLocationName",
                table: "Cat_FireSafetyLocation");

            migrationBuilder.DropColumn(
                name: "ItemName",
                table: "Cat_FireSafetyItem");

            migrationBuilder.AddColumn<int>(
                name: "MeetingNumId",
                table: "Tech_Meeting",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TrainingSub",
                table: "Cat_TrainingSub",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TrainingName",
                table: "Cat_Training",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "MeetingName",
                table: "Cat_Meeting",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "LicenseAuth",
                table: "Cat_LicenseAuth",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "License",
                table: "Cat_License",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "InspectionInstitute",
                table: "Cat_InspectionInst",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "InspectionName",
                table: "Cat_Inspection",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AddColumn<string>(
                name: "FireSafetyType",
                table: "Cat_FireSafetyType",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FireSafetyLocation",
                table: "Cat_FireSafetyLocation",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FireSafetyItem",
                table: "Cat_FireSafetyItem",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Cat_ImportAcidItem",
                columns: table => new
                {
                    ImportAcidItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ImportAcidItem = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UpdateByUserId = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cat_ImportAcidItem", x => x.ImportAcidItemId);
                });

            migrationBuilder.CreateTable(
                name: "Cat_MeetingNum",
                columns: table => new
                {
                    MeetingNumId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MeetingNum = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UpdateByUserId = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cat_MeetingNum", x => x.MeetingNumId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tech_Meeting_MeetingNumId",
                table: "Tech_Meeting",
                column: "MeetingNumId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tech_ImportAcid_Cat_ImportAcidItem_ImportAcidItemId",
                table: "Tech_ImportAcid",
                column: "ImportAcidItemId",
                principalTable: "Cat_ImportAcidItem",
                principalColumn: "ImportAcidItemId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tech_Meeting_Cat_MeetingNum_MeetingNumId",
                table: "Tech_Meeting",
                column: "MeetingNumId",
                principalTable: "Cat_MeetingNum",
                principalColumn: "MeetingNumId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
