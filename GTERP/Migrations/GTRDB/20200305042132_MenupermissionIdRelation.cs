using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class MenupermissionIdRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_MenuPermissionDetails_MenuPermissionId",
                table: "MenuPermissionDetails",
                column: "MenuPermissionId");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuPermissionDetails_MenuPermissionMasters_MenuPermissionId",
                table: "MenuPermissionDetails",
                column: "MenuPermissionId",
                principalTable: "MenuPermissionMasters",
                principalColumn: "MenuPermissionId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuPermissionDetails_MenuPermissionMasters_MenuPermissionId",
                table: "MenuPermissionDetails");

            migrationBuilder.DropIndex(
                name: "IX_MenuPermissionDetails_MenuPermissionId",
                table: "MenuPermissionDetails");
        }
    }
}
