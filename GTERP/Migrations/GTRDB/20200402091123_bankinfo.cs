using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class bankinfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Donaton",
                table: "HR_Emp_Salary");

            migrationBuilder.DropColumn(
                name: "IsDonaton",
                table: "HR_Emp_Salary");

            migrationBuilder.AddColumn<float>(
                name: "Donation",
                table: "HR_Emp_Salary",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDonation",
                table: "HR_Emp_Salary",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "HR_Emp_BankInfo",
                columns: table => new
                {
                    BankId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpId = table.Column<int>(nullable: false),
                    Paymode = table.Column<string>(maxLength: 30, nullable: true),
                    BankName = table.Column<string>(maxLength: 60, nullable: true),
                    BranchName = table.Column<string>(maxLength: 60, nullable: true),
                    RoutingNumber = table.Column<string>(maxLength: 15, nullable: true),
                    AccountNumber = table.Column<string>(maxLength: 25, nullable: true),
                    AccountName = table.Column<string>(maxLength: 60, nullable: true),
                    AccountType = table.Column<string>(maxLength: 30, nullable: true),
                    IsApproved = table.Column<bool>(maxLength: 30, nullable: false),
                    ComId = table.Column<string>(maxLength: 80, nullable: true),
                    PcName = table.Column<string>(maxLength: 60, nullable: true),
                    UserId = table.Column<string>(maxLength: 80, nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    UpdateByUserId = table.Column<string>(nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HR_Emp_BankInfo", x => x.BankId);
                    table.ForeignKey(
                        name: "FK_HR_Emp_BankInfo_HR_Emp_Info_EmpId",
                        column: x => x.EmpId,
                        principalTable: "HR_Emp_Info",
                        principalColumn: "EmpId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_BankInfo_EmpId",
                table: "HR_Emp_BankInfo",
                column: "EmpId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HR_Emp_BankInfo");

            migrationBuilder.DropColumn(
                name: "Donation",
                table: "HR_Emp_Salary");

            migrationBuilder.DropColumn(
                name: "IsDonation",
                table: "HR_Emp_Salary");

            migrationBuilder.AddColumn<float>(
                name: "Donaton",
                table: "HR_Emp_Salary",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDonaton",
                table: "HR_Emp_Salary",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
