using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class Writtendownvaluecolumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FA_Details_HR_Emp_Info_AssignTo",
                table: "FA_Details");

            migrationBuilder.AlterColumn<int>(
                name: "AssignTo",
                table: "FA_Details",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<decimal>(
                name: "AccumulatedDepreciatedValue",
                table: "FA_Details",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "WrittenDownValue",
                table: "FA_Details",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddForeignKey(
                name: "FK_FA_Details_HR_Emp_Info_AssignTo",
                table: "FA_Details",
                column: "AssignTo",
                principalTable: "HR_Emp_Info",
                principalColumn: "EmpId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FA_Details_HR_Emp_Info_AssignTo",
                table: "FA_Details");

            migrationBuilder.DropColumn(
                name: "AccumulatedDepreciatedValue",
                table: "FA_Details");

            migrationBuilder.DropColumn(
                name: "WrittenDownValue",
                table: "FA_Details");

            migrationBuilder.AlterColumn<int>(
                name: "AssignTo",
                table: "FA_Details",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_FA_Details_HR_Emp_Info_AssignTo",
                table: "FA_Details",
                column: "AssignTo",
                principalTable: "HR_Emp_Info",
                principalColumn: "EmpId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
