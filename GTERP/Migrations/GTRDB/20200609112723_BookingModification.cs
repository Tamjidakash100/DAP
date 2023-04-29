using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class BookingModification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Customers_CustomerId",
                table: "Booking");

            migrationBuilder.DropForeignKey(
                name: "FK_Booking_MonthNames_MonthNameId",
                table: "Booking");

            migrationBuilder.DropForeignKey(
                name: "FK_Booking_YearNames_YearNameId",
                table: "Booking");

            migrationBuilder.AlterColumn<int>(
                name: "YearNameId",
                table: "Booking",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MonthNameId",
                table: "Booking",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "Booking",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Cat_DistrictDistId",
                table: "Booking",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Cat_PoliceStationPStationId",
                table: "Booking",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DistId",
                table: "Booking",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PStationId",
                table: "Booking",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Booking_Cat_DistrictDistId",
                table: "Booking",
                column: "Cat_DistrictDistId");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_Cat_PoliceStationPStationId",
                table: "Booking",
                column: "Cat_PoliceStationPStationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Cat_District_Cat_DistrictDistId",
                table: "Booking",
                column: "Cat_DistrictDistId",
                principalTable: "Cat_District",
                principalColumn: "DistId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Cat_PoliceStation_Cat_PoliceStationPStationId",
                table: "Booking",
                column: "Cat_PoliceStationPStationId",
                principalTable: "Cat_PoliceStation",
                principalColumn: "PStationId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Customers_CustomerId",
                table: "Booking",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Cat_District_Cat_DistrictDistId",
                table: "Booking");

            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Cat_PoliceStation_Cat_PoliceStationPStationId",
                table: "Booking");

            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Customers_CustomerId",
                table: "Booking");

            migrationBuilder.DropForeignKey(
                name: "FK_Booking_MonthNames_MonthNameId",
                table: "Booking");

            migrationBuilder.DropForeignKey(
                name: "FK_Booking_YearNames_YearNameId",
                table: "Booking");

            migrationBuilder.DropIndex(
                name: "IX_Booking_Cat_DistrictDistId",
                table: "Booking");

            migrationBuilder.DropIndex(
                name: "IX_Booking_Cat_PoliceStationPStationId",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "Cat_DistrictDistId",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "Cat_PoliceStationPStationId",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "DistId",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "PStationId",
                table: "Booking");

            migrationBuilder.AlterColumn<int>(
                name: "YearNameId",
                table: "Booking",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "MonthNameId",
                table: "Booking",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "Booking",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Customers_CustomerId",
                table: "Booking",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_MonthNames_MonthNameId",
                table: "Booking",
                column: "MonthNameId",
                principalTable: "MonthNames",
                principalColumn: "MonthNameId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_YearNames_YearNameId",
                table: "Booking",
                column: "YearNameId",
                principalTable: "YearNames",
                principalColumn: "YearNameId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
