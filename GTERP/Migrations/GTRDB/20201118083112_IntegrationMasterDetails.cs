using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class IntegrationMasterDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cat_PayrollIntegration_Settings");

            migrationBuilder.CreateTable(
                name: "Cat_Integration_Setting_Mains",
                columns: table => new
                {
                    IntegrationSettingMainId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IntegrationSettingName = table.Column<string>(maxLength: 30, nullable: false),
                    IntegrationTableName = table.Column<string>(nullable: true),
                    MainSLNo = table.Column<string>(nullable: true),
                    ComId = table.Column<string>(nullable: true),
                    PcName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(maxLength: 128, nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    UpdateByUserId = table.Column<string>(nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: true),
                    FromDate = table.Column<DateTime>(nullable: false),
                    ToDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cat_Integration_Setting_Mains", x => x.IntegrationSettingMainId);
                });

            migrationBuilder.CreateTable(
                name: "Cat_Integration_Setting_Details",
                columns: table => new
                {
                    IntegrationSettingDetailsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IntegrationSettingMainId = table.Column<int>(nullable: false),
                    AccId = table.Column<int>(nullable: false),
                    PayrollColumnName = table.Column<string>(nullable: true),
                    OtherLinkOne = table.Column<string>(nullable: true),
                    OtherLineTwo = table.Column<string>(nullable: true),
                    SLNo = table.Column<string>(nullable: true),
                    IsDebit = table.Column<bool>(nullable: false),
                    IsCredit = table.Column<bool>(nullable: false),
                    ComId = table.Column<string>(nullable: true),
                    PcName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(maxLength: 128, nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    UpdateByUserId = table.Column<string>(nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: true),
                    FromDate = table.Column<DateTime>(nullable: false),
                    ToDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cat_Integration_Setting_Details", x => x.IntegrationSettingDetailsId);
                    table.ForeignKey(
                        name: "FK_Cat_Integration_Setting_Details_Acc_ChartOfAccounts_AccId",
                        column: x => x.AccId,
                        principalTable: "Acc_ChartOfAccounts",
                        principalColumn: "AccId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cat_Integration_Setting_Details_Cat_Integration_Setting_Mains_IntegrationSettingMainId",
                        column: x => x.IntegrationSettingMainId,
                        principalTable: "Cat_Integration_Setting_Mains",
                        principalColumn: "IntegrationSettingMainId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cat_Integration_Setting_Details_AccId",
                table: "Cat_Integration_Setting_Details",
                column: "AccId");

            migrationBuilder.CreateIndex(
                name: "IX_Cat_Integration_Setting_Details_IntegrationSettingMainId",
                table: "Cat_Integration_Setting_Details",
                column: "IntegrationSettingMainId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cat_Integration_Setting_Details");

            migrationBuilder.DropTable(
                name: "Cat_Integration_Setting_Mains");

            migrationBuilder.CreateTable(
                name: "Cat_PayrollIntegration_Settings",
                columns: table => new
                {
                    PayrollIntegrationSettingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccId = table.Column<int>(type: "int", nullable: false),
                    ComId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FromDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsCredit = table.Column<bool>(type: "bit", nullable: false),
                    IsDebit = table.Column<bool>(type: "bit", nullable: false),
                    OtherLineTwo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OtherLinkOne = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PayrollColumnName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PayrollIntegrationSettingName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    PayrollTableName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PcName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SLNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ToDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateByUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cat_PayrollIntegration_Settings", x => x.PayrollIntegrationSettingId);
                    table.ForeignKey(
                        name: "FK_Cat_PayrollIntegration_Settings_Acc_ChartOfAccounts_AccId",
                        column: x => x.AccId,
                        principalTable: "Acc_ChartOfAccounts",
                        principalColumn: "AccId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cat_PayrollIntegration_Settings_AccId",
                table: "Cat_PayrollIntegration_Settings",
                column: "AccId");
        }
    }
}
