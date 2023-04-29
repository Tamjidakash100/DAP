using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class loanreturntype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HR_Loan_Return",
                columns: table => new
                {
                    LoanReturnId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpId = table.Column<int>(nullable: false),
                    DtInput = table.Column<DateTime>(nullable: false),
                    DtJoin = table.Column<DateTime>(nullable: false),
                    LoanType = table.Column<string>(maxLength: 100, nullable: true),
                    Amount = table.Column<double>(nullable: false),
                    ComId = table.Column<string>(maxLength: 80, nullable: true),
                    PcName = table.Column<string>(maxLength: 60, nullable: true),
                    UserId = table.Column<string>(maxLength: 80, nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    UpdateByUserId = table.Column<string>(maxLength: 80, nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HR_Loan_Return", x => x.LoanReturnId);
                    table.ForeignKey(
                        name: "FK_HR_Loan_Return_HR_Emp_Info_EmpId",
                        column: x => x.EmpId,
                        principalTable: "HR_Emp_Info",
                        principalColumn: "EmpId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HR_Loan_Return_EmpId",
                table: "HR_Loan_Return",
                column: "EmpId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HR_Loan_Return");
        }
    }
}
