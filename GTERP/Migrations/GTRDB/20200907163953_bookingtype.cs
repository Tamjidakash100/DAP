using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class bookingtype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Booking_ComId_FiscalYearId_FiscalMonthId_CustomerId",
                table: "Booking");

            migrationBuilder.AlterColumn<string>(
                name: "AllotmentType",
                table: "Booking",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Booking_ComId_FiscalYearId_FiscalMonthId_CustomerId_AllotmentType",
                table: "Booking",
                columns: new[] { "ComId", "FiscalYearId", "FiscalMonthId", "CustomerId", "AllotmentType" },
                unique: true,
                filter: "[ComId] IS NOT NULL AND [AllotmentType] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Booking_ComId_FiscalYearId_FiscalMonthId_CustomerId_AllotmentType",
                table: "Booking");

            migrationBuilder.AlterColumn<string>(
                name: "AllotmentType",
                table: "Booking",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Booking_ComId_FiscalYearId_FiscalMonthId_CustomerId",
                table: "Booking",
                columns: new[] { "ComId", "FiscalYearId", "FiscalMonthId", "CustomerId" },
                unique: true,
                filter: "[ComId] IS NOT NULL");
        }
    }
}
