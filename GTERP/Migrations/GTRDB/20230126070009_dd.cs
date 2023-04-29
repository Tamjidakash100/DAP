using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GTERP.Migrations.GTRDB
{
    public partial class dd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BufferRepresentativeId",
                table: "BuffertWiseBookings",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BuffertWiseBookings_BufferRepresentativeId",
                table: "BuffertWiseBookings",
                column: "BufferRepresentativeId");

            migrationBuilder.AddForeignKey(
                name: "FK_BuffertWiseBookings_BuferRepresentative_BufferRepresentativeId",
                table: "BuffertWiseBookings",
                column: "BufferRepresentativeId",
                principalTable: "BuferRepresentative",
                principalColumn: "BufferRepresentativeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BuffertWiseBookings_BuferRepresentative_BufferRepresentativeId",
                table: "BuffertWiseBookings");

            migrationBuilder.DropIndex(
                name: "IX_BuffertWiseBookings_BufferRepresentativeId",
                table: "BuffertWiseBookings");

            migrationBuilder.DropColumn(
                name: "BufferRepresentativeId",
                table: "BuffertWiseBookings");
        }
    }
}
