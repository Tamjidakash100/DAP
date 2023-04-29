using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GTERP.Migrations.GTRDB
{
    public partial class bufferRepMem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RepresentativeBuffers_Representative_RepresentativeId",
                table: "RepresentativeBuffers");

            migrationBuilder.RenameColumn(
                name: "RepresentativeId",
                table: "RepresentativeBuffers",
                newName: "BufferRepresentativeId");

            migrationBuilder.RenameIndex(
                name: "IX_RepresentativeBuffers_RepresentativeId",
                table: "RepresentativeBuffers",
                newName: "IX_RepresentativeBuffers_BufferRepresentativeId");

            migrationBuilder.CreateTable(
                name: "BufferRepresentativeMember",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BufferRepresentativeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BufferRepresentativeMember", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BufferRepresentativeMember_BuferRepresentative_BufferRepresentativeId",
                        column: x => x.BufferRepresentativeId,
                        principalTable: "BuferRepresentative",
                        principalColumn: "BufferRepresentativeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BufferRepresentativeMember_BufferRepresentativeId",
                table: "BufferRepresentativeMember",
                column: "BufferRepresentativeId");

            migrationBuilder.AddForeignKey(
                name: "FK_RepresentativeBuffers_BuferRepresentative_BufferRepresentativeId",
                table: "RepresentativeBuffers",
                column: "BufferRepresentativeId",
                principalTable: "BuferRepresentative",
                principalColumn: "BufferRepresentativeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RepresentativeBuffers_BuferRepresentative_BufferRepresentativeId",
                table: "RepresentativeBuffers");

            migrationBuilder.DropTable(
                name: "BufferRepresentativeMember");

            migrationBuilder.RenameColumn(
                name: "BufferRepresentativeId",
                table: "RepresentativeBuffers",
                newName: "RepresentativeId");

            migrationBuilder.RenameIndex(
                name: "IX_RepresentativeBuffers_BufferRepresentativeId",
                table: "RepresentativeBuffers",
                newName: "IX_RepresentativeBuffers_RepresentativeId");

            migrationBuilder.AddForeignKey(
                name: "FK_RepresentativeBuffers_Representative_RepresentativeId",
                table: "RepresentativeBuffers",
                column: "RepresentativeId",
                principalTable: "Representative",
                principalColumn: "RepresentativeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
