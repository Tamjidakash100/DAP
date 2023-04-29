using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class suplimentupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HR_Emp_Suppliment",
                columns: table => new
                {
                    SupplimentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpId = table.Column<int>(nullable: false),
                    DtInput = table.Column<DateTime>(nullable: false),
                    DtFrom = table.Column<DateTime>(nullable: false),
                    DtTo = table.Column<DateTime>(nullable: false),
                    Duration = table.Column<int>(nullable: false),
                    Basic = table.Column<float>(nullable: false),
                    IsBS = table.Column<bool>(nullable: false),
                    IsHR = table.Column<bool>(nullable: false),
                    IsWash = table.Column<bool>(nullable: false),
                    IsMA = table.Column<bool>(nullable: false),
                    IsCPF = table.Column<bool>(nullable: false),
                    IsRisk = table.Column<bool>(nullable: false),
                    IsEdu = table.Column<bool>(nullable: false),
                    IsHRExpDed = table.Column<bool>(nullable: false),
                    Persantage = table.Column<int>(nullable: false),
                    IsOPF = table.Column<bool>(nullable: false),
                    IsAddPF = table.Column<bool>(nullable: false),
                    IsOA = table.Column<bool>(nullable: false),
                    IsWFSub = table.Column<bool>(nullable: false),
                    IsRS = table.Column<bool>(nullable: false),
                    IsHBLoan = table.Column<bool>(nullable: false),
                    IsMCLoan = table.Column<bool>(nullable: false),
                    ComId = table.Column<string>(maxLength: 80, nullable: true),
                    UserId = table.Column<string>(maxLength: 80, nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    UpdateByUserId = table.Column<string>(maxLength: 80, nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HR_Emp_Suppliment", x => x.SupplimentId);
                    table.ForeignKey(
                        name: "FK_HR_Emp_Suppliment_HR_Emp_Info_EmpId",
                        column: x => x.EmpId,
                        principalTable: "HR_Emp_Info",
                        principalColumn: "EmpId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_Suppliment_EmpId",
                table: "HR_Emp_Suppliment",
                column: "EmpId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HR_Emp_Suppliment");
        }
    }
}
