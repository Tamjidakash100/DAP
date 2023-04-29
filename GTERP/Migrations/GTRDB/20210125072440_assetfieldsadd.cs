using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class assetfieldsadd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AmmoniaReceiving",
                table: "IssueMain",
                maxLength: 300,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhosphoricReceiving",
                table: "IssueMain",
                maxLength: 300,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Qty",
                table: "fA_Sells",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "FA_Details",
                maxLength: 300,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Qty",
                table: "FA_Details",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AmmoniaReceiving",
                table: "IssueMain");

            migrationBuilder.DropColumn(
                name: "PhosphoricReceiving",
                table: "IssueMain");

            migrationBuilder.DropColumn(
                name: "Qty",
                table: "fA_Sells");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "FA_Details");

            migrationBuilder.DropColumn(
                name: "Qty",
                table: "FA_Details");
        }
    }
}
