using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GTERP.Migrations.GTRDB
{
    public partial class DBIssueBuffer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BufferDelChallan_BufferDelOrder_BufferDelOrderId",
                table: "BufferDelChallan");

            //migrationBuilder.DropIndex(
            //   name: "IX_BufferDelChallan_BufferDelOrderId",
            //   table: "BufferDelChallan");

            migrationBuilder.DropColumn(
                name: "BufferDelOrderId",
                table: "BufferDelChallan");

            //migrationBuilder.RenameColumn(
            //    name: "BufferDelOrderId",
            //    table: "BufferDelChallan",
            //    newName: "RepresentativeBookingId");

            //migrationBuilder.RenameIndex(
            //    name: "IX_BufferDelChallan_BufferDelOrderId",
            //    table: "BufferDelChallan",
            //    newName: "IX_BufferDelChallan_RepresentativeBookingId");

            //migrationBuilder.AddColumn<int>(
            //    name: "Id",
            //    table: "BufferDelChallan",
            //    type: "int",
            //    nullable: false,
            //    defaultValue: 0);

            //migrationBuilder.CreateIndex(
            //    name: "IX_BufferDelChallan_Id",
            //    table: "BufferDelChallan",
            //    column: "Id");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_BufferDelChallan_BufferRepresentativeMember_Id",
            //    table: "BufferDelChallan",
            //    column: "Id",
            //    principalTable: "BufferRepresentativeMember",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_BufferDelChallan_RepresentativeBooking_RepresentativeBookingId",
            //    table: "BufferDelChallan",
            //    column: "RepresentativeBookingId",
            //    principalTable: "RepresentativeBooking",
            //    principalColumn: "RepresentativeBookingId",
            //    onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BufferDelChallan_BufferRepresentativeMember_Id",
                table: "BufferDelChallan");

            migrationBuilder.DropForeignKey(
                name: "FK_BufferDelChallan_RepresentativeBooking_RepresentativeBookingId",
                table: "BufferDelChallan");

            migrationBuilder.DropIndex(
                name: "IX_BufferDelChallan_Id",
                table: "BufferDelChallan");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "BufferDelChallan");

            migrationBuilder.RenameColumn(
                name: "RepresentativeBookingId",
                table: "BufferDelChallan",
                newName: "BufferDelOrderId");

            migrationBuilder.RenameIndex(
                name: "IX_BufferDelChallan_RepresentativeBookingId",
                table: "BufferDelChallan",
                newName: "IX_BufferDelChallan_BufferDelOrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_BufferDelChallan_BufferDelOrder_BufferDelOrderId",
                table: "BufferDelChallan",
                column: "BufferDelOrderId",
                principalTable: "BufferDelOrder",
                principalColumn: "BufferDelOrderId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
