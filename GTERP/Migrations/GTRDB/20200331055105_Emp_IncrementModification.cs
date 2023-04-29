using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class Emp_IncrementModification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HR_Emp_Increment_HR_Emp_Info_EmpId",
                table: "HR_Emp_Increment");

            migrationBuilder.DropForeignKey(
                name: "FK_HR_Emp_Increment_HR_IncType_IncTypeId",
                table: "HR_Emp_Increment");

            migrationBuilder.DropForeignKey(
                name: "FK_HR_Emp_Increment_Cat_Department_NewDeptId",
                table: "HR_Emp_Increment");

            migrationBuilder.DropForeignKey(
                name: "FK_HR_Emp_Increment_Cat_Designation_NewDesigId",
                table: "HR_Emp_Increment");

            migrationBuilder.DropForeignKey(
                name: "FK_HR_Emp_Increment_Cat_Emp_Type_NewEmpTypeId",
                table: "HR_Emp_Increment");

            migrationBuilder.DropForeignKey(
                name: "FK_HR_Emp_Increment_Cat_Gender_NewGenderId",
                table: "HR_Emp_Increment");

            migrationBuilder.DropForeignKey(
                name: "FK_HR_Emp_Increment_Cat_Section_NewSectId",
                table: "HR_Emp_Increment");

            migrationBuilder.DropForeignKey(
                name: "FK_HR_Emp_Increment_Cat_Unit_NewUnitId",
                table: "HR_Emp_Increment");

            migrationBuilder.DropForeignKey(
                name: "FK_HR_Emp_Increment_Cat_Department_OldDeptId",
                table: "HR_Emp_Increment");

            migrationBuilder.DropForeignKey(
                name: "FK_HR_Emp_Increment_Cat_Designation_OldDesigId",
                table: "HR_Emp_Increment");

            migrationBuilder.DropForeignKey(
                name: "FK_HR_Emp_Increment_Cat_Emp_Type_OldEmpTypeId",
                table: "HR_Emp_Increment");

            migrationBuilder.DropForeignKey(
                name: "FK_HR_Emp_Increment_Cat_Gender_OldGenderId",
                table: "HR_Emp_Increment");

            migrationBuilder.DropForeignKey(
                name: "FK_HR_Emp_Increment_Cat_Section_OldSectId",
                table: "HR_Emp_Increment");

            migrationBuilder.DropForeignKey(
                name: "FK_HR_Emp_Increment_Cat_Unit_OldUnitId",
                table: "HR_Emp_Increment");

            migrationBuilder.DropIndex(
                name: "IX_HR_Emp_Increment_EmpId",
                table: "HR_Emp_Increment");

            //migrationBuilder.AddColumn<string>(
            //    name: "Command",
            //    table: "SalaryProcess",
            //    nullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "Percentage",
                table: "HR_Emp_Increment",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<int>(
                name: "OldUnitId",
                table: "HR_Emp_Increment",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<double>(
                name: "OldTA",
                table: "HR_Emp_Increment",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<int>(
                name: "OldSectId",
                table: "HR_Emp_Increment",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<double>(
                name: "OldSalary",
                table: "HR_Emp_Increment",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<double>(
                name: "OldPA",
                table: "HR_Emp_Increment",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<double>(
                name: "OldMA",
                table: "HR_Emp_Increment",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<double>(
                name: "OldHR",
                table: "HR_Emp_Increment",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<int>(
                name: "OldGenderId",
                table: "HR_Emp_Increment",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<double>(
                name: "OldFA",
                table: "HR_Emp_Increment",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<int>(
                name: "OldEmpTypeId",
                table: "HR_Emp_Increment",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "OldDesigId",
                table: "HR_Emp_Increment",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "OldDeptId",
                table: "HR_Emp_Increment",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<double>(
                name: "OldDA",
                table: "HR_Emp_Increment",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<double>(
                name: "OldBS",
                table: "HR_Emp_Increment",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<int>(
                name: "NewUnitId",
                table: "HR_Emp_Increment",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<double>(
                name: "NewTA",
                table: "HR_Emp_Increment",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<int>(
                name: "NewSectId",
                table: "HR_Emp_Increment",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<double>(
                name: "NewSalary",
                table: "HR_Emp_Increment",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<double>(
                name: "NewPA",
                table: "HR_Emp_Increment",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<double>(
                name: "NewMA",
                table: "HR_Emp_Increment",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<double>(
                name: "NewHR",
                table: "HR_Emp_Increment",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<int>(
                name: "NewGenderId",
                table: "HR_Emp_Increment",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<double>(
                name: "NewFA",
                table: "HR_Emp_Increment",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<int>(
                name: "NewEmpTypeId",
                table: "HR_Emp_Increment",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "NewDesigId",
                table: "HR_Emp_Increment",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "NewDeptId",
                table: "HR_Emp_Increment",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<double>(
                name: "NewDA",
                table: "HR_Emp_Increment",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<double>(
                name: "NewBS",
                table: "HR_Emp_Increment",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<int>(
                name: "IncTypeId",
                table: "HR_Emp_Increment",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "EmpId",
                table: "HR_Emp_Increment",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DtIncrement",
                table: "HR_Emp_Increment",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<double>(
                name: "Amount",
                table: "HR_Emp_Increment",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_Increment_EmpId",
                table: "HR_Emp_Increment",
                column: "EmpId",
                unique: true,
                filter: "[EmpId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_HR_Emp_Increment_HR_Emp_Info_EmpId",
                table: "HR_Emp_Increment",
                column: "EmpId",
                principalTable: "HR_Emp_Info",
                principalColumn: "EmpId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HR_Emp_Increment_HR_IncType_IncTypeId",
                table: "HR_Emp_Increment",
                column: "IncTypeId",
                principalTable: "HR_IncType",
                principalColumn: "IncTypeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HR_Emp_Increment_Cat_Department_NewDeptId",
                table: "HR_Emp_Increment",
                column: "NewDeptId",
                principalTable: "Cat_Department",
                principalColumn: "DeptId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HR_Emp_Increment_Cat_Designation_NewDesigId",
                table: "HR_Emp_Increment",
                column: "NewDesigId",
                principalTable: "Cat_Designation",
                principalColumn: "DesigId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HR_Emp_Increment_Cat_Emp_Type_NewEmpTypeId",
                table: "HR_Emp_Increment",
                column: "NewEmpTypeId",
                principalTable: "Cat_Emp_Type",
                principalColumn: "EmpTypeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HR_Emp_Increment_Cat_Gender_NewGenderId",
                table: "HR_Emp_Increment",
                column: "NewGenderId",
                principalTable: "Cat_Gender",
                principalColumn: "GenderId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HR_Emp_Increment_Cat_Section_NewSectId",
                table: "HR_Emp_Increment",
                column: "NewSectId",
                principalTable: "Cat_Section",
                principalColumn: "SectId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HR_Emp_Increment_Cat_Unit_NewUnitId",
                table: "HR_Emp_Increment",
                column: "NewUnitId",
                principalTable: "Cat_Unit",
                principalColumn: "UnitId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HR_Emp_Increment_Cat_Department_OldDeptId",
                table: "HR_Emp_Increment",
                column: "OldDeptId",
                principalTable: "Cat_Department",
                principalColumn: "DeptId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HR_Emp_Increment_Cat_Designation_OldDesigId",
                table: "HR_Emp_Increment",
                column: "OldDesigId",
                principalTable: "Cat_Designation",
                principalColumn: "DesigId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HR_Emp_Increment_Cat_Emp_Type_OldEmpTypeId",
                table: "HR_Emp_Increment",
                column: "OldEmpTypeId",
                principalTable: "Cat_Emp_Type",
                principalColumn: "EmpTypeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HR_Emp_Increment_Cat_Gender_OldGenderId",
                table: "HR_Emp_Increment",
                column: "OldGenderId",
                principalTable: "Cat_Gender",
                principalColumn: "GenderId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HR_Emp_Increment_Cat_Section_OldSectId",
                table: "HR_Emp_Increment",
                column: "OldSectId",
                principalTable: "Cat_Section",
                principalColumn: "SectId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HR_Emp_Increment_Cat_Unit_OldUnitId",
                table: "HR_Emp_Increment",
                column: "OldUnitId",
                principalTable: "Cat_Unit",
                principalColumn: "UnitId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HR_Emp_Increment_HR_Emp_Info_EmpId",
                table: "HR_Emp_Increment");

            migrationBuilder.DropForeignKey(
                name: "FK_HR_Emp_Increment_HR_IncType_IncTypeId",
                table: "HR_Emp_Increment");

            migrationBuilder.DropForeignKey(
                name: "FK_HR_Emp_Increment_Cat_Department_NewDeptId",
                table: "HR_Emp_Increment");

            migrationBuilder.DropForeignKey(
                name: "FK_HR_Emp_Increment_Cat_Designation_NewDesigId",
                table: "HR_Emp_Increment");

            migrationBuilder.DropForeignKey(
                name: "FK_HR_Emp_Increment_Cat_Emp_Type_NewEmpTypeId",
                table: "HR_Emp_Increment");

            migrationBuilder.DropForeignKey(
                name: "FK_HR_Emp_Increment_Cat_Gender_NewGenderId",
                table: "HR_Emp_Increment");

            migrationBuilder.DropForeignKey(
                name: "FK_HR_Emp_Increment_Cat_Section_NewSectId",
                table: "HR_Emp_Increment");

            migrationBuilder.DropForeignKey(
                name: "FK_HR_Emp_Increment_Cat_Unit_NewUnitId",
                table: "HR_Emp_Increment");

            migrationBuilder.DropForeignKey(
                name: "FK_HR_Emp_Increment_Cat_Department_OldDeptId",
                table: "HR_Emp_Increment");

            migrationBuilder.DropForeignKey(
                name: "FK_HR_Emp_Increment_Cat_Designation_OldDesigId",
                table: "HR_Emp_Increment");

            migrationBuilder.DropForeignKey(
                name: "FK_HR_Emp_Increment_Cat_Emp_Type_OldEmpTypeId",
                table: "HR_Emp_Increment");

            migrationBuilder.DropForeignKey(
                name: "FK_HR_Emp_Increment_Cat_Gender_OldGenderId",
                table: "HR_Emp_Increment");

            migrationBuilder.DropForeignKey(
                name: "FK_HR_Emp_Increment_Cat_Section_OldSectId",
                table: "HR_Emp_Increment");

            migrationBuilder.DropForeignKey(
                name: "FK_HR_Emp_Increment_Cat_Unit_OldUnitId",
                table: "HR_Emp_Increment");

            migrationBuilder.DropIndex(
                name: "IX_HR_Emp_Increment_EmpId",
                table: "HR_Emp_Increment");

            //migrationBuilder.DropColumn(
            //    name: "Command",
            //    table: "SalaryProcess");

            migrationBuilder.AlterColumn<float>(
                name: "Percentage",
                table: "HR_Emp_Increment",
                type: "real",
                nullable: false,
                oldClrType: typeof(float),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OldUnitId",
                table: "HR_Emp_Increment",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "OldTA",
                table: "HR_Emp_Increment",
                type: "float",
                nullable: false,
                oldClrType: typeof(double),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OldSectId",
                table: "HR_Emp_Increment",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "OldSalary",
                table: "HR_Emp_Increment",
                type: "float",
                nullable: false,
                oldClrType: typeof(double),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "OldPA",
                table: "HR_Emp_Increment",
                type: "float",
                nullable: false,
                oldClrType: typeof(double),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "OldMA",
                table: "HR_Emp_Increment",
                type: "float",
                nullable: false,
                oldClrType: typeof(double),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "OldHR",
                table: "HR_Emp_Increment",
                type: "float",
                nullable: false,
                oldClrType: typeof(double),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OldGenderId",
                table: "HR_Emp_Increment",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "OldFA",
                table: "HR_Emp_Increment",
                type: "float",
                nullable: false,
                oldClrType: typeof(double),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OldEmpTypeId",
                table: "HR_Emp_Increment",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OldDesigId",
                table: "HR_Emp_Increment",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OldDeptId",
                table: "HR_Emp_Increment",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "OldDA",
                table: "HR_Emp_Increment",
                type: "float",
                nullable: false,
                oldClrType: typeof(double),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "OldBS",
                table: "HR_Emp_Increment",
                type: "float",
                nullable: false,
                oldClrType: typeof(double),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "NewUnitId",
                table: "HR_Emp_Increment",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "NewTA",
                table: "HR_Emp_Increment",
                type: "float",
                nullable: false,
                oldClrType: typeof(double),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "NewSectId",
                table: "HR_Emp_Increment",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "NewSalary",
                table: "HR_Emp_Increment",
                type: "float",
                nullable: false,
                oldClrType: typeof(double),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "NewPA",
                table: "HR_Emp_Increment",
                type: "float",
                nullable: false,
                oldClrType: typeof(double),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "NewMA",
                table: "HR_Emp_Increment",
                type: "float",
                nullable: false,
                oldClrType: typeof(double),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "NewHR",
                table: "HR_Emp_Increment",
                type: "float",
                nullable: false,
                oldClrType: typeof(double),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "NewGenderId",
                table: "HR_Emp_Increment",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "NewFA",
                table: "HR_Emp_Increment",
                type: "float",
                nullable: false,
                oldClrType: typeof(double),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "NewEmpTypeId",
                table: "HR_Emp_Increment",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "NewDesigId",
                table: "HR_Emp_Increment",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "NewDeptId",
                table: "HR_Emp_Increment",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "NewDA",
                table: "HR_Emp_Increment",
                type: "float",
                nullable: false,
                oldClrType: typeof(double),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "NewBS",
                table: "HR_Emp_Increment",
                type: "float",
                nullable: false,
                oldClrType: typeof(double),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IncTypeId",
                table: "HR_Emp_Increment",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EmpId",
                table: "HR_Emp_Increment",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DtIncrement",
                table: "HR_Emp_Increment",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Amount",
                table: "HR_Emp_Increment",
                type: "float",
                nullable: false,
                oldClrType: typeof(double),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_Increment_EmpId",
                table: "HR_Emp_Increment",
                column: "EmpId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_HR_Emp_Increment_HR_Emp_Info_EmpId",
                table: "HR_Emp_Increment",
                column: "EmpId",
                principalTable: "HR_Emp_Info",
                principalColumn: "EmpId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HR_Emp_Increment_HR_IncType_IncTypeId",
                table: "HR_Emp_Increment",
                column: "IncTypeId",
                principalTable: "HR_IncType",
                principalColumn: "IncTypeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HR_Emp_Increment_Cat_Department_NewDeptId",
                table: "HR_Emp_Increment",
                column: "NewDeptId",
                principalTable: "Cat_Department",
                principalColumn: "DeptId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HR_Emp_Increment_Cat_Designation_NewDesigId",
                table: "HR_Emp_Increment",
                column: "NewDesigId",
                principalTable: "Cat_Designation",
                principalColumn: "DesigId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HR_Emp_Increment_Cat_Emp_Type_NewEmpTypeId",
                table: "HR_Emp_Increment",
                column: "NewEmpTypeId",
                principalTable: "Cat_Emp_Type",
                principalColumn: "EmpTypeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HR_Emp_Increment_Cat_Gender_NewGenderId",
                table: "HR_Emp_Increment",
                column: "NewGenderId",
                principalTable: "Cat_Gender",
                principalColumn: "GenderId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HR_Emp_Increment_Cat_Section_NewSectId",
                table: "HR_Emp_Increment",
                column: "NewSectId",
                principalTable: "Cat_Section",
                principalColumn: "SectId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HR_Emp_Increment_Cat_Unit_NewUnitId",
                table: "HR_Emp_Increment",
                column: "NewUnitId",
                principalTable: "Cat_Unit",
                principalColumn: "UnitId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HR_Emp_Increment_Cat_Department_OldDeptId",
                table: "HR_Emp_Increment",
                column: "OldDeptId",
                principalTable: "Cat_Department",
                principalColumn: "DeptId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HR_Emp_Increment_Cat_Designation_OldDesigId",
                table: "HR_Emp_Increment",
                column: "OldDesigId",
                principalTable: "Cat_Designation",
                principalColumn: "DesigId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HR_Emp_Increment_Cat_Emp_Type_OldEmpTypeId",
                table: "HR_Emp_Increment",
                column: "OldEmpTypeId",
                principalTable: "Cat_Emp_Type",
                principalColumn: "EmpTypeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HR_Emp_Increment_Cat_Gender_OldGenderId",
                table: "HR_Emp_Increment",
                column: "OldGenderId",
                principalTable: "Cat_Gender",
                principalColumn: "GenderId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HR_Emp_Increment_Cat_Section_OldSectId",
                table: "HR_Emp_Increment",
                column: "OldSectId",
                principalTable: "Cat_Section",
                principalColumn: "SectId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HR_Emp_Increment_Cat_Unit_OldUnitId",
                table: "HR_Emp_Increment",
                column: "OldUnitId",
                principalTable: "Cat_Unit",
                principalColumn: "UnitId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
