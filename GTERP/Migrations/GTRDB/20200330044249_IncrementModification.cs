using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class IncrementModification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BS",
                table: "HR_Emp_Increment");

            migrationBuilder.DropColumn(
                name: "DA",
                table: "HR_Emp_Increment");

            migrationBuilder.DropColumn(
                name: "FA",
                table: "HR_Emp_Increment");

            migrationBuilder.DropColumn(
                name: "HR",
                table: "HR_Emp_Increment");

            migrationBuilder.DropColumn(
                name: "MA",
                table: "HR_Emp_Increment");

            migrationBuilder.DropColumn(
                name: "PA",
                table: "HR_Emp_Increment");

            migrationBuilder.DropColumn(
                name: "TA",
                table: "HR_Emp_Increment");

            migrationBuilder.AddColumn<double>(
                name: "NewBS",
                table: "HR_Emp_Increment",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "NewDA",
                table: "HR_Emp_Increment",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "NewFA",
                table: "HR_Emp_Increment",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "NewHR",
                table: "HR_Emp_Increment",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "NewMA",
                table: "HR_Emp_Increment",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "NewPA",
                table: "HR_Emp_Increment",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "NewTA",
                table: "HR_Emp_Increment",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "OldBS",
                table: "HR_Emp_Increment",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "OldDA",
                table: "HR_Emp_Increment",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "OldFA",
                table: "HR_Emp_Increment",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "OldHR",
                table: "HR_Emp_Increment",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "OldMA",
                table: "HR_Emp_Increment",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "OldPA",
                table: "HR_Emp_Increment",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "OldTA",
                table: "HR_Emp_Increment",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NewBS",
                table: "HR_Emp_Increment");

            migrationBuilder.DropColumn(
                name: "NewDA",
                table: "HR_Emp_Increment");

            migrationBuilder.DropColumn(
                name: "NewFA",
                table: "HR_Emp_Increment");

            migrationBuilder.DropColumn(
                name: "NewHR",
                table: "HR_Emp_Increment");

            migrationBuilder.DropColumn(
                name: "NewMA",
                table: "HR_Emp_Increment");

            migrationBuilder.DropColumn(
                name: "NewPA",
                table: "HR_Emp_Increment");

            migrationBuilder.DropColumn(
                name: "NewTA",
                table: "HR_Emp_Increment");

            migrationBuilder.DropColumn(
                name: "OldBS",
                table: "HR_Emp_Increment");

            migrationBuilder.DropColumn(
                name: "OldDA",
                table: "HR_Emp_Increment");

            migrationBuilder.DropColumn(
                name: "OldFA",
                table: "HR_Emp_Increment");

            migrationBuilder.DropColumn(
                name: "OldHR",
                table: "HR_Emp_Increment");

            migrationBuilder.DropColumn(
                name: "OldMA",
                table: "HR_Emp_Increment");

            migrationBuilder.DropColumn(
                name: "OldPA",
                table: "HR_Emp_Increment");

            migrationBuilder.DropColumn(
                name: "OldTA",
                table: "HR_Emp_Increment");

            migrationBuilder.AddColumn<double>(
                name: "BS",
                table: "HR_Emp_Increment",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "DA",
                table: "HR_Emp_Increment",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "FA",
                table: "HR_Emp_Increment",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "HR",
                table: "HR_Emp_Increment",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "MA",
                table: "HR_Emp_Increment",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "PA",
                table: "HR_Emp_Increment",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TA",
                table: "HR_Emp_Increment",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
