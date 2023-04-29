using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class islockprosslock : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Payroll_SalaryAddition");

            migrationBuilder.AlterColumn<bool>(
                name: "IsLock",
                table: "HR_ProcessLock",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte>(
                name: "IsLock",
                table: "HR_ProcessLock",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(bool));

            migrationBuilder.CreateTable(
                name: "Payroll_SalaryAddition",
                columns: table => new
                {
                    SalAddId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddTypeId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    ComId = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DtInput = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DtJoin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmpId = table.Column<int>(type: "int", nullable: false),
                    PcName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    UpdateByUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payroll_SalaryAddition", x => x.SalAddId);
                    table.ForeignKey(
                        name: "FK_Payroll_SalaryAddition_Cat_Location_AddTypeId",
                        column: x => x.AddTypeId,
                        principalTable: "Cat_Location",
                        principalColumn: "LId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Payroll_SalaryAddition_HR_Emp_Info_EmpId",
                        column: x => x.EmpId,
                        principalTable: "HR_Emp_Info",
                        principalColumn: "EmpId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Payroll_SalaryAddition_AddTypeId",
                table: "Payroll_SalaryAddition",
                column: "AddTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Payroll_SalaryAddition_EmpId",
                table: "Payroll_SalaryAddition",
                column: "EmpId");
        }
    }
}
