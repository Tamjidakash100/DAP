using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class AllLoanTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HR_Loan_MotorCycle",
                columns: table => new
                {
                    LoanMotorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComId = table.Column<string>(maxLength: 80, nullable: true),
                    EmpId = table.Column<int>(nullable: true),
                    LoanType = table.Column<string>(maxLength: 50, nullable: true),
                    DtLoanStart = table.Column<DateTime>(nullable: false),
                    DtLoanEnd = table.Column<DateTime>(nullable: false),
                    LoanAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    LoanTerm = table.Column<float>(nullable: false),
                    InterestRate = table.Column<float>(nullable: false),
                    Compound = table.Column<string>(maxLength: 50, nullable: true),
                    PayBack = table.Column<string>(maxLength: 50, nullable: true),
                    MonthlyLoanAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MonthlyInterest = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TotalLoanAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TotalInterest = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Isinactive = table.Column<bool>(nullable: false),
                    PcName = table.Column<string>(maxLength: 80, nullable: true),
                    UserId = table.Column<string>(maxLength: 80, nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    UpdateByUserId = table.Column<string>(maxLength: 80, nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: true),
                    DtTran = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HR_Loan_MotorCycle", x => x.LoanMotorId);
                    table.ForeignKey(
                        name: "FK_HR_Loan_MotorCycle_HR_Emp_Info_EmpId",
                        column: x => x.EmpId,
                        principalTable: "HR_Emp_Info",
                        principalColumn: "EmpId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HR_Loan_Other",
                columns: table => new
                {
                    LoanOtherId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComId = table.Column<string>(maxLength: 80, nullable: true),
                    EmpId = table.Column<int>(nullable: true),
                    LoanType = table.Column<string>(maxLength: 50, nullable: true),
                    DtLoanStart = table.Column<DateTime>(nullable: false),
                    DtLoanEnd = table.Column<DateTime>(nullable: false),
                    LoanAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    LoanTerm = table.Column<float>(nullable: false),
                    InterestRate = table.Column<float>(nullable: false),
                    Compound = table.Column<string>(maxLength: 50, nullable: true),
                    PayBack = table.Column<string>(maxLength: 50, nullable: true),
                    MonthlyLoanAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MonthlyInterest = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TotalLoanAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TotalInterest = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Isinactive = table.Column<bool>(nullable: false),
                    PcName = table.Column<string>(maxLength: 80, nullable: true),
                    UserId = table.Column<string>(maxLength: 80, nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    UpdateByUserId = table.Column<string>(maxLength: 80, nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: true),
                    DtTran = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HR_Loan_Other", x => x.LoanOtherId);
                    table.ForeignKey(
                        name: "FK_HR_Loan_Other_HR_Emp_Info_EmpId",
                        column: x => x.EmpId,
                        principalTable: "HR_Emp_Info",
                        principalColumn: "EmpId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HR_Loan_PF",
                columns: table => new
                {
                    LoanPFId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComId = table.Column<string>(maxLength: 80, nullable: true),
                    EmpId = table.Column<int>(nullable: true),
                    LoanType = table.Column<string>(maxLength: 50, nullable: true),
                    DtLoanStart = table.Column<DateTime>(nullable: false),
                    DtLoanEnd = table.Column<DateTime>(nullable: false),
                    LoanAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    LoanTerm = table.Column<float>(nullable: false),
                    InterestRate = table.Column<float>(nullable: false),
                    Compound = table.Column<string>(maxLength: 50, nullable: true),
                    PayBack = table.Column<string>(maxLength: 50, nullable: true),
                    MonthlyLoanAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MonthlyInterest = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TotalLoanAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TotalInterest = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Isinactive = table.Column<bool>(nullable: false),
                    PcName = table.Column<string>(maxLength: 80, nullable: true),
                    UserId = table.Column<string>(maxLength: 80, nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    UpdateByUserId = table.Column<string>(maxLength: 80, nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: true),
                    DtTran = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HR_Loan_PF", x => x.LoanPFId);
                    table.ForeignKey(
                        name: "FK_HR_Loan_PF_HR_Emp_Info_EmpId",
                        column: x => x.EmpId,
                        principalTable: "HR_Emp_Info",
                        principalColumn: "EmpId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HR_Loan_Welfare",
                columns: table => new
                {
                    LoanWelId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComId = table.Column<string>(maxLength: 80, nullable: true),
                    EmpId = table.Column<int>(nullable: true),
                    LoanType = table.Column<string>(maxLength: 50, nullable: true),
                    DtLoanStart = table.Column<DateTime>(nullable: false),
                    DtLoanEnd = table.Column<DateTime>(nullable: false),
                    LoanAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    LoanTerm = table.Column<float>(nullable: false),
                    InterestRate = table.Column<float>(nullable: false),
                    Compound = table.Column<string>(maxLength: 50, nullable: true),
                    PayBack = table.Column<string>(maxLength: 50, nullable: true),
                    MonthlyLoanAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MonthlyInterest = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TotalLoanAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TotalInterest = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Isinactive = table.Column<bool>(nullable: false),
                    PcName = table.Column<string>(maxLength: 80, nullable: true),
                    UserId = table.Column<string>(maxLength: 80, nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    UpdateByUserId = table.Column<string>(maxLength: 80, nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: true),
                    DtTran = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HR_Loan_Welfare", x => x.LoanWelId);
                    table.ForeignKey(
                        name: "FK_HR_Loan_Welfare_HR_Emp_Info_EmpId",
                        column: x => x.EmpId,
                        principalTable: "HR_Emp_Info",
                        principalColumn: "EmpId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HR_Loan_Data_MotorCycle",
                columns: table => new
                {
                    LoanDataMotorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComId = table.Column<string>(maxLength: 80, nullable: true),
                    LoanMotorId = table.Column<int>(nullable: true),
                    EmpId = table.Column<int>(nullable: true),
                    DtLoanMonth = table.Column<DateTime>(nullable: false),
                    BeginningLoanBalance = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    InterestAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PrincipalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MonthlyLoanAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    EndingBalance = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    IsPaid = table.Column<bool>(nullable: false),
                    PcName = table.Column<string>(maxLength: 80, nullable: true),
                    UserId = table.Column<string>(maxLength: 80, nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    UpdateByUserId = table.Column<string>(maxLength: 80, nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: true),
                    DtTran = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HR_Loan_Data_MotorCycle", x => x.LoanDataMotorId);
                    table.ForeignKey(
                        name: "FK_HR_Loan_Data_MotorCycle_HR_Emp_Info_EmpId",
                        column: x => x.EmpId,
                        principalTable: "HR_Emp_Info",
                        principalColumn: "EmpId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HR_Loan_Data_MotorCycle_HR_Loan_MotorCycle_LoanMotorId",
                        column: x => x.LoanMotorId,
                        principalTable: "HR_Loan_MotorCycle",
                        principalColumn: "LoanMotorId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HR_Loan_Data_Other",
                columns: table => new
                {
                    LoanDataOtherId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComId = table.Column<string>(maxLength: 80, nullable: true),
                    LoanOtherId = table.Column<int>(nullable: true),
                    EmpId = table.Column<int>(nullable: true),
                    DtLoanMonth = table.Column<DateTime>(nullable: false),
                    BeginningLoanBalance = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    InterestAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PrincipalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MonthlyLoanAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    EndingBalance = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    IsPaid = table.Column<bool>(nullable: false),
                    PcName = table.Column<string>(maxLength: 80, nullable: true),
                    UserId = table.Column<string>(maxLength: 80, nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    UpdateByUserId = table.Column<string>(maxLength: 80, nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: true),
                    DtTran = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HR_Loan_Data_Other", x => x.LoanDataOtherId);
                    table.ForeignKey(
                        name: "FK_HR_Loan_Data_Other_HR_Emp_Info_EmpId",
                        column: x => x.EmpId,
                        principalTable: "HR_Emp_Info",
                        principalColumn: "EmpId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HR_Loan_Data_Other_HR_Loan_Other_LoanOtherId",
                        column: x => x.LoanOtherId,
                        principalTable: "HR_Loan_Other",
                        principalColumn: "LoanOtherId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HR_Loan_Data_PF",
                columns: table => new
                {
                    LoanDataPFId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComId = table.Column<string>(maxLength: 80, nullable: true),
                    LoanPFId = table.Column<int>(nullable: true),
                    EmpId = table.Column<int>(nullable: true),
                    DtLoanMonth = table.Column<DateTime>(nullable: false),
                    BeginningLoanBalance = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    InterestAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PrincipalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MonthlyLoanAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    EndingBalance = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    IsPaid = table.Column<bool>(nullable: false),
                    PcName = table.Column<string>(maxLength: 80, nullable: true),
                    UserId = table.Column<string>(maxLength: 80, nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    UpdateByUserId = table.Column<string>(maxLength: 80, nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: true),
                    DtTran = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HR_Loan_Data_PF", x => x.LoanDataPFId);
                    table.ForeignKey(
                        name: "FK_HR_Loan_Data_PF_HR_Emp_Info_EmpId",
                        column: x => x.EmpId,
                        principalTable: "HR_Emp_Info",
                        principalColumn: "EmpId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HR_Loan_Data_PF_HR_Loan_PF_LoanPFId",
                        column: x => x.LoanPFId,
                        principalTable: "HR_Loan_PF",
                        principalColumn: "LoanPFId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HR_Loan_Data_Welfare",
                columns: table => new
                {
                    LoanDataWelId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComId = table.Column<string>(maxLength: 80, nullable: true),
                    LoanWelId = table.Column<int>(nullable: true),
                    EmpId = table.Column<int>(nullable: true),
                    DtLoanMonth = table.Column<DateTime>(nullable: false),
                    BeginningLoanBalance = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    InterestAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PrincipalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MonthlyLoanAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    EndingBalance = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    IsPaid = table.Column<bool>(nullable: false),
                    PcName = table.Column<string>(maxLength: 80, nullable: true),
                    UserId = table.Column<string>(maxLength: 80, nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    UpdateByUserId = table.Column<string>(maxLength: 80, nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: true),
                    DtTran = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HR_Loan_Data_Welfare", x => x.LoanDataWelId);
                    table.ForeignKey(
                        name: "FK_HR_Loan_Data_Welfare_HR_Emp_Info_EmpId",
                        column: x => x.EmpId,
                        principalTable: "HR_Emp_Info",
                        principalColumn: "EmpId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HR_Loan_Data_Welfare_HR_Loan_Welfare_LoanWelId",
                        column: x => x.LoanWelId,
                        principalTable: "HR_Loan_Welfare",
                        principalColumn: "LoanWelId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HR_Loan_Data_MotorCycle_EmpId",
                table: "HR_Loan_Data_MotorCycle",
                column: "EmpId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Loan_Data_MotorCycle_LoanMotorId",
                table: "HR_Loan_Data_MotorCycle",
                column: "LoanMotorId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Loan_Data_Other_EmpId",
                table: "HR_Loan_Data_Other",
                column: "EmpId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Loan_Data_Other_LoanOtherId",
                table: "HR_Loan_Data_Other",
                column: "LoanOtherId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Loan_Data_PF_EmpId",
                table: "HR_Loan_Data_PF",
                column: "EmpId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Loan_Data_PF_LoanPFId",
                table: "HR_Loan_Data_PF",
                column: "LoanPFId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Loan_Data_Welfare_EmpId",
                table: "HR_Loan_Data_Welfare",
                column: "EmpId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Loan_Data_Welfare_LoanWelId",
                table: "HR_Loan_Data_Welfare",
                column: "LoanWelId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Loan_MotorCycle_EmpId",
                table: "HR_Loan_MotorCycle",
                column: "EmpId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Loan_Other_EmpId",
                table: "HR_Loan_Other",
                column: "EmpId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Loan_PF_EmpId",
                table: "HR_Loan_PF",
                column: "EmpId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Loan_Welfare_EmpId",
                table: "HR_Loan_Welfare",
                column: "EmpId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HR_Loan_Data_MotorCycle");

            migrationBuilder.DropTable(
                name: "HR_Loan_Data_Other");

            migrationBuilder.DropTable(
                name: "HR_Loan_Data_PF");

            migrationBuilder.DropTable(
                name: "HR_Loan_Data_Welfare");

            migrationBuilder.DropTable(
                name: "HR_Loan_MotorCycle");

            migrationBuilder.DropTable(
                name: "HR_Loan_Other");

            migrationBuilder.DropTable(
                name: "HR_Loan_PF");

            migrationBuilder.DropTable(
                name: "HR_Loan_Welfare");
        }
    }
}
