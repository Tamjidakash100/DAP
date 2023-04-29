using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GTERP.Migrations.GTRDB
{
    public partial class bufferdelcha : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_BufferDelChallan_BufferRepresentativeMember_Id",
            //    table: "BufferDelChallan");

            migrationBuilder.DropIndex(
                name: "IX_BufferDelChallan_Id",
                table: "BufferDelChallan");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "BufferDelChallan");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "BufferDelChallan",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_BufferDelChallan_Id",
                table: "BufferDelChallan",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BufferDelChallan_BufferRepresentativeMember_Id",
                table: "BufferDelChallan",
                column: "Id",
                principalTable: "BufferRepresentativeMember",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
