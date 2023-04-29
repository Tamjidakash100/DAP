using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GTERP.Migrations.GTRDB
{
    public partial class DC : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BufferDelChallan_BufferDelOrder_BufferDelOrderId",
                table: "BufferDelChallan");

            migrationBuilder.RenameColumn(
                name: "BufferDelOrderId",
                table: "BufferDelChallan",
                newName: "RepresentativeBookingId");

            migrationBuilder.RenameIndex(
                name: "IX_BufferDelChallan_BufferDelOrderId",
                table: "BufferDelChallan",
                newName: "IX_BufferDelChallan_RepresentativeBookingId");

            //migrationBuilder.AddColumn<int>(
            //    name: "BufferDelOrderId1",
            //    table: "BufferDelChallan",
            //    type: "int",
            //    nullable: true);

            //migrationBuilder.CreateIndex(
            //    name: "IX_BufferDelChallan_BufferDelOrderId1",
            //    table: "BufferDelChallan",
            //    column: "BufferDelOrderId1");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_BufferDelChallan_BufferDelOrder_BufferDelOrderId1",
            //    table: "BufferDelChallan",
            //    column: "BufferDelOrderId1",
            //    principalTable: "BufferDelOrder",
            //    principalColumn: "BufferDelOrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_BufferDelChallan_RepresentativeBooking_RepresentativeBookingId",
                table: "BufferDelChallan",
                column: "RepresentativeBookingId",
                principalTable: "RepresentativeBooking",
                principalColumn: "RepresentativeBookingId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BufferDelChallan_BufferDelOrder_BufferDelOrderId1",
                table: "BufferDelChallan");

            migrationBuilder.DropForeignKey(
                name: "FK_BufferDelChallan_RepresentativeBooking_RepresentativeBookingId",
                table: "BufferDelChallan");

            migrationBuilder.DropIndex(
                name: "IX_BufferDelChallan_BufferDelOrderId1",
                table: "BufferDelChallan");

            //migrationBuilder.DropColumn(
            //    name: "BufferDelOrderId1",
            //    table: "BufferDelChallan");

            migrationBuilder.RenameColumn(
                name: "RepresentativeBookingId",
                table: "BufferDelChallan",
                newName: "BufferDelOrderId");

            //migrationBuilder.RenameIndex(
            //    name: "IX_BufferDelChallan_RepresentativeBookingId",
            //    table: "BufferDelChallan",
            //    newName: "IX_BufferDelChallan_BufferDelOrderId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_BufferDelChallan_BufferDelOrder_BufferDelOrderId",
            //    table: "BufferDelChallan",
            //    column: "BufferDelOrderId",
            //    principalTable: "BufferDelOrder",
            //    principalColumn: "BufferDelOrderId",
            //    onDelete: ReferentialAction.Cascade);
        }
    }
}
