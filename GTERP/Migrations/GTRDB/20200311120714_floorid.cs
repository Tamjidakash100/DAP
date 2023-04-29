using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class floorid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Cat_Floor",
                table: "Cat_Floor");

            migrationBuilder.DropColumn(
                name: "LineId",
                table: "Cat_Floor");

            migrationBuilder.AddColumn<int>(
                name: "FloorId",
                table: "Cat_Floor",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cat_Floor",
                table: "Cat_Floor",
                column: "FloorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Cat_Floor",
                table: "Cat_Floor");

            migrationBuilder.DropColumn(
                name: "FloorId",
                table: "Cat_Floor");

            migrationBuilder.AddColumn<int>(
                name: "LineId",
                table: "Cat_Floor",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cat_Floor",
                table: "Cat_Floor",
                column: "LineId");
        }
    }
}
