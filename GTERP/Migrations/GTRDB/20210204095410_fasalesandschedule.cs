using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class fasalesandschedule : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "MRRDate",
                table: "fA_Sells",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MRRNo",
                table: "fA_Sells",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Rate",
                table: "fA_Sells",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SalesDate",
                table: "fA_Sells",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "VoucherDate",
                table: "fA_Sells",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VoucherNo",
                table: "fA_Sells",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "MRRDate",
                table: "FA_Details",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MRRNo",
                table: "FA_Details",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Rate",
                table: "FA_Details",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "VoucherDate",
                table: "FA_Details",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VoucherNo",
                table: "FA_Details",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Rate",
                table: "DepreciationSchedules",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VoucherNo",
                table: "DepreciationSchedules",
                maxLength: 100,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DepreciationScheduleSales",
                columns: table => new
                {
                    DepreciationScheduleSaleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FA_DetailsId = table.Column<int>(nullable: false),
                    ScheduleDate = table.Column<DateTime>(nullable: false),
                    DepAmount = table.Column<decimal>(nullable: false),
                    AccumulateDepAmount = table.Column<decimal>(nullable: false),
                    AccumulateDepBooked = table.Column<int>(nullable: false),
                    AccumulateDepRemain = table.Column<int>(nullable: false),
                    JournalEntry = table.Column<bool>(nullable: false),
                    VoucherNo = table.Column<string>(maxLength: 100, nullable: true),
                    Rate = table.Column<decimal>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepreciationScheduleSales", x => x.DepreciationScheduleSaleId);
                    table.ForeignKey(
                        name: "FK_DepreciationScheduleSales_FA_Details_FA_DetailsId",
                        column: x => x.FA_DetailsId,
                        principalTable: "FA_Details",
                        principalColumn: "FA_DetailsId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DepreciationScheduleSales_FA_DetailsId",
                table: "DepreciationScheduleSales",
                column: "FA_DetailsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DepreciationScheduleSales");

            migrationBuilder.DropColumn(
                name: "MRRDate",
                table: "fA_Sells");

            migrationBuilder.DropColumn(
                name: "MRRNo",
                table: "fA_Sells");

            migrationBuilder.DropColumn(
                name: "Rate",
                table: "fA_Sells");

            migrationBuilder.DropColumn(
                name: "SalesDate",
                table: "fA_Sells");

            migrationBuilder.DropColumn(
                name: "VoucherDate",
                table: "fA_Sells");

            migrationBuilder.DropColumn(
                name: "VoucherNo",
                table: "fA_Sells");

            migrationBuilder.DropColumn(
                name: "MRRDate",
                table: "FA_Details");

            migrationBuilder.DropColumn(
                name: "MRRNo",
                table: "FA_Details");

            migrationBuilder.DropColumn(
                name: "Rate",
                table: "FA_Details");

            migrationBuilder.DropColumn(
                name: "VoucherDate",
                table: "FA_Details");

            migrationBuilder.DropColumn(
                name: "VoucherNo",
                table: "FA_Details");

            migrationBuilder.DropColumn(
                name: "Rate",
                table: "DepreciationSchedules");

            migrationBuilder.DropColumn(
                name: "VoucherNo",
                table: "DepreciationSchedules");
        }
    }
}
