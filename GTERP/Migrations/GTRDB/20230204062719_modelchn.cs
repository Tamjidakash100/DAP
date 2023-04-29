using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GTERP.Migrations.GTRDB
{
    public partial class modelchn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.AddForeignKey(
                name: "FK_BuffertWiseBookings_BuferRepresentative_BufferRepresentativeId",
                table: "BuffertWiseBookings",
                column: "BufferRepresentativeId",
                principalTable: "BuferRepresentative",
                principalColumn: "BufferRepresentativeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.AddForeignKey(
                name: "FK_BuffertWiseBookings_BuferRepresentative_BufferRepresentativeId",
                table: "BuffertWiseBookings",
                column: "BufferRepresentativeId",
                principalTable: "BuferRepresentative",
                principalColumn: "BufferRepresentativeId");
        }
    }
}
