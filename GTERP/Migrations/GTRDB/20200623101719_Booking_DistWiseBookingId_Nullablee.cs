using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class Booking_DistWiseBookingId_Nullablee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booking_DistrictWiseBooking_DistWiseBookingId",
                table: "Booking");

            migrationBuilder.AlterColumn<int>(
                name: "DistWiseBookingId",
                table: "Booking",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_DistrictWiseBooking_DistWiseBookingId",
                table: "Booking",
                column: "DistWiseBookingId",
                principalTable: "DistrictWiseBooking",
                principalColumn: "DistWiseBookingId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booking_DistrictWiseBooking_DistWiseBookingId",
                table: "Booking");

            migrationBuilder.AlterColumn<int>(
                name: "DistWiseBookingId",
                table: "Booking",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_DistrictWiseBooking_DistWiseBookingId",
                table: "Booking",
                column: "DistWiseBookingId",
                principalTable: "DistrictWiseBooking",
                principalColumn: "DistWiseBookingId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
