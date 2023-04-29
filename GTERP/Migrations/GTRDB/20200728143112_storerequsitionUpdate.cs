using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class storerequsitionUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StoreRequisitionMain_HR_Emp_Info_ApprovedByEmpId",
                table: "StoreRequisitionMain");

            migrationBuilder.DropForeignKey(
                name: "FK_StoreRequisitionMain_HR_Emp_Info_RecommenedByEmpId",
                table: "StoreRequisitionMain");

            migrationBuilder.AlterColumn<int>(
                name: "RecommenedByEmpId",
                table: "StoreRequisitionMain",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ApprovedByEmpId",
                table: "StoreRequisitionMain",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_StoreRequisitionMain_HR_Emp_Info_ApprovedByEmpId",
                table: "StoreRequisitionMain",
                column: "ApprovedByEmpId",
                principalTable: "HR_Emp_Info",
                principalColumn: "EmpId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StoreRequisitionMain_HR_Emp_Info_RecommenedByEmpId",
                table: "StoreRequisitionMain",
                column: "RecommenedByEmpId",
                principalTable: "HR_Emp_Info",
                principalColumn: "EmpId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StoreRequisitionMain_HR_Emp_Info_ApprovedByEmpId",
                table: "StoreRequisitionMain");

            migrationBuilder.DropForeignKey(
                name: "FK_StoreRequisitionMain_HR_Emp_Info_RecommenedByEmpId",
                table: "StoreRequisitionMain");

            migrationBuilder.AlterColumn<int>(
                name: "RecommenedByEmpId",
                table: "StoreRequisitionMain",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ApprovedByEmpId",
                table: "StoreRequisitionMain",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_StoreRequisitionMain_HR_Emp_Info_ApprovedByEmpId",
                table: "StoreRequisitionMain",
                column: "ApprovedByEmpId",
                principalTable: "HR_Emp_Info",
                principalColumn: "EmpId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StoreRequisitionMain_HR_Emp_Info_RecommenedByEmpId",
                table: "StoreRequisitionMain",
                column: "RecommenedByEmpId",
                principalTable: "HR_Emp_Info",
                principalColumn: "EmpId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
