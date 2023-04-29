using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class DeliveryorderOldDONO : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_DeliveryOrder_ComId_DONo",
                table: "DeliveryOrder",
                columns: new[] { "ComId", "DONo" },
                unique: true,
                filter: "[ComId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_DeliveryOrder_ComId_DONo",
                table: "DeliveryOrder");
        }
    }
}
