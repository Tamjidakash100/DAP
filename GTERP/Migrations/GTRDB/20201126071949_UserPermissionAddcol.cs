using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class UserPermissionAddcol : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAccouonts",
                table: "UserPermission");

            migrationBuilder.AddColumn<bool>(
                name: "IsBillManagement",
                table: "UserPermission",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsCashbankMangement",
                table: "UserPermission",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsGeneralAccouonts",
                table: "UserPermission",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsBillManagement",
                table: "UserPermission");

            migrationBuilder.DropColumn(
                name: "IsCashbankMangement",
                table: "UserPermission");

            migrationBuilder.DropColumn(
                name: "IsGeneralAccouonts",
                table: "UserPermission");

            migrationBuilder.AddColumn<bool>(
                name: "IsAccouonts",
                table: "UserPermission",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
