using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class DistrictWiseBooking_Modification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MonthNameId",
                table: "DistrictWiseBooking",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "YearNameId",
                table: "DistrictWiseBooking",
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

            migrationBuilder.AddForeignKey(
                name: "FK_DistrictWiseBooking_MonthNames_MonthNameId",
                table: "DistrictWiseBooking",
                column: "MonthNameId",
                principalTable: "MonthNames",
                principalColumn: "MonthNameId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DistrictWiseBooking_YearNames_YearNameId",
                table: "DistrictWiseBooking",
                column: "YearNameId",
                principalTable: "YearNames",
                principalColumn: "YearNameId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DistrictWiseBooking_MonthNames_MonthNameId",
                table: "DistrictWiseBooking");

            migrationBuilder.DropForeignKey(
                name: "FK_DistrictWiseBooking_YearNames_YearNameId",
                table: "DistrictWiseBooking");

            migrationBuilder.DropIndex(
                name: "IX_DistrictWiseBooking_MonthNameId",
                table: "DistrictWiseBooking");

            migrationBuilder.DropIndex(
                name: "IX_DistrictWiseBooking_YearNameId",
                table: "DistrictWiseBooking");

            migrationBuilder.DropColumn(
                name: "MonthNameId",
                table: "DistrictWiseBooking");

            migrationBuilder.DropColumn(
                name: "YearNameId",
                table: "DistrictWiseBooking");
        }
    }
}
