using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class lvencashment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "LvEncashmentIYear",
                table: "HR_LvEncashment",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            //migrationBuilder.CreateTable(
            //    name: "StoreRequisitionMain",
            //    columns: table => new
            //    {
            //        StoreReqId = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        PrdUnitId = table.Column<int>(nullable: false),
            //        SRNo = table.Column<string>(maxLength: 50, nullable: true),
            //        ReqRef = table.Column<string>(nullable: true),
            //        ReqDate = table.Column<DateTime>(nullable: false),
            //        BoardMeetingDate = table.Column<DateTime>(nullable: false),
            //        PurposeId = table.Column<int>(nullable: false),
            //        DepartmentId = table.Column<int>(nullable: false),
            //        ApprovedByEmpId = table.Column<int>(nullable: false),
            //        RecommenedByEmpId = table.Column<int>(nullable: false),
            //        ReqStatus = table.Column<string>(nullable: true),
            //        Remarks = table.Column<string>(nullable: true),
            //        RequiredDate = table.Column<DateTime>(nullable: false),
            //        ComId = table.Column<string>(maxLength: 80, nullable: true),
            //        PcName = table.Column<string>(maxLength: 60, nullable: true),
            //        UserId = table.Column<string>(maxLength: 80, nullable: true),
            //        DateAdded = table.Column<DateTime>(nullable: true),
            //        UpdateByUserId = table.Column<string>(maxLength: 80, nullable: true),
            //        DateUpdated = table.Column<DateTime>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_StoreRequisitionMain", x => x.StoreReqId);
            //        table.ForeignKey(
            //            name: "FK_StoreRequisitionMain_HR_Emp_Info_ApprovedByEmpId",
            //            column: x => x.ApprovedByEmpId,
            //            principalTable: "HR_Emp_Info",
            //            principalColumn: "EmpId",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_StoreRequisitionMain_Cat_Department_DepartmentId",
            //            column: x => x.DepartmentId,
            //            principalTable: "Cat_Department",
            //            principalColumn: "DeptId",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_StoreRequisitionMain_PrdUnits_PrdUnitId",
            //            column: x => x.PrdUnitId,
            //            principalTable: "PrdUnits",
            //            principalColumn: "PrdUnitId",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_StoreRequisitionMain_Purpose_PurposeId",
            //            column: x => x.PurposeId,
            //            principalTable: "Purpose",
            //            principalColumn: "PurposeId",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_StoreRequisitionMain_HR_Emp_Info_RecommenedByEmpId",
            //            column: x => x.RecommenedByEmpId,
            //            principalTable: "HR_Emp_Info",
            //            principalColumn: "EmpId",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "UserStates",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        UserId = table.Column<string>(nullable: true),
            //        ComId = table.Column<string>(nullable: true),
            //        LastVisited = table.Column<string>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_UserStates", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "IssueMain",
            //    columns: table => new
            //    {
            //        IssueMainId = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        IssueNo = table.Column<string>(nullable: true),
            //        IssueDate = table.Column<DateTime>(nullable: false),
            //        IssueRef = table.Column<string>(nullable: true),
            //        Department = table.Column<string>(nullable: true),
            //        PrdUnitId = table.Column<int>(nullable: true),
            //        StoreReqId = table.Column<int>(nullable: true),
            //        SupplierId = table.Column<int>(nullable: true),
            //        PaymentTypeId = table.Column<int>(nullable: true),
            //        CurrencyId = table.Column<int>(nullable: true),
            //        ConvertionRate = table.Column<float>(nullable: false),
            //        TotalIssueValue = table.Column<float>(nullable: false),
            //        Deduction = table.Column<float>(nullable: true),
            //        NetIssueValue = table.Column<float>(nullable: true),
            //        SubSectId = table.Column<int>(nullable: true),
            //        GateInHouseDate = table.Column<DateTime>(nullable: true),
            //        ExpectedReciveDate = table.Column<DateTime>(nullable: true),
            //        TermsAndCondition = table.Column<string>(nullable: true),
            //        Remarks = table.Column<string>(nullable: true),
            //        ComId = table.Column<string>(maxLength: 80, nullable: true),
            //        PcName = table.Column<string>(maxLength: 60, nullable: true),
            //        UserId = table.Column<string>(maxLength: 80, nullable: true),
            //        DateAdded = table.Column<DateTime>(nullable: true),
            //        UpdateByUserId = table.Column<string>(maxLength: 80, nullable: true),
            //        DateUpdated = table.Column<DateTime>(nullable: true),
            //        GateInHouseDatestring = table.Column<string>(nullable: true),
            //        ExpectedReciveDatestring = table.Column<string>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_IssueMain", x => x.IssueMainId);
            //        table.ForeignKey(
            //            name: "FK_IssueMain_Currency_CurrencyId",
            //            column: x => x.CurrencyId,
            //            principalTable: "Currency",
            //            principalColumn: "CurrencyId",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_IssueMain_PaymentTypes_PaymentTypeId",
            //            column: x => x.PaymentTypeId,
            //            principalTable: "PaymentTypes",
            //            principalColumn: "PaymentTypeId",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_IssueMain_PrdUnits_PrdUnitId",
            //            column: x => x.PrdUnitId,
            //            principalTable: "PrdUnits",
            //            principalColumn: "PrdUnitId",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_IssueMain_StoreRequisitionMain_StoreReqId",
            //            column: x => x.StoreReqId,
            //            principalTable: "StoreRequisitionMain",
            //            principalColumn: "StoreReqId",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_IssueMain_Cat_SubSection_SubSectId",
            //            column: x => x.SubSectId,
            //            principalTable: "Cat_SubSection",
            //            principalColumn: "SubSectId",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_IssueMain_Suppliers_SupplierId",
            //            column: x => x.SupplierId,
            //            principalTable: "Suppliers",
            //            principalColumn: "SupplierId",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "StoreRequisitionSub",
            //    columns: table => new
            //    {
            //        StoreReqSubId = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        SLNo = table.Column<int>(nullable: false),
            //        ProductId = table.Column<int>(nullable: false),
            //        StoreReqQty = table.Column<int>(nullable: false),
            //        RemainingReqQty = table.Column<int>(nullable: true),
            //        Note = table.Column<string>(nullable: true),
            //        StoreReqId = table.Column<int>(nullable: false),
            //        ComId = table.Column<string>(maxLength: 80, nullable: true),
            //        PcName = table.Column<string>(maxLength: 60, nullable: true),
            //        UserId = table.Column<string>(maxLength: 80, nullable: true),
            //        DateAdded = table.Column<DateTime>(nullable: true),
            //        UpdateByUserId = table.Column<string>(maxLength: 80, nullable: true),
            //        DateUpdated = table.Column<DateTime>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_StoreRequisitionSub", x => x.StoreReqSubId);
            //        table.ForeignKey(
            //            name: "FK_StoreRequisitionSub_Products_ProductId",
            //            column: x => x.ProductId,
            //            principalTable: "Products",
            //            principalColumn: "ProductId",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_StoreRequisitionSub_StoreRequisitionMain_StoreReqId",
            //            column: x => x.StoreReqId,
            //            principalTable: "StoreRequisitionMain",
            //            principalColumn: "StoreReqId",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "IssueSub",
            //    columns: table => new
            //    {
            //        IssueSubId = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        SLNo = table.Column<string>(nullable: true),
            //        ProductId = table.Column<int>(nullable: true),
            //        RequisitionQty = table.Column<int>(nullable: true),
            //        RemainingReqQty = table.Column<int>(nullable: true),
            //        PurchaseQty = table.Column<int>(nullable: true),
            //        Rate = table.Column<float>(nullable: true),
            //        TotalValue = table.Column<float>(nullable: true),
            //        Remarks = table.Column<string>(nullable: true),
            //        ComId = table.Column<string>(maxLength: 80, nullable: true),
            //        PcName = table.Column<string>(maxLength: 60, nullable: true),
            //        UserId = table.Column<string>(maxLength: 80, nullable: true),
            //        DateAdded = table.Column<DateTime>(nullable: true),
            //        UpdateByUserId = table.Column<string>(maxLength: 80, nullable: true),
            //        DateUpdated = table.Column<DateTime>(nullable: true),
            //        StoreReqSubId = table.Column<int>(nullable: true),
            //        IssueMainId = table.Column<int>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_IssueSub", x => x.IssueSubId);
            //        table.ForeignKey(
            //            name: "FK_IssueSub_IssueMain_IssueMainId",
            //            column: x => x.IssueMainId,
            //            principalTable: "IssueMain",
            //            principalColumn: "IssueMainId",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_IssueSub_Products_ProductId",
            //            column: x => x.ProductId,
            //            principalTable: "Products",
            //            principalColumn: "ProductId",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_IssueSub_StoreRequisitionSub_StoreReqSubId",
            //            column: x => x.StoreReqSubId,
            //            principalTable: "StoreRequisitionSub",
            //            principalColumn: "StoreReqSubId",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_IssueMain_CurrencyId",
            //    table: "IssueMain",
            //    column: "CurrencyId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_IssueMain_PaymentTypeId",
            //    table: "IssueMain",
            //    column: "PaymentTypeId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_IssueMain_PrdUnitId",
            //    table: "IssueMain",
            //    column: "PrdUnitId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_IssueMain_StoreReqId",
            //    table: "IssueMain",
            //    column: "StoreReqId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_IssueMain_SubSectId",
            //    table: "IssueMain",
            //    column: "SubSectId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_IssueMain_SupplierId",
            //    table: "IssueMain",
            //    column: "SupplierId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_IssueSub_IssueMainId",
            //    table: "IssueSub",
            //    column: "IssueMainId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_IssueSub_ProductId",
            //    table: "IssueSub",
            //    column: "ProductId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_IssueSub_StoreReqSubId",
            //    table: "IssueSub",
            //    column: "StoreReqSubId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_StoreRequisitionMain_ApprovedByEmpId",
            //    table: "StoreRequisitionMain",
            //    column: "ApprovedByEmpId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_StoreRequisitionMain_DepartmentId",
            //    table: "StoreRequisitionMain",
            //    column: "DepartmentId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_StoreRequisitionMain_PrdUnitId",
            //    table: "StoreRequisitionMain",
            //    column: "PrdUnitId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_StoreRequisitionMain_PurposeId",
            //    table: "StoreRequisitionMain",
            //    column: "PurposeId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_StoreRequisitionMain_RecommenedByEmpId",
            //    table: "StoreRequisitionMain",
            //    column: "RecommenedByEmpId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_StoreRequisitionSub_ProductId",
            //    table: "StoreRequisitionSub",
            //    column: "ProductId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_StoreRequisitionSub_StoreReqId",
            //    table: "StoreRequisitionSub",
            //    column: "StoreReqId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IssueSub");

            migrationBuilder.DropTable(
                name: "UserStates");

            migrationBuilder.DropTable(
                name: "IssueMain");

            migrationBuilder.DropTable(
                name: "StoreRequisitionSub");

            migrationBuilder.DropTable(
                name: "StoreRequisitionMain");

            migrationBuilder.AlterColumn<string>(
                name: "LvEncashmentIYear",
                table: "HR_LvEncashment",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
