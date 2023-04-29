using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class FixedAttandenceModification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Cat_AttStatus",
                table: "Cat_AttStatus");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "HR_AttFixed");

            migrationBuilder.DropColumn(
                name: "AId",
                table: "Cat_AttStatus");

            migrationBuilder.AlterColumn<int>(
                name: "ShiftId",
                table: "HR_AttFixed",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "EmpId",
                table: "HR_AttFixed",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Cat_AttStatusStatusId",
                table: "HR_AttFixed",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Cat_ShiftShiftId",
                table: "HR_AttFixed",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HR_Emp_InfoEmpId",
                table: "HR_AttFixed",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "HR_AttFixed",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "Cat_AttStatus",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cat_AttStatus",
                table: "Cat_AttStatus",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_AttFixed_Cat_AttStatusStatusId",
                table: "HR_AttFixed",
                column: "Cat_AttStatusStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_AttFixed_Cat_ShiftShiftId",
                table: "HR_AttFixed",
                column: "Cat_ShiftShiftId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_AttFixed_HR_Emp_InfoEmpId",
                table: "HR_AttFixed",
                column: "HR_Emp_InfoEmpId");

            migrationBuilder.AddForeignKey(
                name: "FK_HR_AttFixed_Cat_AttStatus_Cat_AttStatusStatusId",
                table: "HR_AttFixed",
                column: "Cat_AttStatusStatusId",
                principalTable: "Cat_AttStatus",
                principalColumn: "StatusId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HR_AttFixed_Cat_Shift_Cat_ShiftShiftId",
                table: "HR_AttFixed",
                column: "Cat_ShiftShiftId",
                principalTable: "Cat_Shift",
                principalColumn: "ShiftId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HR_AttFixed_HR_Emp_Info_HR_Emp_InfoEmpId",
                table: "HR_AttFixed",
                column: "HR_Emp_InfoEmpId",
                principalTable: "HR_Emp_Info",
                principalColumn: "EmpId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HR_AttFixed_Cat_AttStatus_Cat_AttStatusStatusId",
                table: "HR_AttFixed");

            migrationBuilder.DropForeignKey(
                name: "FK_HR_AttFixed_Cat_Shift_Cat_ShiftShiftId",
                table: "HR_AttFixed");

            migrationBuilder.DropForeignKey(
                name: "FK_HR_AttFixed_HR_Emp_Info_HR_Emp_InfoEmpId",
                table: "HR_AttFixed");

            migrationBuilder.DropIndex(
                name: "IX_HR_AttFixed_Cat_AttStatusStatusId",
                table: "HR_AttFixed");

            migrationBuilder.DropIndex(
                name: "IX_HR_AttFixed_Cat_ShiftShiftId",
                table: "HR_AttFixed");

            migrationBuilder.DropIndex(
                name: "IX_HR_AttFixed_HR_Emp_InfoEmpId",
                table: "HR_AttFixed");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cat_AttStatus",
                table: "Cat_AttStatus");

            migrationBuilder.DropColumn(
                name: "Cat_AttStatusStatusId",
                table: "HR_AttFixed");

            migrationBuilder.DropColumn(
                name: "Cat_ShiftShiftId",
                table: "HR_AttFixed");

            migrationBuilder.DropColumn(
                name: "HR_Emp_InfoEmpId",
                table: "HR_AttFixed");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "HR_AttFixed");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Cat_AttStatus");

            migrationBuilder.AlterColumn<int>(
                name: "ShiftId",
                table: "HR_AttFixed",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EmpId",
                table: "HR_AttFixed",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "HR_AttFixed",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AId",
                table: "Cat_AttStatus",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cat_AttStatus",
                table: "Cat_AttStatus",
                column: "AId");
        }
    }
}
