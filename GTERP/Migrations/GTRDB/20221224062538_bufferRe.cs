using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GTERP.Migrations.GTRDB
{
    public partial class bufferRe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RepresentativeBuffers_BuferRepresentative_BufferRepresentativeId",
                table: "RepresentativeBuffers");

            migrationBuilder.AlterColumn<int>(
                name: "BufferRepresentativeId",
                table: "RepresentativeBuffers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "RepresentativeId",
                table: "RepresentativeBuffers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_RepresentativeBuffers_RepresentativeId",
                table: "RepresentativeBuffers",
                column: "RepresentativeId");

            migrationBuilder.AddForeignKey(
                name: "FK_RepresentativeBuffers_BuferRepresentative_BufferRepresentativeId",
                table: "RepresentativeBuffers",
                column: "BufferRepresentativeId",
                principalTable: "BuferRepresentative",
                principalColumn: "BufferRepresentativeId");

            migrationBuilder.AddForeignKey(
                name: "FK_RepresentativeBuffers_Representative_RepresentativeId",
                table: "RepresentativeBuffers",
                column: "RepresentativeId",
                principalTable: "Representative",
                principalColumn: "RepresentativeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RepresentativeBuffers_BuferRepresentative_BufferRepresentativeId",
                table: "RepresentativeBuffers");

            migrationBuilder.DropForeignKey(
                name: "FK_RepresentativeBuffers_Representative_RepresentativeId",
                table: "RepresentativeBuffers");

            migrationBuilder.DropIndex(
                name: "IX_RepresentativeBuffers_RepresentativeId",
                table: "RepresentativeBuffers");

            migrationBuilder.DropColumn(
                name: "RepresentativeId",
                table: "RepresentativeBuffers");

            migrationBuilder.AlterColumn<int>(
                name: "BufferRepresentativeId",
                table: "RepresentativeBuffers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_RepresentativeBuffers_BuferRepresentative_BufferRepresentativeId",
                table: "RepresentativeBuffers",
                column: "BufferRepresentativeId",
                principalTable: "BuferRepresentative",
                principalColumn: "BufferRepresentativeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
