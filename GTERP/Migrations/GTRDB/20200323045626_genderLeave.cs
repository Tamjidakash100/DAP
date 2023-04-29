using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class genderLeave : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BuildingNo",
                table: "HR_Emp_PersonalInfo");

            migrationBuilder.DropColumn(
                name: "Sex",
                table: "HR_Emp_Info");

            migrationBuilder.AlterColumn<string>(
                name: "UpdateByUserId",
                table: "HR_Leave_Avail",
                maxLength: 80,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "TotalDay",
                table: "HR_Leave_Avail",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PcName",
                table: "HR_Leave_Avail",
                maxLength: 60,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "LvApp",
                table: "HR_Leave_Avail",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<int>(
                name: "LTypeId",
                table: "HR_Leave_Avail",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "HR_Emp_PersonalInfo",
                maxLength: 80,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PcName",
                table: "HR_Emp_PersonalInfo",
                maxLength: 60,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ComId",
                table: "HR_Emp_PersonalInfo",
                maxLength: 80,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BId",
                table: "HR_Emp_PersonalInfo",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GenderId",
                table: "HR_Emp_Info",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Cat_BuildingType",
                maxLength: 80,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdateByUserId",
                table: "Cat_BuildingType",
                maxLength: 80,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PcName",
                table: "Cat_BuildingType",
                maxLength: 60,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ComId",
                table: "Cat_BuildingType",
                maxLength: 80,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Cat_Gender",
                columns: table => new
                {
                    GenderId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenderName = table.Column<string>(maxLength: 30, nullable: true),
                    GenderNameB = table.Column<string>(maxLength: 30, nullable: true),
                    ComId = table.Column<string>(maxLength: 80, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cat_Gender", x => x.GenderId);
                });

            migrationBuilder.CreateTable(
                name: "Cat_Leave_Type",
                columns: table => new
                {
                    LTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LTypeName = table.Column<string>(maxLength: 25, nullable: false),
                    LTypeNameShort = table.Column<string>(maxLength: 5, nullable: true),
                    LDays = table.Column<float>(nullable: true),
                    ComId = table.Column<string>(maxLength: 80, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cat_Leave_Type", x => x.LTypeId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HR_Leave_Avail_LTypeId",
                table: "HR_Leave_Avail",
                column: "LTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_PersonalInfo_BId",
                table: "HR_Emp_PersonalInfo",
                column: "BId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_Info_GenderId",
                table: "HR_Emp_Info",
                column: "GenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_HR_Emp_Info_Cat_Gender_GenderId",
                table: "HR_Emp_Info",
                column: "GenderId",
                principalTable: "Cat_Gender",
                principalColumn: "GenderId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HR_Emp_PersonalInfo_Cat_BuildingType_BId",
                table: "HR_Emp_PersonalInfo",
                column: "BId",
                principalTable: "Cat_BuildingType",
                principalColumn: "BId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HR_Leave_Avail_Cat_Leave_Type_LTypeId",
                table: "HR_Leave_Avail",
                column: "LTypeId",
                principalTable: "Cat_Leave_Type",
                principalColumn: "LTypeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HR_Emp_Info_Cat_Gender_GenderId",
                table: "HR_Emp_Info");

            migrationBuilder.DropForeignKey(
                name: "FK_HR_Emp_PersonalInfo_Cat_BuildingType_BId",
                table: "HR_Emp_PersonalInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_HR_Leave_Avail_Cat_Leave_Type_LTypeId",
                table: "HR_Leave_Avail");

            migrationBuilder.DropTable(
                name: "Cat_Gender");

            migrationBuilder.DropTable(
                name: "Cat_Leave_Type");

            migrationBuilder.DropIndex(
                name: "IX_HR_Leave_Avail_LTypeId",
                table: "HR_Leave_Avail");

            migrationBuilder.DropIndex(
                name: "IX_HR_Emp_PersonalInfo_BId",
                table: "HR_Emp_PersonalInfo");

            migrationBuilder.DropIndex(
                name: "IX_HR_Emp_Info_GenderId",
                table: "HR_Emp_Info");

            migrationBuilder.DropColumn(
                name: "LTypeId",
                table: "HR_Leave_Avail");

            migrationBuilder.DropColumn(
                name: "BId",
                table: "HR_Emp_PersonalInfo");

            migrationBuilder.DropColumn(
                name: "GenderId",
                table: "HR_Emp_Info");

            migrationBuilder.AlterColumn<string>(
                name: "UpdateByUserId",
                table: "HR_Leave_Avail",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 80,
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "TotalDay",
                table: "HR_Leave_Avail",
                type: "float",
                nullable: true,
                oldClrType: typeof(float),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PcName",
                table: "HR_Leave_Avail",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 60,
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "LvApp",
                table: "HR_Leave_Avail",
                type: "float",
                nullable: false,
                oldClrType: typeof(float));

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "HR_Emp_PersonalInfo",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 80,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PcName",
                table: "HR_Emp_PersonalInfo",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 60,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ComId",
                table: "HR_Emp_PersonalInfo",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 80,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BuildingNo",
                table: "HR_Emp_PersonalInfo",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Sex",
                table: "HR_Emp_Info",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Cat_BuildingType",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 80,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdateByUserId",
                table: "Cat_BuildingType",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 80,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PcName",
                table: "Cat_BuildingType",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 60,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ComId",
                table: "Cat_BuildingType",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 80,
                oldNullable: true);
        }
    }
}
