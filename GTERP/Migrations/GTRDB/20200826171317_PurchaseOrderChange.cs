using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class PurchaseOrderChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IssueMain_Cat_SubSection_SubSectId",
                table: "IssueMain");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseOrderMain_Cat_SubSection_SubSectId",
                table: "PurchaseOrderMain");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseOrderValidMains_Cat_SubSection_SubSectId",
                table: "PurchaseOrderValidMains");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseRequisitionMain_HR_Emp_Info_ApprovedByEmpId",
                table: "PurchaseRequisitionMain");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseRequisitionMain_HR_Emp_Info_RecommenedByEmpId",
                table: "PurchaseRequisitionMain");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseOrderValidMains_SubSectId",
                table: "PurchaseOrderValidMains");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseOrderMain_SubSectId",
                table: "PurchaseOrderMain");

            migrationBuilder.DropIndex(
                name: "IX_IssueMain_SubSectId",
                table: "IssueMain");

            migrationBuilder.DropColumn(
                name: "SubSectId",
                table: "PurchaseOrderValidMains");

            migrationBuilder.DropColumn(
                name: "ExpectedReciveDate",
                table: "PurchaseOrderMain");

            migrationBuilder.DropColumn(
                name: "ExpectedReciveDatestring",
                table: "PurchaseOrderMain");

            migrationBuilder.DropColumn(
                name: "GateInHouseDate",
                table: "PurchaseOrderMain");

            migrationBuilder.DropColumn(
                name: "GateInHouseDatestring",
                table: "PurchaseOrderMain");

            migrationBuilder.DropColumn(
                name: "SubSectId",
                table: "PurchaseOrderMain");

            migrationBuilder.DropColumn(
                name: "SubSectId",
                table: "IssueMain");

            migrationBuilder.AddColumn<int>(
                name: "DistId",
                table: "Suppliers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PStationId",
                table: "Suppliers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SLNo",
                table: "Suppliers",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RecommenedByEmpId",
                table: "PurchaseRequisitionMain",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ApprovedByEmpId",
                table: "PurchaseRequisitionMain",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "FiscalYearId",
                table: "PurchaseOrderValidMains",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastDateOfDelivery",
                table: "PurchaseOrderValidMains",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "SectId",
                table: "PurchaseOrderValidMains",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpectedRecivedDate",
                table: "PurchaseOrderMain",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FiscalYearId",
                table: "PurchaseOrderMain",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastDateOfDelivery",
                table: "PurchaseOrderMain",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "SectId",
                table: "PurchaseOrderMain",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SectId",
                table: "IssueMain",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_DistId",
                table: "Suppliers",
                column: "DistId");

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_PStationId",
                table: "Suppliers",
                column: "PStationId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderValidMains_FiscalYearId",
                table: "PurchaseOrderValidMains",
                column: "FiscalYearId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderValidMains_SectId",
                table: "PurchaseOrderValidMains",
                column: "SectId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderMain_FiscalYearId",
                table: "PurchaseOrderMain",
                column: "FiscalYearId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderMain_SectId",
                table: "PurchaseOrderMain",
                column: "SectId");

            migrationBuilder.CreateIndex(
                name: "IX_IssueMain_SectId",
                table: "IssueMain",
                column: "SectId");

            migrationBuilder.AddForeignKey(
                name: "FK_IssueMain_Cat_Section_SectId",
                table: "IssueMain",
                column: "SectId",
                principalTable: "Cat_Section",
                principalColumn: "SectId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseOrderMain_Acc_FiscalYears_FiscalYearId",
                table: "PurchaseOrderMain",
                column: "FiscalYearId",
                principalTable: "Acc_FiscalYears",
                principalColumn: "FiscalYearId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseOrderMain_Cat_Section_SectId",
                table: "PurchaseOrderMain",
                column: "SectId",
                principalTable: "Cat_Section",
                principalColumn: "SectId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseOrderValidMains_Acc_FiscalYears_FiscalYearId",
                table: "PurchaseOrderValidMains",
                column: "FiscalYearId",
                principalTable: "Acc_FiscalYears",
                principalColumn: "FiscalYearId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseOrderValidMains_Cat_Section_SectId",
                table: "PurchaseOrderValidMains",
                column: "SectId",
                principalTable: "Cat_Section",
                principalColumn: "SectId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseRequisitionMain_HR_Emp_Info_ApprovedByEmpId",
                table: "PurchaseRequisitionMain",
                column: "ApprovedByEmpId",
                principalTable: "HR_Emp_Info",
                principalColumn: "EmpId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseRequisitionMain_HR_Emp_Info_RecommenedByEmpId",
                table: "PurchaseRequisitionMain",
                column: "RecommenedByEmpId",
                principalTable: "HR_Emp_Info",
                principalColumn: "EmpId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Suppliers_Cat_District_DistId",
                table: "Suppliers",
                column: "DistId",
                principalTable: "Cat_District",
                principalColumn: "DistId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Suppliers_Cat_PoliceStation_PStationId",
                table: "Suppliers",
                column: "PStationId",
                principalTable: "Cat_PoliceStation",
                principalColumn: "PStationId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IssueMain_Cat_Section_SectId",
                table: "IssueMain");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseOrderMain_Acc_FiscalYears_FiscalYearId",
                table: "PurchaseOrderMain");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseOrderMain_Cat_Section_SectId",
                table: "PurchaseOrderMain");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseOrderValidMains_Acc_FiscalYears_FiscalYearId",
                table: "PurchaseOrderValidMains");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseOrderValidMains_Cat_Section_SectId",
                table: "PurchaseOrderValidMains");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseRequisitionMain_HR_Emp_Info_ApprovedByEmpId",
                table: "PurchaseRequisitionMain");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseRequisitionMain_HR_Emp_Info_RecommenedByEmpId",
                table: "PurchaseRequisitionMain");

            migrationBuilder.DropForeignKey(
                name: "FK_Suppliers_Cat_District_DistId",
                table: "Suppliers");

            migrationBuilder.DropForeignKey(
                name: "FK_Suppliers_Cat_PoliceStation_PStationId",
                table: "Suppliers");

            migrationBuilder.DropIndex(
                name: "IX_Suppliers_DistId",
                table: "Suppliers");

            migrationBuilder.DropIndex(
                name: "IX_Suppliers_PStationId",
                table: "Suppliers");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseOrderValidMains_FiscalYearId",
                table: "PurchaseOrderValidMains");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseOrderValidMains_SectId",
                table: "PurchaseOrderValidMains");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseOrderMain_FiscalYearId",
                table: "PurchaseOrderMain");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseOrderMain_SectId",
                table: "PurchaseOrderMain");

            migrationBuilder.DropIndex(
                name: "IX_IssueMain_SectId",
                table: "IssueMain");

            migrationBuilder.DropColumn(
                name: "DistId",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "PStationId",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "SLNo",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "FiscalYearId",
                table: "PurchaseOrderValidMains");

            migrationBuilder.DropColumn(
                name: "LastDateOfDelivery",
                table: "PurchaseOrderValidMains");

            migrationBuilder.DropColumn(
                name: "SectId",
                table: "PurchaseOrderValidMains");

            migrationBuilder.DropColumn(
                name: "ExpectedRecivedDate",
                table: "PurchaseOrderMain");

            migrationBuilder.DropColumn(
                name: "FiscalYearId",
                table: "PurchaseOrderMain");

            migrationBuilder.DropColumn(
                name: "LastDateOfDelivery",
                table: "PurchaseOrderMain");

            migrationBuilder.DropColumn(
                name: "SectId",
                table: "PurchaseOrderMain");

            migrationBuilder.DropColumn(
                name: "SectId",
                table: "IssueMain");

            migrationBuilder.AlterColumn<int>(
                name: "RecommenedByEmpId",
                table: "PurchaseRequisitionMain",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ApprovedByEmpId",
                table: "PurchaseRequisitionMain",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SubSectId",
                table: "PurchaseOrderValidMains",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpectedReciveDate",
                table: "PurchaseOrderMain",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExpectedReciveDatestring",
                table: "PurchaseOrderMain",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "GateInHouseDate",
                table: "PurchaseOrderMain",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GateInHouseDatestring",
                table: "PurchaseOrderMain",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SubSectId",
                table: "PurchaseOrderMain",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SubSectId",
                table: "IssueMain",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderValidMains_SubSectId",
                table: "PurchaseOrderValidMains",
                column: "SubSectId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderMain_SubSectId",
                table: "PurchaseOrderMain",
                column: "SubSectId");

            migrationBuilder.CreateIndex(
                name: "IX_IssueMain_SubSectId",
                table: "IssueMain",
                column: "SubSectId");

            migrationBuilder.AddForeignKey(
                name: "FK_IssueMain_Cat_SubSection_SubSectId",
                table: "IssueMain",
                column: "SubSectId",
                principalTable: "Cat_SubSection",
                principalColumn: "SubSectId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseOrderMain_Cat_SubSection_SubSectId",
                table: "PurchaseOrderMain",
                column: "SubSectId",
                principalTable: "Cat_SubSection",
                principalColumn: "SubSectId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseOrderValidMains_Cat_SubSection_SubSectId",
                table: "PurchaseOrderValidMains",
                column: "SubSectId",
                principalTable: "Cat_SubSection",
                principalColumn: "SubSectId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseRequisitionMain_HR_Emp_Info_ApprovedByEmpId",
                table: "PurchaseRequisitionMain",
                column: "ApprovedByEmpId",
                principalTable: "HR_Emp_Info",
                principalColumn: "EmpId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseRequisitionMain_HR_Emp_Info_RecommenedByEmpId",
                table: "PurchaseRequisitionMain",
                column: "RecommenedByEmpId",
                principalTable: "HR_Emp_Info",
                principalColumn: "EmpId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
