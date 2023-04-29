using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class SectionModify : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CostSect",
                table: "Sections");

            migrationBuilder.DropColumn(
                name: "CostSectTotal",
                table: "Sections");

            migrationBuilder.DropColumn(
                name: "CostSubSect",
                table: "Sections");

            migrationBuilder.DropColumn(
                name: "DeptName",
                table: "Sections");

            migrationBuilder.DropColumn(
                name: "EmpIdSrtName",
                table: "Sections");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<short>(
                name: "CostSect",
                table: "Sections",
                type: "smallint",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "CostSectTotal",
                table: "Sections",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<short>(
                name: "CostSubSect",
                table: "Sections",
                type: "smallint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeptName",
                table: "Sections",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmpIdSrtName",
                table: "Sections",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
