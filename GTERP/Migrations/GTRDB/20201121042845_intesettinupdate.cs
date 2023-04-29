using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class intesettinupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OtherLineTwo",
                table: "Cat_Integration_Setting_Details");

            migrationBuilder.DropColumn(
                name: "OtherLinkOne",
                table: "Cat_Integration_Setting_Details");

            migrationBuilder.DropColumn(
                name: "PayrollColumnName",
                table: "Cat_Integration_Setting_Details");

            migrationBuilder.AlterColumn<string>(
                name: "PcName",
                table: "Cat_Integration_Setting_Mains",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MainSLNo",
                table: "Cat_Integration_Setting_Mains",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IntegrationTableName",
                table: "Cat_Integration_Setting_Mains",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IntegrationSettingName",
                table: "Cat_Integration_Setting_Mains",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "ComId",
                table: "Cat_Integration_Setting_Mains",
                maxLength: 128,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SLNo",
                table: "Cat_Integration_Setting_Details",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PcName",
                table: "Cat_Integration_Setting_Details",
                maxLength: 128,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ComId",
                table: "Cat_Integration_Setting_Details",
                maxLength: 128,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ColNameFour",
                table: "Cat_Integration_Setting_Details",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ColNameOne",
                table: "Cat_Integration_Setting_Details",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ColNameThree",
                table: "Cat_Integration_Setting_Details",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ColNameTwo",
                table: "Cat_Integration_Setting_Details",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ConditionCount",
                table: "Cat_Integration_Setting_Details",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsSubtract",
                table: "Cat_Integration_Setting_Details",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "SelectColumnNameOne",
                table: "Cat_Integration_Setting_Details",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "colNameFourValue",
                table: "Cat_Integration_Setting_Details",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "colNameOneValue",
                table: "Cat_Integration_Setting_Details",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "colNameThreeValue",
                table: "Cat_Integration_Setting_Details",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "colNameTwoValue",
                table: "Cat_Integration_Setting_Details",
                maxLength: 50,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ColNameFour",
                table: "Cat_Integration_Setting_Details");

            migrationBuilder.DropColumn(
                name: "ColNameOne",
                table: "Cat_Integration_Setting_Details");

            migrationBuilder.DropColumn(
                name: "ColNameThree",
                table: "Cat_Integration_Setting_Details");

            migrationBuilder.DropColumn(
                name: "ColNameTwo",
                table: "Cat_Integration_Setting_Details");

            migrationBuilder.DropColumn(
                name: "ConditionCount",
                table: "Cat_Integration_Setting_Details");

            migrationBuilder.DropColumn(
                name: "IsSubtract",
                table: "Cat_Integration_Setting_Details");

            migrationBuilder.DropColumn(
                name: "SelectColumnNameOne",
                table: "Cat_Integration_Setting_Details");

            migrationBuilder.DropColumn(
                name: "colNameFourValue",
                table: "Cat_Integration_Setting_Details");

            migrationBuilder.DropColumn(
                name: "colNameOneValue",
                table: "Cat_Integration_Setting_Details");

            migrationBuilder.DropColumn(
                name: "colNameThreeValue",
                table: "Cat_Integration_Setting_Details");

            migrationBuilder.DropColumn(
                name: "colNameTwoValue",
                table: "Cat_Integration_Setting_Details");

            migrationBuilder.AlterColumn<string>(
                name: "PcName",
                table: "Cat_Integration_Setting_Mains",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MainSLNo",
                table: "Cat_Integration_Setting_Mains",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IntegrationTableName",
                table: "Cat_Integration_Setting_Mains",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IntegrationSettingName",
                table: "Cat_Integration_Setting_Mains",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "ComId",
                table: "Cat_Integration_Setting_Mains",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 128,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SLNo",
                table: "Cat_Integration_Setting_Details",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PcName",
                table: "Cat_Integration_Setting_Details",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 128,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ComId",
                table: "Cat_Integration_Setting_Details",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 128,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OtherLineTwo",
                table: "Cat_Integration_Setting_Details",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OtherLinkOne",
                table: "Cat_Integration_Setting_Details",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PayrollColumnName",
                table: "Cat_Integration_Setting_Details",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
