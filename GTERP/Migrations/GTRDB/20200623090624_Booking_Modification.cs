using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class Booking_Modification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DistrictWiseBooking_Booking_BookingId",
                table: "DistrictWiseBooking");

            migrationBuilder.DropIndex(
                name: "IX_DistrictWiseBooking_BookingId",
                table: "DistrictWiseBooking");

            migrationBuilder.DropColumn(
                name: "BookingId",
                table: "DistrictWiseBooking");

            migrationBuilder.AddColumn<int>(
                name: "DistWiseBookingId",
                table: "Booking",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Booking_DistWiseBookingId",
                table: "Booking",
                column: "DistWiseBookingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_DistrictWiseBooking_DistWiseBookingId",
                table: "Booking",
                column: "DistWiseBookingId",
                principalTable: "DistrictWiseBooking",
                principalColumn: "DistWiseBookingId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booking_DistrictWiseBooking_DistWiseBookingId",
                table: "Booking");

            migrationBuilder.DropIndex(
                name: "IX_Booking_DistWiseBookingId",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "DistWiseBookingId",
                table: "Booking");

            migrationBuilder.AddColumn<int>(
                name: "BookingId",
                table: "DistrictWiseBooking",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_DistrictWiseBooking_BookingId",
                table: "DistrictWiseBooking",
                column: "BookingId");

            migrationBuilder.AddForeignKey(
                name: "FK_DistrictWiseBooking_Booking_BookingId",
                table: "DistrictWiseBooking",
                column: "BookingId",
                principalTable: "Booking",
                principalColumn: "BookingId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
