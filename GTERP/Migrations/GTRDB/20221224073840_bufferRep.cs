using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GTERP.Migrations.GTRDB
{
    public partial class bufferRep : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RepresentativeBuffers_BuferRepresentative_BufferRepresentativeId",
                table: "RepresentativeBuffers");

            migrationBuilder.DropIndex(
                name: "IX_RepresentativeBuffers_BufferRepresentativeId",
                table: "RepresentativeBuffers");

            migrationBuilder.DropColumn(
                name: "BufferRepresentativeId",
                table: "RepresentativeBuffers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BufferRepresentativeId",
                table: "RepresentativeBuffers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RepresentativeBuffers_BufferRepresentativeId",
                table: "RepresentativeBuffers",
                column: "BufferRepresentativeId");

            migrationBuilder.AddForeignKey(
                name: "FK_RepresentativeBuffers_BuferRepresentative_BufferRepresentativeId",
                table: "RepresentativeBuffers",
                column: "BufferRepresentativeId",
                principalTable: "BuferRepresentative",
                principalColumn: "BufferRepresentativeId");
        }
    }
}
