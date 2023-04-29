using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GTERP.Migrations.GTRDB
{
    public partial class BanksModelModify001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BufferId",
                table: "BanksModel",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_BanksModel_BufferId",
                table: "BanksModel",
                column: "BufferId");

            migrationBuilder.AddForeignKey(
                name: "FK_BanksModel_Buffers_BufferId",
                table: "BanksModel",
                column: "BufferId",
                principalTable: "Buffers",
                principalColumn: "BufferListId",
                onUpdate: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BanksModel_Buffers_BufferId",
                table: "BanksModel");

            migrationBuilder.DropIndex(
                name: "IX_BanksModel_BufferId",
                table: "BanksModel");

            migrationBuilder.DropColumn(
                name: "BufferId",
                table: "BanksModel");
        }
    }
}
