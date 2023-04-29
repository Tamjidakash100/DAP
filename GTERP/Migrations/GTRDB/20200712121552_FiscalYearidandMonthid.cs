using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class FiscalYearidandMonthid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Acc_FiscalMonths_MonthNameId",
                table: "Booking");

            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Acc_FiscalYears_YearNameId",
                table: "Booking");

            migrationBuilder.DropForeignKey(
                name: "FK_DistrictWiseBooking_Acc_FiscalMonths_MonthNameId",
                table: "DistrictWiseBooking");

            migrationBuilder.DropForeignKey(
                name: "FK_DistrictWiseBooking_Acc_FiscalYears_YearNameId",
                table: "DistrictWiseBooking");

            migrationBuilder.DropIndex(
                name: "IX_DistrictWiseBooking_MonthNameId",
                table: "DistrictWiseBooking");

            migrationBuilder.DropIndex(
                name: "IX_DistrictWiseBooking_YearNameId",
                table: "DistrictWiseBooking");

            migrationBuilder.DropIndex(
                name: "IX_Booking_MonthNameId",
                table: "Booking");

            migrationBuilder.DropIndex(
                name: "IX_Booking_YearNameId",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "MonthNameId",
                table: "DistrictWiseBooking");

            migrationBuilder.DropColumn(
                name: "YearNameId",
                table: "DistrictWiseBooking");

            migrationBuilder.DropColumn(
                name: "MonthNameId",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "YearNameId",
                table: "Booking");

            migrationBuilder.AddColumn<int>(
                name: "FiscalMonthId",
                table: "DistrictWiseBooking",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FiscalYearId",
                table: "DistrictWiseBooking",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FiscalMonthId",
                table: "Booking",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FiscalYearId",
                table: "Booking",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_DistrictWiseBooking_FiscalMonthId",
                table: "DistrictWiseBooking",
                column: "FiscalMonthId");

            migrationBuilder.CreateIndex(
                name: "IX_DistrictWiseBooking_FiscalYearId",
                table: "DistrictWiseBooking",
                column: "FiscalYearId");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_FiscalMonthId",
                table: "Booking",
                column: "FiscalMonthId");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_FiscalYearId",
                table: "Booking",
                column: "FiscalYearId");

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Acc_FiscalMonths_FiscalMonthId",
                table: "Booking",
                column: "FiscalMonthId",
                principalTable: "Acc_FiscalMonths",
                principalColumn: "FiscalMonthId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Acc_FiscalYears_FiscalYearId",
                table: "Booking",
                column: "FiscalYearId",
                principalTable: "Acc_FiscalYears",
                principalColumn: "FiscalYearId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DistrictWiseBooking_Acc_FiscalMonths_FiscalMonthId",
                table: "DistrictWiseBooking",
                column: "FiscalMonthId",
                principalTable: "Acc_FiscalMonths",
                principalColumn: "FiscalMonthId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DistrictWiseBooking_Acc_FiscalYears_FiscalYearId",
                table: "DistrictWiseBooking",
                column: "FiscalYearId",
                principalTable: "Acc_FiscalYears",
                principalColumn: "FiscalYearId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Acc_FiscalMonths_FiscalMonthId",
                table: "Booking");

            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Acc_FiscalYears_FiscalYearId",
                table: "Booking");

            migrationBuilder.DropForeignKey(
                name: "FK_DistrictWiseBooking_Acc_FiscalMonths_FiscalMonthId",
                table: "DistrictWiseBooking");

            migrationBuilder.DropForeignKey(
                name: "FK_DistrictWiseBooking_Acc_FiscalYears_FiscalYearId",
                table: "DistrictWiseBooking");

            migrationBuilder.DropIndex(
                name: "IX_DistrictWiseBooking_FiscalMonthId",
                table: "DistrictWiseBooking");

            migrationBuilder.DropIndex(
                name: "IX_DistrictWiseBooking_FiscalYearId",
                table: "DistrictWiseBooking");

            migrationBuilder.DropIndex(
                name: "IX_Booking_FiscalMonthId",
                table: "Booking");

            migrationBuilder.DropIndex(
                name: "IX_Booking_FiscalYearId",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "FiscalMonthId",
                table: "DistrictWiseBooking");

            migrationBuilder.DropColumn(
                name: "FiscalYearId",
                table: "DistrictWiseBooking");

            migrationBuilder.DropColumn(
                name: "FiscalMonthId",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "FiscalYearId",
                table: "Booking");

            migrationBuilder.AddColumn<int>(
                name: "MonthNameId",
                table: "DistrictWiseBooking",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "YearNameId",
                table: "DistrictWiseBooking",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MonthNameId",
                table: "Booking",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "YearNameId",
                table: "Booking",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_DistrictWiseBooking_MonthNameId",
                table: "DistrictWiseBooking",
                column: "MonthNameId");

            migrationBuilder.CreateIndex(
                name: "IX_DistrictWiseBooking_YearNameId",
                table: "DistrictWiseBooking",
                column: "YearNameId");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_MonthNameId",
                table: "Booking",
                column: "MonthNameId");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_YearNameId",
                table: "Booking",
                column: "YearNameId");

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Acc_FiscalMonths_MonthNameId",
                table: "Booking",
                column: "MonthNameId",
                principalTable: "Acc_FiscalMonths",
                principalColumn: "FiscalMonthId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Acc_FiscalYears_YearNameId",
                table: "Booking",
                column: "YearNameId",
                principalTable: "Acc_FiscalYears",
                principalColumn: "FiscalYearId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DistrictWiseBooking_Acc_FiscalMonths_MonthNameId",
                table: "DistrictWiseBooking",
                column: "MonthNameId",
                principalTable: "Acc_FiscalMonths",
                principalColumn: "FiscalMonthId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DistrictWiseBooking_Acc_FiscalYears_YearNameId",
                table: "DistrictWiseBooking",
                column: "YearNameId",
                principalTable: "Acc_FiscalYears",
                principalColumn: "FiscalYearId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
