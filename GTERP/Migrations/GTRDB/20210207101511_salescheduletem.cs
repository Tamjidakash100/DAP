using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class salescheduletem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DepCalFromDate",
                table: "fA_Sells",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "Tem_FA_Sell",
                columns: table => new
                {
                    FA_SellId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FA_DetailsId = table.Column<int>(nullable: false),
                    FA_MasterId = table.Column<int>(nullable: false),
                    SellsPrice = table.Column<decimal>(nullable: false),
                    CostPrice = table.Column<decimal>(nullable: true),
                    Qty = table.Column<decimal>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    MRRNo = table.Column<string>(maxLength: 100, nullable: true),
                    MRRDate = table.Column<DateTime>(nullable: true),
                    VoucherNo = table.Column<string>(maxLength: 100, nullable: true),
                    VoucherDate = table.Column<DateTime>(nullable: true),
                    Rate = table.Column<decimal>(nullable: true),
                    SalesDate = table.Column<DateTime>(nullable: false),
                    DepCalFromDate = table.Column<DateTime>(nullable: false),
                    IsInActive = table.Column<bool>(nullable: false),
                    IsDepRunning = table.Column<bool>(nullable: false),
                    FA_Dep_StatusId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tem_FA_Sell", x => x.FA_SellId);
                });

            migrationBuilder.CreateTable(
                name: "TemDepScheduleSales",
                columns: table => new
                {
                    DepreciationScheduleSaleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FA_SellId = table.Column<int>(nullable: false),
                    ScheduleDate = table.Column<DateTime>(nullable: false),
                    DepAmount = table.Column<decimal>(nullable: false),
                    AccumulateDepAmount = table.Column<decimal>(nullable: false),
                    AccumulateDepBooked = table.Column<int>(nullable: false),
                    AccumulateDepRemain = table.Column<int>(nullable: false),
                    JournalEntry = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemDepScheduleSales", x => x.DepreciationScheduleSaleId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tem_FA_Sell");

            migrationBuilder.DropTable(
                name: "TemDepScheduleSales");

            migrationBuilder.DropColumn(
                name: "DepCalFromDate",
                table: "fA_Sells");
        }
    }
}
