using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class note2addedinprovision : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Note1",
                table: "GoodsReceiveProvision",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Note2",
                table: "GoodsReceiveProvision",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Note1",
                table: "GoodsReceiveProvision");

            migrationBuilder.DropColumn(
                name: "Note2",
                table: "GoodsReceiveProvision");
        }
    }
}
