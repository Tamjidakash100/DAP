using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class PerfectModulemenuList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ModuleMenuClassi",
                table: "ModuleMenus",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ParentId",
                table: "ModuleMenus",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ModuleMenus_ParentId",
                table: "ModuleMenus",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_ModuleMenus_ModuleMenus_ParentId",
                table: "ModuleMenus",
                column: "ParentId",
                principalTable: "ModuleMenus",
                principalColumn: "ModuleMenuId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ModuleMenus_ModuleMenus_ParentId",
                table: "ModuleMenus");

            migrationBuilder.DropIndex(
                name: "IX_ModuleMenus_ParentId",
                table: "ModuleMenus");

            migrationBuilder.DropColumn(
                name: "ModuleMenuClassi",
                table: "ModuleMenus");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "ModuleMenus");
        }
    }
}
