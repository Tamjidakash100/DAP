using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class agepatient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "Age",
                table: "IssueSub",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Patient",
                table: "IssueSub",
                maxLength: 30,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "IssueSub");

            migrationBuilder.DropColumn(
                name: "Patient",
                table: "IssueSub");
        }
    }
}
