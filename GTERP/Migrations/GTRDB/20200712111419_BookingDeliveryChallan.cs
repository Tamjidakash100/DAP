using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class BookingDeliveryChallan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booking_MonthNames_MonthNameId",
                table: "Booking");

            migrationBuilder.DropForeignKey(
                name: "FK_Booking_YearNames_YearNameId",
                table: "Booking");

            migrationBuilder.DropForeignKey(
                name: "FK_DistrictWiseBooking_MonthNames_MonthNameId",
                table: "DistrictWiseBooking");

            migrationBuilder.DropForeignKey(
                name: "FK_DistrictWiseBooking_YearNames_YearNameId",
                table: "DistrictWiseBooking");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateAdded",
                table: "Cat_Emp_Type",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdated",
                table: "Cat_Emp_Type",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PcName",
                table: "Cat_Emp_Type",
                maxLength: 60,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdateByUserId",
                table: "Cat_Emp_Type",
                maxLength: 80,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Cat_Emp_Type",
                maxLength: 80,
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Acc_FiscalMonths_MonthNameId",
                table: "Booking",
                column: "MonthNameId",
                principalTable: "Acc_FiscalMonths",
                principalColumn: "FiscalMonthId",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Acc_FiscalYears_YearNameId",
                table: "Booking",
                column: "YearNameId",
                principalTable: "Acc_FiscalYears",
                principalColumn: "FiscalYearId",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_DistrictWiseBooking_Acc_FiscalMonths_MonthNameId",
                table: "DistrictWiseBooking",
                column: "MonthNameId",
                principalTable: "Acc_FiscalMonths",
                principalColumn: "FiscalMonthId",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_DistrictWiseBooking_Acc_FiscalYears_YearNameId",
                table: "DistrictWiseBooking",
                column: "YearNameId",
                principalTable: "Acc_FiscalYears",
                principalColumn: "FiscalYearId",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "DateAdded",
                table: "Cat_Emp_Type");

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "Cat_Emp_Type");

            migrationBuilder.DropColumn(
                name: "PcName",
                table: "Cat_Emp_Type");

            migrationBuilder.DropColumn(
                name: "UpdateByUserId",
                table: "Cat_Emp_Type");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Cat_Emp_Type");

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_MonthNames_MonthNameId",
                table: "Booking",
                column: "MonthNameId",
                principalTable: "MonthNames",
                principalColumn: "MonthNameId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_YearNames_YearNameId",
                table: "Booking",
                column: "YearNameId",
                principalTable: "YearNames",
                principalColumn: "YearNameId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DistrictWiseBooking_MonthNames_MonthNameId",
                table: "DistrictWiseBooking",
                column: "MonthNameId",
                principalTable: "MonthNames",
                principalColumn: "MonthNameId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DistrictWiseBooking_YearNames_YearNameId",
                table: "DistrictWiseBooking",
                column: "YearNameId",
                principalTable: "YearNames",
                principalColumn: "YearNameId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
