using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class intesettinupdatecol : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Remarks",
                table: "Cat_Integration_Setting_Details",
                maxLength: 300,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SelectStatement",
                table: "Cat_Integration_Setting_Details",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WhereCondition",
                table: "Cat_Integration_Setting_Details",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Remarks",
                table: "Cat_Integration_Setting_Details");

            migrationBuilder.DropColumn(
                name: "SelectStatement",
                table: "Cat_Integration_Setting_Details");

            migrationBuilder.DropColumn(
                name: "WhereCondition",
                table: "Cat_Integration_Setting_Details");
        }
    }
}
