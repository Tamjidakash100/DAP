using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class Booking_and_SummerWinterAllow_Modification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GumbootAllow",
                table: "HR_SummerWinterAllowance");

            migrationBuilder.DropColumn(
                name: "RainCoatAllow",
                table: "HR_SummerWinterAllowance");

            migrationBuilder.DropColumn(
                name: "BookingNo",
                table: "Booking");

            migrationBuilder.AddColumn<float>(
                name: "RainCoatAndGumbootAllow",
                table: "HR_SummerWinterAllowance",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "SummerAllow",
                table: "HR_SummerWinterAllowance",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BookingId",
                table: "DistrictWiseBooking",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<float>(
                name: "AllotmentQty",
                table: "Booking",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DistrictWiseBooking_Booking_BookingId",
                table: "DistrictWiseBooking");

            migrationBuilder.DropIndex(
                name: "IX_DistrictWiseBooking_BookingId",
                table: "DistrictWiseBooking");

            migrationBuilder.DropColumn(
                name: "RainCoatAndGumbootAllow",
                table: "HR_SummerWinterAllowance");

            migrationBuilder.DropColumn(
                name: "SummerAllow",
                table: "HR_SummerWinterAllowance");

            migrationBuilder.DropColumn(
                name: "BookingId",
                table: "DistrictWiseBooking");

            migrationBuilder.AddColumn<float>(
                name: "GumbootAllow",
                table: "HR_SummerWinterAllowance",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "RainCoatAllow",
                table: "HR_SummerWinterAllowance",
                type: "real",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AllotmentQty",
                table: "Booking",
                type: "int",
                nullable: false,
                oldClrType: typeof(float));

            migrationBuilder.AddColumn<int>(
                name: "BookingNo",
                table: "Booking",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
