using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class fa_dep_schedule_tem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tem_FA_Details",
                columns: table => new
                {
                    FA_DetailsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FA_MasterId = table.Column<int>(nullable: false),
                    AssetItem = table.Column<string>(nullable: true),
                    IssuNo = table.Column<string>(nullable: true),
                    PurchseDate = table.Column<DateTime>(nullable: false),
                    PurchaseValue = table.Column<decimal>(nullable: false),
                    IssueDate = table.Column<DateTime>(nullable: false),
                    DepCalFromDate = table.Column<DateTime>(nullable: false),
                    AssignTo = table.Column<int>(nullable: false),
                    UsefullLife = table.Column<int>(nullable: false),
                    RemainingYear = table.Column<int>(nullable: false),
                    CurrentStatus = table.Column<string>(nullable: true),
                    IsInActive = table.Column<bool>(nullable: false),
                    EVAULife = table.Column<decimal>(nullable: false),
                    ComId = table.Column<string>(nullable: true),
                    IsDepRunning = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tem_FA_Details", x => x.FA_DetailsId);
                });

            migrationBuilder.CreateTable(
                name: "TemDepSchedules",
                columns: table => new
                {
                    DepreciationScheduleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FA_DetailsId = table.Column<int>(nullable: false),
                    ScheduleDate = table.Column<DateTime>(nullable: false),
                    DepAmount = table.Column<decimal>(nullable: false),
                    AccumulateDepAmount = table.Column<decimal>(nullable: false),
                    AccumulateDepBooked = table.Column<int>(nullable: false),
                    AccumulateDepRemain = table.Column<int>(nullable: false),
                    JournalEntry = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemDepSchedules", x => x.DepreciationScheduleId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tem_FA_Details");

            migrationBuilder.DropTable(
                name: "TemDepSchedules");
        }
    }
}
