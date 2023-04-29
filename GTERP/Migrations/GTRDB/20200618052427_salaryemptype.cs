using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class salaryemptype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmpType",
                table: "Cat_SalarySettings");

            migrationBuilder.AddColumn<int>(
                name: "EmpTypeId",
                table: "Cat_SalarySettings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Cat_SalarySettings_EmpTypeId",
                table: "Cat_SalarySettings",
                column: "EmpTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cat_SalarySettings_Cat_Emp_Type_EmpTypeId",
                table: "Cat_SalarySettings",
                column: "EmpTypeId",
                principalTable: "Cat_Emp_Type",
                principalColumn: "EmpTypeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cat_SalarySettings_Cat_Emp_Type_EmpTypeId",
                table: "Cat_SalarySettings");

            migrationBuilder.DropIndex(
                name: "IX_Cat_SalarySettings_EmpTypeId",
                table: "Cat_SalarySettings");

            migrationBuilder.DropColumn(
                name: "EmpTypeId",
                table: "Cat_SalarySettings");

            migrationBuilder.AddColumn<string>(
                name: "EmpType",
                table: "Cat_SalarySettings",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);
        }
    }
}
