using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class jobcard : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Cat_AttStatusStatusId",
                table: "HR_AttFixed");

            migrationBuilder.DropColumn(
                name: "Cat_ShiftShiftId",
                table: "HR_AttFixed");

            migrationBuilder.DropColumn(
                name: "HR_Emp_InfoEmpId",
                table: "HR_AttFixed");

            migrationBuilder.AlterColumn<int>(
                name: "ShiftId",
                table: "HR_AttFixed",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EmpId",
                table: "HR_AttFixed",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "HR_TempJob",
                columns: table => new
                {
                    ComId = table.Column<string>(nullable: false),
                    ComName = table.Column<string>(nullable: true),
                    ComAdd1 = table.Column<string>(nullable: true),
                    ComAdd2 = table.Column<string>(nullable: true),
                    Caption = table.Column<string>(nullable: true),
                    EmpId = table.Column<long>(nullable: true),
                    EmpCode = table.Column<string>(nullable: true),
                    EmpName = table.Column<string>(nullable: true),
                    BloodGroup = table.Column<string>(nullable: true),
                    Gs = table.Column<decimal>(nullable: false),
                    DesigId = table.Column<short>(nullable: false),
                    DesigName = table.Column<string>(nullable: true),
                    Grade = table.Column<string>(nullable: true),
                    SectId = table.Column<short>(nullable: false),
                    SectName = table.Column<string>(nullable: true),
                    DeptId = table.Column<short>(nullable: true),
                    DeptName = table.Column<string>(nullable: true),
                    Band = table.Column<string>(nullable: true),
                    Floor = table.Column<string>(nullable: true),
                    Line = table.Column<string>(nullable: true),
                    DtJoin = table.Column<string>(nullable: true),
                    DtReleased = table.Column<string>(nullable: true),
                    CardNo = table.Column<string>(nullable: true),
                    Present = table.Column<float>(nullable: false),
                    Absent = table.Column<float>(nullable: false),
                    LateDay = table.Column<float>(nullable: false),
                    Leave = table.Column<float>(nullable: false),
                    Hday = table.Column<float>(nullable: false),
                    Wday = table.Column<float>(nullable: false),
                    LateHrTtl = table.Column<float>(nullable: false),
                    Othr = table.Column<float>(nullable: false),
                    OthrDed = table.Column<float>(nullable: false),
                    OthrsTtl = table.Column<float>(nullable: false),
                    Rot = table.Column<float>(nullable: true),
                    Eot = table.Column<float>(nullable: true),
                    Night = table.Column<float>(nullable: false),
                    Lunch = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HR_TempJob", x => x.ComId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HR_AttFixed_EmpId",
                table: "HR_AttFixed",
                column: "EmpId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_AttFixed_ShiftId",
                table: "HR_AttFixed",
                column: "ShiftId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_AttFixed_StatusId",
                table: "HR_AttFixed",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_HR_AttFixed_HR_Emp_Info_EmpId",
                table: "HR_AttFixed",
                column: "EmpId",
                principalTable: "HR_Emp_Info",
                principalColumn: "EmpId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HR_AttFixed_Cat_Shift_ShiftId",
                table: "HR_AttFixed",
                column: "ShiftId",
                principalTable: "Cat_Shift",
                principalColumn: "ShiftId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HR_AttFixed_Cat_AttStatus_StatusId",
                table: "HR_AttFixed",
                column: "StatusId",
                principalTable: "Cat_AttStatus",
                principalColumn: "StatusId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HR_AttFixed_HR_Emp_Info_EmpId",
                table: "HR_AttFixed");

            migrationBuilder.DropForeignKey(
                name: "FK_HR_AttFixed_Cat_Shift_ShiftId",
                table: "HR_AttFixed");

            migrationBuilder.DropForeignKey(
                name: "FK_HR_AttFixed_Cat_AttStatus_StatusId",
                table: "HR_AttFixed");

            migrationBuilder.DropTable(
                name: "HR_TempJob");

            migrationBuilder.DropIndex(
                name: "IX_HR_AttFixed_EmpId",
                table: "HR_AttFixed");

            migrationBuilder.DropIndex(
                name: "IX_HR_AttFixed_ShiftId",
                table: "HR_AttFixed");

            migrationBuilder.DropIndex(
                name: "IX_HR_AttFixed_StatusId",
                table: "HR_AttFixed");

            migrationBuilder.AlterColumn<int>(
                name: "ShiftId",
                table: "HR_AttFixed",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "EmpId",
                table: "HR_AttFixed",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "Cat_AttStatusStatusId",
                table: "HR_AttFixed",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Cat_ShiftShiftId",
                table: "HR_AttFixed",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HR_Emp_InfoEmpId",
                table: "HR_AttFixed",
                type: "int",
                nullable: true);

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
    }
}
