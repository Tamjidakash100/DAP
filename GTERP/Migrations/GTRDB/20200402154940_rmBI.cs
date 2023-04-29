using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class rmBI : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HR_Emp_Salary_HR_Emp_Info_EmpId",
                table: "HR_Emp_Salary");

            migrationBuilder.DropForeignKey(
                name: "FK_HR_Emp_Salary_Cat_Location_LId1",
                table: "HR_Emp_Salary");

            migrationBuilder.DropTable(
                name: "HR_Emp_BankInfo");

            migrationBuilder.AlterColumn<int>(
                name: "LId1",
                table: "HR_Emp_Salary",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "EmpId",
                table: "HR_Emp_Salary",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            //migrationBuilder.AddColumn<float>(
            //    name: "FoodAllow",
            //    table: "HR_Emp_Salary",
            //    nullable: true);

            //migrationBuilder.AddColumn<bool>(
            //    name: "IsFa",
            //    table: "HR_Emp_Salary",
            //    nullable: false,
            //    defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_HR_Emp_Salary_HR_Emp_Info_EmpId",
                table: "HR_Emp_Salary",
                column: "EmpId",
                principalTable: "HR_Emp_Info",
                principalColumn: "EmpId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HR_Emp_Salary_Cat_Location_LId1",
                table: "HR_Emp_Salary",
                column: "LId1",
                principalTable: "Cat_Location",
                principalColumn: "LId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HR_Emp_Salary_HR_Emp_Info_EmpId",
                table: "HR_Emp_Salary");

            migrationBuilder.DropForeignKey(
                name: "FK_HR_Emp_Salary_Cat_Location_LId1",
                table: "HR_Emp_Salary");

            //migrationBuilder.DropColumn(
            //    name: "FoodAllow",
            //    table: "HR_Emp_Salary");

            //migrationBuilder.DropColumn(
            //    name: "IsFa",
            //    table: "HR_Emp_Salary");

            migrationBuilder.AlterColumn<int>(
                name: "LId1",
                table: "HR_Emp_Salary",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EmpId",
                table: "HR_Emp_Salary",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "HR_Emp_BankInfo",
                columns: table => new
                {
                    BankId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    AccountNumber = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    AccountType = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    BankName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    BranchName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    ComId = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EmpId = table.Column<int>(type: "int", nullable: false),
                    IsApproved = table.Column<bool>(type: "bit", maxLength: 30, nullable: false),
                    Paymode = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    PcName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    RoutingNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    UpdateByUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true)
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

            migrationBuilder.AddForeignKey(
                name: "FK_HR_Emp_Salary_HR_Emp_Info_EmpId",
                table: "HR_Emp_Salary",
                column: "EmpId",
                principalTable: "HR_Emp_Info",
                principalColumn: "EmpId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HR_Emp_Salary_Cat_Location_LId1",
                table: "HR_Emp_Salary",
                column: "LId1",
                principalTable: "Cat_Location",
                principalColumn: "LId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
