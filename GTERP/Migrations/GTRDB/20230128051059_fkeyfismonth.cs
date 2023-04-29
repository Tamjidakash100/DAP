using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GTERP.Migrations.GTRDB
{
    public partial class fkeyfismonth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BuffertWiseBookings_Acc_FiscalMonths_FiscalMonthId",
                table: "BuffertWiseBookings");

            migrationBuilder.DropIndex(
                name: "IX_BuffertWiseBookings_FiscalMonthId",
                table: "BuffertWiseBookings");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_BuffertWiseBookings_FiscalMonthId",
                table: "BuffertWiseBookings",
                column: "FiscalMonthId");

            migrationBuilder.AddForeignKey(
                name: "FK_BuffertWiseBookings_Acc_FiscalMonths_FiscalMonthId",
                table: "BuffertWiseBookings",
                column: "FiscalMonthId",
                principalTable: "Acc_FiscalMonths",
                principalColumn: "FiscalMonthId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
