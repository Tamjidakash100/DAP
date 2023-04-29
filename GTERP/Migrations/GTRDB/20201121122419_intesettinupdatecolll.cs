using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class intesettinupdatecolll : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "SLNo",
                table: "Cat_Integration_Setting_Details",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ColNameFourGroupBy",
                table: "Cat_Integration_Setting_Details",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ColNameOneGroupBy",
                table: "Cat_Integration_Setting_Details",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ColNameThreeGroupBy",
                table: "Cat_Integration_Setting_Details",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ColNameTwoGroupBy",
                table: "Cat_Integration_Setting_Details",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GroupByCondition",
                table: "Cat_Integration_Setting_Details",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ColNameFourGroupBy",
                table: "Cat_Integration_Setting_Details");

            migrationBuilder.DropColumn(
                name: "ColNameOneGroupBy",
                table: "Cat_Integration_Setting_Details");

            migrationBuilder.DropColumn(
                name: "ColNameThreeGroupBy",
                table: "Cat_Integration_Setting_Details");

            migrationBuilder.DropColumn(
                name: "ColNameTwoGroupBy",
                table: "Cat_Integration_Setting_Details");

            migrationBuilder.DropColumn(
                name: "GroupByCondition",
                table: "Cat_Integration_Setting_Details");

            migrationBuilder.AlterColumn<string>(
                name: "SLNo",
                table: "Cat_Integration_Setting_Details",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
