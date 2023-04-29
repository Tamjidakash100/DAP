using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GTERP.Migrations.GTRDB
{
    public partial class bufferdelcha1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RepresentativeMemberId",
                table: "BufferDelChallan",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_BufferDelChallan_RepresentativeMemberId",
                table: "BufferDelChallan",
                column: "RepresentativeMemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_BufferDelChallan_BufferRepresentativeMember_RepresentativeMemberId",
                table: "BufferDelChallan",
                column: "RepresentativeMemberId",
                principalTable: "BufferRepresentativeMember",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BufferDelChallan_BufferRepresentativeMember_RepresentativeMemberId",
                table: "BufferDelChallan");

            migrationBuilder.DropIndex(
                name: "IX_BufferDelChallan_RepresentativeMemberId",
                table: "BufferDelChallan");

            migrationBuilder.DropColumn(
                name: "RepresentativeMemberId",
                table: "BufferDelChallan");
        }
    }
}
