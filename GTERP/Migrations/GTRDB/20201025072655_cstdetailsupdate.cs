using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class cstdetailsupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DetailsTableCaption",
                table: "CostAllocation_Details",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "DetailsTablePercentage",
                table: "CostAllocation_Details",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DetailsTableCaption",
                table: "CostAllocation_Details");

            migrationBuilder.DropColumn(
                name: "DetailsTablePercentage",
                table: "CostAllocation_Details");
        }
    }
}
