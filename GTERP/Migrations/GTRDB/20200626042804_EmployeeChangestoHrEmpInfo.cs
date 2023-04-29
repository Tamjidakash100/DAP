using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class EmployeeChangestoHrEmpInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseRequisitionMain_Employee_ApprovedByEmpId",
                table: "PurchaseRequisitionMain");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseRequisitionMain_Employee_RecommenedByEmpId",
                table: "PurchaseRequisitionMain");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseRequisitionMain_HR_Emp_Info_ApprovedByEmpId",
                table: "PurchaseRequisitionMain",
                column: "ApprovedByEmpId",
                principalTable: "HR_Emp_Info",
                principalColumn: "EmpId",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseRequisitionMain_HR_Emp_Info_RecommenedByEmpId",
                table: "PurchaseRequisitionMain",
                column: "RecommenedByEmpId",
                principalTable: "HR_Emp_Info",
                principalColumn: "EmpId",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseRequisitionMain_HR_Emp_Info_ApprovedByEmpId",
                table: "PurchaseRequisitionMain");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseRequisitionMain_HR_Emp_Info_RecommenedByEmpId",
                table: "PurchaseRequisitionMain");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseRequisitionMain_Employee_ApprovedByEmpId",
                table: "PurchaseRequisitionMain",
                column: "ApprovedByEmpId",
                principalTable: "Employee",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseRequisitionMain_Employee_RecommenedByEmpId",
                table: "PurchaseRequisitionMain",
                column: "RecommenedByEmpId",
                principalTable: "Employee",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
