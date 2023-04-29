using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class shiftinput : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmpMobile",
                table: "HR_Emp_Info");

            migrationBuilder.AlterColumn<string>(
                name: "EmpPerZip",
                table: "HR_Emp_Info",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "HR_Emp_ShiftInput",
                columns: table => new
                {
                    ShiftInputId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComId = table.Column<string>(maxLength: 80, nullable: true),
                    DtDate = table.Column<DateTime>(nullable: false),
                    FromDate = table.Column<DateTime>(nullable: false),
                    ToDate = table.Column<DateTime>(nullable: false),
                    EmpId = table.Column<int>(nullable: false),
                    ShiftId = table.Column<int>(nullable: false),
                    PcName = table.Column<string>(maxLength: 80, nullable: true),
                    UserId = table.Column<string>(maxLength: 80, nullable: true),
                    DtTran = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HR_Emp_ShiftInput", x => x.ShiftInputId);
                    table.ForeignKey(
                        name: "FK_HR_Emp_ShiftInput_HR_Emp_Info_EmpId",
                        column: x => x.EmpId,
                        principalTable: "HR_Emp_Info",
                        principalColumn: "EmpId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HR_Emp_ShiftInput_Cat_Shift_ShiftId",
                        column: x => x.ShiftId,
                        principalTable: "Cat_Shift",
                        principalColumn: "ShiftId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_ShiftInput_EmpId",
                table: "HR_Emp_ShiftInput",
                column: "EmpId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_ShiftInput_ShiftId",
                table: "HR_Emp_ShiftInput",
                column: "ShiftId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HR_Emp_ShiftInput");

            migrationBuilder.AlterColumn<string>(
                name: "EmpPerZip",
                table: "HR_Emp_Info",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmpMobile",
                table: "HR_Emp_Info",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
