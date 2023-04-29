using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class HR_Emp_PF_OPBal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HR_Emp_PF_OPBal",
                columns: table => new
                {
                    PFOPBalId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpId = table.Column<int>(nullable: false),
                    PFOwn = table.Column<float>(nullable: false),
                    PFComp = table.Column<float>(nullable: false),
                    PFAdd = table.Column<float>(nullable: false),
                    PFOPBalYID = table.Column<int>(nullable: true),
                    ComId = table.Column<string>(maxLength: 80, nullable: true),
                    PcName = table.Column<string>(maxLength: 60, nullable: true),
                    UserId = table.Column<string>(maxLength: 80, nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    UpdateByUserId = table.Column<string>(maxLength: 80, nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HR_Emp_PF_OPBal", x => x.PFOPBalId);
                    table.ForeignKey(
                        name: "FK_HR_Emp_PF_OPBal_HR_Emp_Info_EmpId",
                        column: x => x.EmpId,
                        principalTable: "HR_Emp_Info",
                        principalColumn: "EmpId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HR_Emp_PF_OPBal_Acc_FiscalYears_PFOPBalYID",
                        column: x => x.PFOPBalYID,
                        principalTable: "Acc_FiscalYears",
                        principalColumn: "FiscalYearId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_PF_OPBal_EmpId",
                table: "HR_Emp_PF_OPBal",
                column: "EmpId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_PF_OPBal_PFOPBalYID",
                table: "HR_Emp_PF_OPBal",
                column: "PFOPBalYID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HR_Emp_PF_OPBal");
        }
    }
}
