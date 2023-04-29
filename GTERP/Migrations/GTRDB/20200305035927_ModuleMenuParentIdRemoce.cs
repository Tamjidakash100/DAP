using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class ModuleMenuParentIdRemoce : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ModuleMenus_ModuleMenus_ParentModuleMenuModuleMenuId",
                table: "ModuleMenus");

            migrationBuilder.DropIndex(
                name: "IX_ModuleMenus_ParentModuleMenuModuleMenuId",
                table: "ModuleMenus");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "ModuleMenus");

            migrationBuilder.DropColumn(
                name: "ParentModuleMenuModuleMenuId",
                table: "ModuleMenus");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ParentId",
                table: "ModuleMenus",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ParentModuleMenuModuleMenuId",
                table: "ModuleMenus",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ModuleMenus_ParentModuleMenuModuleMenuId",
                table: "ModuleMenus",
                column: "ParentModuleMenuModuleMenuId");

            migrationBuilder.AddForeignKey(
                name: "FK_ModuleMenus_ModuleMenus_ParentModuleMenuModuleMenuId",
                table: "ModuleMenus",
                column: "ParentModuleMenuModuleMenuId",
                principalTable: "ModuleMenus",
                principalColumn: "ModuleMenuId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
