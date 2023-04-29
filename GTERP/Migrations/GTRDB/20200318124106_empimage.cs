using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class empimage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Approved",
                table: "HR_Emp_Info");

            migrationBuilder.DropColumn(
                name: "BankAcNo",
                table: "HR_Emp_Info");

            migrationBuilder.DropColumn(
                name: "BankId",
                table: "HR_Emp_Info");

            migrationBuilder.DropColumn(
                name: "BirthCertNo",
                table: "HR_Emp_Info");

            migrationBuilder.DropColumn(
                name: "CardNo",
                table: "HR_Emp_Info");

            migrationBuilder.DropColumn(
                name: "CardNoOld",
                table: "HR_Emp_Info");

            migrationBuilder.DropColumn(
                name: "Caste",
                table: "HR_Emp_Info");

            migrationBuilder.DropColumn(
                name: "ChildF",
                table: "HR_Emp_Info");

            migrationBuilder.DropColumn(
                name: "ChildM",
                table: "HR_Emp_Info");

            migrationBuilder.DropColumn(
                name: "ChildNo",
                table: "HR_Emp_Info");

            migrationBuilder.DropColumn(
                name: "ConfDay",
                table: "HR_Emp_Info");

            migrationBuilder.DropColumn(
                name: "DtApprove",
                table: "HR_Emp_Info");

            migrationBuilder.DropColumn(
                name: "DtCardAssign",
                table: "HR_Emp_Info");

            migrationBuilder.DropColumn(
                name: "DtMarrige",
                table: "HR_Emp_Info");

            migrationBuilder.DropColumn(
                name: "DtReleased",
                table: "HR_Emp_Info");

            migrationBuilder.DropColumn(
                name: "DtTransport",
                table: "HR_Emp_Info");

            migrationBuilder.DropColumn(
                name: "EduLvl",
                table: "HR_Emp_Info");

            migrationBuilder.DropColumn(
                name: "EmergencyMob",
                table: "HR_Emp_Info");

            migrationBuilder.DropColumn(
                name: "EmergencyName",
                table: "HR_Emp_Info");

            migrationBuilder.DropColumn(
                name: "EmpCatagory",
                table: "HR_Emp_Info");

            migrationBuilder.DropColumn(
                name: "EmpCategory",
                table: "HR_Emp_Info");

            migrationBuilder.DropColumn(
                name: "EmpCurrCity",
                table: "HR_Emp_Info");

            migrationBuilder.DropColumn(
                name: "EmpCurrDist",
                table: "HR_Emp_Info");

            migrationBuilder.DropColumn(
                name: "EmpCurrZip",
                table: "HR_Emp_Info");

            migrationBuilder.DropColumn(
                name: "EmpFather",
                table: "HR_Emp_Info");

            migrationBuilder.DropColumn(
                name: "EmpHblocation",
                table: "HR_Emp_Info");

            migrationBuilder.DropColumn(
                name: "EmpImage",
                table: "HR_Emp_Info");

            migrationBuilder.DropColumn(
                name: "EmpImageExtension",
                table: "HR_Emp_Info");

            migrationBuilder.DropColumn(
                name: "EmpImagePath",
                table: "HR_Emp_Info");

            migrationBuilder.DropColumn(
                name: "EmpMclocation",
                table: "HR_Emp_Info");

            migrationBuilder.DropColumn(
                name: "EmpMother",
                table: "HR_Emp_Info");

            migrationBuilder.DropColumn(
                name: "EmpNomineeMob",
                table: "HR_Emp_Info");

            migrationBuilder.DropColumn(
                name: "EmpNomineeName",
                table: "HR_Emp_Info");

            migrationBuilder.DropColumn(
                name: "EmpPerDist",
                table: "HR_Emp_Info");

            migrationBuilder.DropColumn(
                name: "EmpPflocation",
                table: "HR_Emp_Info");

            migrationBuilder.DropColumn(
                name: "EmpPicLocation",
                table: "HR_Emp_Info");

            migrationBuilder.DropColumn(
                name: "EmpRef",
                table: "HR_Emp_Info");

            migrationBuilder.DropColumn(
                name: "EmpRefMob",
                table: "HR_Emp_Info");

            migrationBuilder.DropColumn(
                name: "EmpSpouse",
                table: "HR_Emp_Info");

            migrationBuilder.DropColumn(
                name: "EmpSts",
                table: "HR_Emp_Info");

            migrationBuilder.DropColumn(
                name: "EmpWflocation",
                table: "HR_Emp_Info");

            migrationBuilder.DropColumn(
                name: "EmployementType",
                table: "HR_Emp_Info");

            migrationBuilder.DropColumn(
                name: "Fpid",
                table: "HR_Emp_Info");

            migrationBuilder.DropColumn(
                name: "IsAcc",
                table: "HR_Emp_Info");

            migrationBuilder.DropColumn(
                name: "IsAllowOt",
                table: "HR_Emp_Info");

            migrationBuilder.DropColumn(
                name: "IsAllowPf",
                table: "HR_Emp_Info");

            migrationBuilder.DropColumn(
                name: "IsConfirm",
                table: "HR_Emp_Info");

            migrationBuilder.DropColumn(
                name: "IsContract",
                table: "HR_Emp_Info");

            migrationBuilder.DropColumn(
                name: "IsDisabled",
                table: "HR_Emp_Info");

            migrationBuilder.DropColumn(
                name: "IsNid",
                table: "HR_Emp_Info");

            migrationBuilder.DropColumn(
                name: "IsTax",
                table: "HR_Emp_Info");

            migrationBuilder.DropColumn(
                name: "MaritalSts",
                table: "HR_Emp_Info");

            migrationBuilder.DropColumn(
                name: "Nationality",
                table: "HR_Emp_Info");

            migrationBuilder.DropColumn(
                name: "NickName",
                table: "HR_Emp_Info");

            migrationBuilder.DropColumn(
                name: "OldEmpId",
                table: "HR_Emp_Info");

            migrationBuilder.DropColumn(
                name: "PassportNo",
                table: "HR_Emp_Info");

            migrationBuilder.DropColumn(
                name: "PayMode",
                table: "HR_Emp_Info");

            migrationBuilder.DropColumn(
                name: "PaySource",
                table: "HR_Emp_Info");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "HR_Emp_Info");

            migrationBuilder.DropColumn(
                name: "VoterNo",
                table: "HR_Emp_Info");

            migrationBuilder.DropColumn(
                name: "WeekDayId",
                table: "HR_Emp_Info");

            migrationBuilder.DropColumn(
                name: "WorkPlace",
                table: "HR_Emp_Info");

            migrationBuilder.DropColumn(
                name: "WorkType",
                table: "HR_Emp_Info");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "HR_Emp_Info",
                maxLength: 80,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PcName",
                table: "HR_Emp_Info",
                maxLength: 60,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EmpEmail",
                table: "HR_Emp_Info",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ComId",
                table: "HR_Emp_Info",
                maxLength: 80,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "HR_Emp_Image",
                columns: table => new
                {
                    EmpImageId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpId = table.Column<int>(nullable: false),
                    EmpImage = table.Column<byte[]>(nullable: true),
                    EmpImagePath = table.Column<string>(nullable: true),
                    EmpImageExtension = table.Column<string>(nullable: true),
                    ComId = table.Column<string>(maxLength: 80, nullable: true),
                    PcName = table.Column<string>(maxLength: 60, nullable: true),
                    UserId = table.Column<string>(maxLength: 80, nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    UpdateByUserId = table.Column<string>(nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HR_Emp_Image", x => x.EmpImageId);
                    table.ForeignKey(
                        name: "FK_HR_Emp_Image_HR_Emp_Info_EmpId",
                        column: x => x.EmpId,
                        principalTable: "HR_Emp_Info",
                        principalColumn: "EmpId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_Image_EmpId",
                table: "HR_Emp_Image",
                column: "EmpId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HR_Emp_Image");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "HR_Emp_Info",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 80,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PcName",
                table: "HR_Emp_Info",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 60,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EmpEmail",
                table: "HR_Emp_Info",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ComId",
                table: "HR_Emp_Info",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 80,
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Approved",
                table: "HR_Emp_Info",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "BankAcNo",
                table: "HR_Emp_Info",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BankId",
                table: "HR_Emp_Info",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "BirthCertNo",
                table: "HR_Emp_Info",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CardNo",
                table: "HR_Emp_Info",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CardNoOld",
                table: "HR_Emp_Info",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Caste",
                table: "HR_Emp_Info",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "ChildF",
                table: "HR_Emp_Info",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "ChildM",
                table: "HR_Emp_Info",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<int>(
                name: "ChildNo",
                table: "HR_Emp_Info",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ConfDay",
                table: "HR_Emp_Info",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DtApprove",
                table: "HR_Emp_Info",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DtCardAssign",
                table: "HR_Emp_Info",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DtMarrige",
                table: "HR_Emp_Info",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DtReleased",
                table: "HR_Emp_Info",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DtTransport",
                table: "HR_Emp_Info",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EduLvl",
                table: "HR_Emp_Info",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmergencyMob",
                table: "HR_Emp_Info",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmergencyName",
                table: "HR_Emp_Info",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmpCatagory",
                table: "HR_Emp_Info",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmpCategory",
                table: "HR_Emp_Info",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmpCurrCity",
                table: "HR_Emp_Info",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmpCurrDist",
                table: "HR_Emp_Info",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmpCurrZip",
                table: "HR_Emp_Info",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmpFather",
                table: "HR_Emp_Info",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmpHblocation",
                table: "HR_Emp_Info",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "EmpImage",
                table: "HR_Emp_Info",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmpImageExtension",
                table: "HR_Emp_Info",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmpImagePath",
                table: "HR_Emp_Info",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmpMclocation",
                table: "HR_Emp_Info",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmpMother",
                table: "HR_Emp_Info",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmpNomineeMob",
                table: "HR_Emp_Info",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmpNomineeName",
                table: "HR_Emp_Info",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmpPerDist",
                table: "HR_Emp_Info",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmpPflocation",
                table: "HR_Emp_Info",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmpPicLocation",
                table: "HR_Emp_Info",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmpRef",
                table: "HR_Emp_Info",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmpRefMob",
                table: "HR_Emp_Info",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmpSpouse",
                table: "HR_Emp_Info",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmpSts",
                table: "HR_Emp_Info",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmpWflocation",
                table: "HR_Emp_Info",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmployementType",
                table: "HR_Emp_Info",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Fpid",
                table: "HR_Emp_Info",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsAcc",
                table: "HR_Emp_Info",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsAllowOt",
                table: "HR_Emp_Info",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsAllowPf",
                table: "HR_Emp_Info",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsConfirm",
                table: "HR_Emp_Info",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsContract",
                table: "HR_Emp_Info",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDisabled",
                table: "HR_Emp_Info",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsNid",
                table: "HR_Emp_Info",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsTax",
                table: "HR_Emp_Info",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "MaritalSts",
                table: "HR_Emp_Info",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nationality",
                table: "HR_Emp_Info",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NickName",
                table: "HR_Emp_Info",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OldEmpId",
                table: "HR_Emp_Info",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PassportNo",
                table: "HR_Emp_Info",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PayMode",
                table: "HR_Emp_Info",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaySource",
                table: "HR_Emp_Info",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "HR_Emp_Info",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VoterNo",
                table: "HR_Emp_Info",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "WeekDayId",
                table: "HR_Emp_Info",
                type: "tinyint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WorkPlace",
                table: "HR_Emp_Info",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WorkType",
                table: "HR_Emp_Info",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
