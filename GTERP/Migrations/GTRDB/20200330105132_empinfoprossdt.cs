using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class empinfoprossdt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AdJusted",
                table: "HR_ProcessedData",
                maxLength: 2,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ManageType",
                table: "HR_Emp_Info",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdJusted",
                table: "HR_ProcessedData");

            migrationBuilder.DropColumn(
                name: "ManageType",
                table: "HR_Emp_Info");
        }
    }
}
