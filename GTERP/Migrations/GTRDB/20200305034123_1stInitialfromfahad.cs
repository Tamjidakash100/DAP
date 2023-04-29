using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class _1stInitialfromfahad : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuPermissionDetails_MenuPermissionMasters_MenuPermission_MastersMenuPermissionId",
                table: "MenuPermissionDetails");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_ModuleMenus_ModuleMenus_ParentId",
            //    table: "ModuleMenus");



            migrationBuilder.DropForeignKey(
                name: "FK_ModuleMenus_ModuleMenus",
                table: "ModuleMenus");

            

            migrationBuilder.DropIndex(
                name: "IX_ModuleMenus_ParentId",
                table: "ModuleMenus");

            migrationBuilder.DropIndex(
                name: "IX_MenuPermissionDetails_MenuPermission_MastersMenuPermissionId",
                table: "MenuPermissionDetails");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "MenuPermissionMasters");

            migrationBuilder.DropColumn(
                name: "MenuPermission_MastersMenuPermissionId",
                table: "MenuPermissionDetails");

            migrationBuilder.AddColumn<int>(
                name: "ParentModuleMenuModuleMenuId",
                table: "ModuleMenus",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ModuleMenus_ModuleMenus_ParentModuleMenuModuleMenuId",
                table: "ModuleMenus");

            migrationBuilder.DropIndex(
                name: "IX_ModuleMenus_ParentModuleMenuModuleMenuId",
                table: "ModuleMenus");

            migrationBuilder.DropColumn(
                name: "ParentModuleMenuModuleMenuId",
                table: "ModuleMenus");

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "MenuPermissionMasters",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "MenuPermission_MastersMenuPermissionId",
                table: "MenuPermissionDetails",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ModuleMenus_ParentId",
                table: "ModuleMenus",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuPermissionDetails_MenuPermission_MastersMenuPermissionId",
                table: "MenuPermissionDetails",
                column: "MenuPermission_MastersMenuPermissionId");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuPermissionDetails_MenuPermissionMasters_MenuPermission_MastersMenuPermissionId",
                table: "MenuPermissionDetails",
                column: "MenuPermission_MastersMenuPermissionId",
                principalTable: "MenuPermissionMasters",
                principalColumn: "MenuPermissionId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ModuleMenus_ModuleMenus_ParentId",
                table: "ModuleMenus",
                column: "ParentId",
                principalTable: "ModuleMenus",
                principalColumn: "ModuleMenuId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
