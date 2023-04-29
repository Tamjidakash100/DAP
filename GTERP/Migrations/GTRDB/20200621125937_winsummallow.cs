using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class winsummallow : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "ElectricChargeOther",
                table: "HR_Emp_Salary",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GLId",
                table: "HR_Emp_Salary",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "GasChargeOther",
                table: "HR_Emp_Salary",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsElectricChargeOther",
                table: "HR_Emp_Salary",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsGasChargeOther",
                table: "HR_Emp_Salary",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsWaterChargeOther",
                table: "HR_Emp_Salary",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "PFLLId",
                table: "HR_Emp_Salary",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "WaterChargeOther",
                table: "HR_Emp_Salary",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_Salary_GLId",
                table: "HR_Emp_Salary",
                column: "GLId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_Salary_PFLLId",
                table: "HR_Emp_Salary",
                column: "PFLLId");

            migrationBuilder.AddForeignKey(
                name: "FK_HR_Emp_Salary_Cat_Location_GLId",
                table: "HR_Emp_Salary",
                column: "GLId",
                principalTable: "Cat_Location",
                principalColumn: "LId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HR_Emp_Salary_Cat_Location_PFLLId",
                table: "HR_Emp_Salary",
                column: "PFLLId",
                principalTable: "Cat_Location",
                principalColumn: "LId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HR_Emp_Salary_Cat_Location_GLId",
                table: "HR_Emp_Salary");

            migrationBuilder.DropForeignKey(
                name: "FK_HR_Emp_Salary_Cat_Location_PFLLId",
                table: "HR_Emp_Salary");

            migrationBuilder.DropIndex(
                name: "IX_HR_Emp_Salary_GLId",
                table: "HR_Emp_Salary");

            migrationBuilder.DropIndex(
                name: "IX_HR_Emp_Salary_PFLLId",
                table: "HR_Emp_Salary");

            migrationBuilder.DropColumn(
                name: "ElectricChargeOther",
                table: "HR_Emp_Salary");

            migrationBuilder.DropColumn(
                name: "GLId",
                table: "HR_Emp_Salary");

            migrationBuilder.DropColumn(
                name: "GasChargeOther",
                table: "HR_Emp_Salary");

            migrationBuilder.DropColumn(
                name: "IsElectricChargeOther",
                table: "HR_Emp_Salary");

            migrationBuilder.DropColumn(
                name: "IsGasChargeOther",
                table: "HR_Emp_Salary");

            migrationBuilder.DropColumn(
                name: "IsWaterChargeOther",
                table: "HR_Emp_Salary");

            migrationBuilder.DropColumn(
                name: "PFLLId",
                table: "HR_Emp_Salary");

            migrationBuilder.DropColumn(
                name: "WaterChargeOther",
                table: "HR_Emp_Salary");
        }
    }
}
