using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class clsqty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "ColosingBagStock",
                table: "Production",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "ColosingSeedStock",
                table: "Production",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ColosingBagStock",
                table: "Production");

            migrationBuilder.DropColumn(
                name: "ColosingSeedStock",
                table: "Production");
        }
    }
}
