using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class SalaryAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Payroll_SalaryAddition",
                columns: table => new
                {
                    SalAddId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpId = table.Column<int>(nullable: false),
                    DtInput = table.Column<string>(nullable: true),
                    DtJoin = table.Column<string>(nullable: true),
                    AddTypeId = table.Column<int>(nullable: false),
                    Amount = table.Column<double>(nullable: false),
                    ComId = table.Column<string>(maxLength: 80, nullable: true),
                    PcName = table.Column<string>(maxLength: 60, nullable: true),
                    UserId = table.Column<string>(maxLength: 80, nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    UpdateByUserId = table.Column<string>(nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: true)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Payroll_SalaryAddition");
        }
    }
}
