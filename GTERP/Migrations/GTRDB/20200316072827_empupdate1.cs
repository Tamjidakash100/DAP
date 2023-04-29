using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class empupdate1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HrEmpInfo_Cat_District_EmpPerDistId",
                table: "HrEmpInfo");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "HrEmpInfo");

            migrationBuilder.DropColumn(
                name: "EmpPhone",
                table: "HrEmpInfo");

            migrationBuilder.DropColumn(
                name: "PhoneNo1",
                table: "HrEmpInfo");

            migrationBuilder.DropColumn(
                name: "PhoneNo2",
                table: "HrEmpInfo");

            migrationBuilder.AlterColumn<int>(
                name: "EmpPerDistId",
                table: "HrEmpInfo",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "EmpPhone1",
                table: "HrEmpInfo",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmpPhone2",
                table: "HrEmpInfo",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FingerId",
                table: "HrEmpInfo",
                maxLength: 40,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UnitId",
                table: "HrEmpInfo",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_HrEmpInfo_UnitId",
                table: "HrEmpInfo",
                column: "UnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_HrEmpInfo_Cat_District_EmpPerDistId",
                table: "HrEmpInfo",
                column: "EmpPerDistId",
                principalTable: "Cat_District",
                principalColumn: "DistId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HrEmpInfo_Cat_Unit_UnitId",
                table: "HrEmpInfo",
                column: "UnitId",
                principalTable: "Cat_Unit",
                principalColumn: "UnitId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HrEmpInfo_Cat_District_EmpPerDistId",
                table: "HrEmpInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_HrEmpInfo_Cat_Unit_UnitId",
                table: "HrEmpInfo");

            migrationBuilder.DropIndex(
                name: "IX_HrEmpInfo_UnitId",
                table: "HrEmpInfo");

            migrationBuilder.DropColumn(
                name: "EmpPhone1",
                table: "HrEmpInfo");

            migrationBuilder.DropColumn(
                name: "EmpPhone2",
                table: "HrEmpInfo");

            migrationBuilder.DropColumn(
                name: "FingerId",
                table: "HrEmpInfo");

            migrationBuilder.DropColumn(
                name: "UnitId",
                table: "HrEmpInfo");

            migrationBuilder.AlterColumn<int>(
                name: "EmpPerDistId",
                table: "HrEmpInfo",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "HrEmpInfo",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmpPhone",
                table: "HrEmpInfo",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNo1",
                table: "HrEmpInfo",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNo2",
                table: "HrEmpInfo",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_HrEmpInfo_Cat_District_EmpPerDistId",
                table: "HrEmpInfo",
                column: "EmpPerDistId",
                principalTable: "Cat_District",
                principalColumn: "DistId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
