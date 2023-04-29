using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class testmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AssignToDept",
                table: "FA_Details",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FA_Details_AssignToDept",
                table: "FA_Details",
                column: "AssignToDept");

            migrationBuilder.AddForeignKey(
                name: "FK_FA_Details_Cat_Department_AssignToDept",
                table: "FA_Details",
                column: "AssignToDept",
                principalTable: "Cat_Department",
                principalColumn: "DeptId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FA_Details_Cat_Department_AssignToDept",
                table: "FA_Details");

            migrationBuilder.DropIndex(
                name: "IX_FA_Details_AssignToDept",
                table: "FA_Details");

            migrationBuilder.DropColumn(
                name: "AssignToDept",
                table: "FA_Details");
        }
    }
}
