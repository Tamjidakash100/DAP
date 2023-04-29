using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class empupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HrEmpInfo_Cat_Floor_FloorId",
                table: "HrEmpInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_HrEmpInfo_Cat_Grade_GradeId",
                table: "HrEmpInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_HrEmpInfo_Cat_Line_LineId",
                table: "HrEmpInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_HrEmpInfo_Cat_SubSection_SubSectId",
                table: "HrEmpInfo");

            migrationBuilder.AlterColumn<int>(
                name: "SubSectId",
                table: "HrEmpInfo",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Sex",
                table: "HrEmpInfo",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LineId",
                table: "HrEmpInfo",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "GradeId",
                table: "HrEmpInfo",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "FloorId",
                table: "HrEmpInfo",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "EmpType",
                table: "HrEmpInfo",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "HrEmpInfo",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "EmpImage",
                table: "HrEmpInfo",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmpImageExtension",
                table: "HrEmpInfo",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmpImagePath",
                table: "HrEmpInfo",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NID",
                table: "HrEmpInfo",
                maxLength: 40,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNo1",
                table: "HrEmpInfo",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNo2",
                table: "HrEmpInfo",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_HrEmpInfo_Cat_Floor_FloorId",
                table: "HrEmpInfo",
                column: "FloorId",
                principalTable: "Cat_Floor",
                principalColumn: "FloorId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HrEmpInfo_Cat_Grade_GradeId",
                table: "HrEmpInfo",
                column: "GradeId",
                principalTable: "Cat_Grade",
                principalColumn: "GradeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HrEmpInfo_Cat_Line_LineId",
                table: "HrEmpInfo",
                column: "LineId",
                principalTable: "Cat_Line",
                principalColumn: "LineId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HrEmpInfo_Cat_SubSection_SubSectId",
                table: "HrEmpInfo",
                column: "SubSectId",
                principalTable: "Cat_SubSection",
                principalColumn: "SubSectId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HrEmpInfo_Cat_Floor_FloorId",
                table: "HrEmpInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_HrEmpInfo_Cat_Grade_GradeId",
                table: "HrEmpInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_HrEmpInfo_Cat_Line_LineId",
                table: "HrEmpInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_HrEmpInfo_Cat_SubSection_SubSectId",
                table: "HrEmpInfo");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "HrEmpInfo");

            migrationBuilder.DropColumn(
                name: "EmpImage",
                table: "HrEmpInfo");

            migrationBuilder.DropColumn(
                name: "EmpImageExtension",
                table: "HrEmpInfo");

            migrationBuilder.DropColumn(
                name: "EmpImagePath",
                table: "HrEmpInfo");

            migrationBuilder.DropColumn(
                name: "NID",
                table: "HrEmpInfo");

            migrationBuilder.DropColumn(
                name: "PhoneNo1",
                table: "HrEmpInfo");

            migrationBuilder.DropColumn(
                name: "PhoneNo2",
                table: "HrEmpInfo");

            migrationBuilder.AlterColumn<int>(
                name: "SubSectId",
                table: "HrEmpInfo",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Sex",
                table: "HrEmpInfo",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LineId",
                table: "HrEmpInfo",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "GradeId",
                table: "HrEmpInfo",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FloorId",
                table: "HrEmpInfo",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EmpType",
                table: "HrEmpInfo",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_HrEmpInfo_Cat_Floor_FloorId",
                table: "HrEmpInfo",
                column: "FloorId",
                principalTable: "Cat_Floor",
                principalColumn: "FloorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HrEmpInfo_Cat_Grade_GradeId",
                table: "HrEmpInfo",
                column: "GradeId",
                principalTable: "Cat_Grade",
                principalColumn: "GradeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HrEmpInfo_Cat_Line_LineId",
                table: "HrEmpInfo",
                column: "LineId",
                principalTable: "Cat_Line",
                principalColumn: "LineId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HrEmpInfo_Cat_SubSection_SubSectId",
                table: "HrEmpInfo",
                column: "SubSectId",
                principalTable: "Cat_SubSection",
                principalColumn: "SubSectId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
