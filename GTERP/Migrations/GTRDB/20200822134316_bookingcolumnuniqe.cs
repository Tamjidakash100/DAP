using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class bookingcolumnuniqe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Booking_ComId_FiscalYearId_FiscalMonthId_CustomerId",
                table: "Booking",
                columns: new[] { "ComId", "FiscalYearId", "FiscalMonthId", "CustomerId" },
                unique: true,
                filter: "[ComId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Booking_ComId_FiscalYearId_FiscalMonthId_CustomerId",
                table: "Booking");
        }
    }
}
