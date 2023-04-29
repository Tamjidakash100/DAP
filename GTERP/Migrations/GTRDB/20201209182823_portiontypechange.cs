using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class portiontypechange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PortyionType",
                table: "Acc_GovtSchedule_JapanLoans");

            migrationBuilder.AddColumn<string>(
                name: "PortionType",
                table: "Acc_GovtSchedule_JapanLoans",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PortionType",
                table: "Acc_GovtSchedule_JapanLoans");

            migrationBuilder.AddColumn<string>(
                name: "PortyionType",
                table: "Acc_GovtSchedule_JapanLoans",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
