using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace GTERP.Migrations.GTRDB
{
    public partial class chartofaccounts_PFandUniqecodemaintain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SupplierCode",
                table: "Suppliers",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Acc_ChartOfAccount_PF",
                columns: table => new
                {
                    AccId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    comid = table.Column<string>(maxLength: 128, nullable: true),
                    AccName = table.Column<string>(maxLength: 200, nullable: false),
                    AccCode = table.Column<string>(maxLength: 20, nullable: true),
                    AccCode_Old = table.Column<string>(nullable: true),
                    AccType = table.Column<string>(maxLength: 1, nullable: true),
                    ParentID = table.Column<int>(nullable: true),
                    ParentCode = table.Column<string>(maxLength: 20, nullable: true),
                    OpDebit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OpCredit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    userid = table.Column<string>(maxLength: 128, nullable: true),
                    useridUpdate = table.Column<string>(maxLength: 128, nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: true),
                    IsItemBS = table.Column<int>(nullable: false),
                    IsItemPL = table.Column<int>(nullable: false),
                    IsItemTA = table.Column<int>(nullable: false),
                    IsItemCS = table.Column<int>(nullable: false),
                    IsShowCOA = table.Column<int>(nullable: false),
                    IsChkRef = table.Column<bool>(nullable: false),
                    IsItemDepExp = table.Column<bool>(nullable: false),
                    IsItemAccmulateddDep = table.Column<bool>(nullable: false),
                    IsEntryBankLiability = table.Column<int>(nullable: false),
                    IsSysDefined = table.Column<int>(nullable: false),
                    CountryID = table.Column<int>(nullable: false),
                    CountryIdLocal = table.Column<int>(nullable: false),
                    Rate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OpDebitLocal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OpCreditLocal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    isInactive = table.Column<bool>(nullable: false),
                    isItemConsumed = table.Column<bool>(nullable: false),
                    isItemInventory = table.Column<bool>(nullable: false),
                    isShowUg = table.Column<bool>(nullable: false),
                    OpDate = table.Column<DateTime>(nullable: false),
                    opFYId = table.Column<int>(nullable: false),
                    Balance = table.Column<decimal>(nullable: false),
                    RelatedId = table.Column<int>(nullable: false),
                    Level = table.Column<int>(nullable: true),
                    AccSubId = table.Column<int>(nullable: true),
                    IsCashItem = table.Column<bool>(nullable: false),
                    IsBankItem = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acc_ChartOfAccount_PF", x => x.AccId);
                    table.ForeignKey(
                        name: "FK_Acc_ChartOfAccount_PF_Acc_ChartOfAccount_PF_ParentID",
                        column: x => x.ParentID,
                        principalTable: "Acc_ChartOfAccount_PF",
                        principalColumn: "AccId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Acc_VoucherMain_PF",
                columns: table => new
                {
                    VoucherId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VoucherSerialId = table.Column<int>(nullable: false),
                    YearlyVoucherTypeWiseSerial = table.Column<int>(nullable: true),
                    VoucherNo = table.Column<string>(maxLength: 20, nullable: true),
                    VoucherDate = table.Column<DateTime>(nullable: false),
                    VoucherInputDate = table.Column<DateTime>(nullable: false),
                    VoucherTypeId = table.Column<int>(nullable: false),
                    PrdUnitId = table.Column<int>(nullable: true),
                    VoucherDesc = table.Column<string>(nullable: true),
                    comid = table.Column<string>(maxLength: 128, nullable: true),
                    userid = table.Column<string>(maxLength: 128, nullable: true),
                    useridCheck = table.Column<string>(maxLength: 128, nullable: true),
                    useridApprove = table.Column<string>(maxLength: 128, nullable: true),
                    useridUpdate = table.Column<string>(maxLength: 128, nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: true),
                    isAutoEntry = table.Column<bool>(nullable: false),
                    isPosted = table.Column<bool>(nullable: false),
                    CountryId = table.Column<int>(nullable: false),
                    CountryIdLocal = table.Column<int>(nullable: false),
                    VAmount = table.Column<double>(nullable: false),
                    vAmountInWords = table.Column<string>(nullable: true),
                    Source = table.Column<string>(nullable: true),
                    SourceId = table.Column<int>(nullable: false),
                    ConvRate = table.Column<double>(nullable: false),
                    VAmountLocal = table.Column<double>(nullable: false),
                    Referance = table.Column<string>(nullable: true),
                    ReferanceTwo = table.Column<string>(nullable: true),
                    ReferanceThree = table.Column<string>(nullable: true),
                    IsCash = table.Column<bool>(nullable: false),
                    FiscalYearId = table.Column<int>(nullable: true),
                    FiscalMonthId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acc_VoucherMain_PF", x => x.VoucherId);
                    table.ForeignKey(
                        name: "FK_Acc_VoucherMain_PF_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Acc_VoucherMain_PF_Countries_CountryIdLocal",
                        column: x => x.CountryIdLocal,
                        principalTable: "Countries",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Acc_VoucherMain_PF_Acc_FiscalMonths_FiscalMonthId",
                        column: x => x.FiscalMonthId,
                        principalTable: "Acc_FiscalMonths",
                        principalColumn: "FiscalMonthId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Acc_VoucherMain_PF_Acc_FiscalYears_FiscalYearId",
                        column: x => x.FiscalYearId,
                        principalTable: "Acc_FiscalYears",
                        principalColumn: "FiscalYearId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Acc_VoucherMain_PF_PrdUnits_PrdUnitId",
                        column: x => x.PrdUnitId,
                        principalTable: "PrdUnits",
                        principalColumn: "PrdUnitId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Acc_VoucherMain_PF_Acc_VoucherTypes_VoucherTypeId",
                        column: x => x.VoucherTypeId,
                        principalTable: "Acc_VoucherTypes",
                        principalColumn: "VoucherTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Acc_VoucherSub_PF",
                columns: table => new
                {
                    VoucherSubId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VoucherId = table.Column<int>(nullable: false),
                    AccId = table.Column<int>(nullable: false),
                    SRowNo = table.Column<int>(nullable: false),
                    ccId = table.Column<int>(nullable: false),
                    CurrencyId = table.Column<int>(nullable: false),
                    CurrencyForeignId = table.Column<int>(nullable: false),
                    TKDebit = table.Column<double>(nullable: false),
                    TKCredit = table.Column<double>(nullable: false),
                    TKDebitLocal = table.Column<double>(nullable: false),
                    TKCreditLocal = table.Column<double>(nullable: false),
                    CurrencyRate = table.Column<double>(nullable: false),
                    Note1 = table.Column<string>(nullable: true),
                    Note2 = table.Column<string>(nullable: true),
                    Note3 = table.Column<string>(nullable: true),
                    Note4 = table.Column<string>(nullable: true),
                    Note5 = table.Column<string>(nullable: true),
                    RowNo = table.Column<int>(nullable: true),
                    RefId = table.Column<int>(nullable: true),
                    SLNo = table.Column<int>(nullable: true),
                    EmpId = table.Column<int>(nullable: true),
                    CustomerId = table.Column<int>(nullable: true),
                    SupplierId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acc_VoucherSub_PF", x => x.VoucherSubId);
                    table.ForeignKey(
                        name: "FK_Acc_VoucherSub_PF_Acc_ChartOfAccount_PF_AccId",
                        column: x => x.AccId,
                        principalTable: "Acc_ChartOfAccount_PF",
                        principalColumn: "AccId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Acc_VoucherSub_PF_Countries_CurrencyForeignId",
                        column: x => x.CurrencyForeignId,
                        principalTable: "Countries",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Acc_VoucherSub_PF_Countries_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Countries",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Acc_VoucherSub_PF_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Acc_VoucherSub_PF_HR_Emp_Info_EmpId",
                        column: x => x.EmpId,
                        principalTable: "HR_Emp_Info",
                        principalColumn: "EmpId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Acc_VoucherSub_PF_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "SupplierId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Acc_VoucherSub_PF_Acc_VoucherMain_PF_VoucherId",
                        column: x => x.VoucherId,
                        principalTable: "Acc_VoucherMain_PF",
                        principalColumn: "VoucherId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Acc_VoucherSub_PFCheckno",
                columns: table => new
                {
                    VoucherSubCheckId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VoucherSubId = table.Column<int>(nullable: true),
                    RowNoChk = table.Column<int>(nullable: false),
                    VoucherId = table.Column<int>(nullable: true),
                    AccId = table.Column<int>(nullable: false),
                    SRowNo = table.Column<int>(nullable: true),
                    ChkNo = table.Column<string>(nullable: true),
                    dtChk = table.Column<DateTime>(nullable: true),
                    dtChkTo = table.Column<string>(nullable: true),
                    Remarks = table.Column<string>(nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InterestRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    isClear = table.Column<bool>(nullable: false),
                    dtChkClear = table.Column<string>(nullable: true),
                    Criteria = table.Column<string>(nullable: true),
                    comid = table.Column<string>(maxLength: 128, nullable: true),
                    userid = table.Column<string>(maxLength: 128, nullable: true),
                    useridCheck = table.Column<string>(maxLength: 128, nullable: true),
                    useridApprove = table.Column<string>(maxLength: 128, nullable: true),
                    useridUpdate = table.Column<string>(maxLength: 128, nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: true),
                    isManualEntry = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acc_VoucherSub_PFCheckno", x => x.VoucherSubCheckId);
                    table.ForeignKey(
                        name: "FK_Acc_VoucherSub_PFCheckno_Acc_ChartOfAccount_PF_AccId",
                        column: x => x.AccId,
                        principalTable: "Acc_ChartOfAccount_PF",
                        principalColumn: "AccId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Acc_VoucherSub_PFCheckno_Acc_VoucherSub_PF_VoucherSubId",
                        column: x => x.VoucherSubId,
                        principalTable: "Acc_VoucherSub_PF",
                        principalColumn: "VoucherSubId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Acc_VoucherSub_PFSection",
                columns: table => new
                {
                    VoucherSubSectionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VoucherSubId = table.Column<int>(nullable: false),
                    RowNoSSec = table.Column<int>(nullable: false),
                    VoucherId = table.Column<int>(nullable: false),
                    AccId = table.Column<int>(nullable: false),
                    SRowNo = table.Column<int>(nullable: false),
                    SubSectId = table.Column<int>(nullable: false),
                    Note1 = table.Column<string>(nullable: true),
                    Note2 = table.Column<string>(nullable: true),
                    Amount = table.Column<double>(nullable: false),
                    SubSectionSubSectId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acc_VoucherSub_PFSection", x => x.VoucherSubSectionId);
                    table.ForeignKey(
                        name: "FK_Acc_VoucherSub_PFSection_Cat_SubSection_SubSectionSubSectId",
                        column: x => x.SubSectionSubSectId,
                        principalTable: "Cat_SubSection",
                        principalColumn: "SubSectId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Acc_VoucherSub_PFSection_Acc_VoucherSub_PF_VoucherSubId",
                        column: x => x.VoucherSubId,
                        principalTable: "Acc_VoucherSub_PF",
                        principalColumn: "VoucherSubId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_comid_SupplierCode",
                table: "Suppliers",
                columns: new[] { "comid", "SupplierCode" },
                unique: true,
                filter: "[SupplierCode] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Acc_VoucherMains_comid_VoucherNo_FiscalYearId_FiscalMonthId",
                table: "Acc_VoucherMains",
                columns: new[] { "comid", "VoucherNo", "FiscalYearId", "FiscalMonthId" },
                unique: true,
                filter: "[comid] IS NOT NULL AND [VoucherNo] IS NOT NULL AND [FiscalYearId] IS NOT NULL AND [FiscalMonthId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Acc_ChartOfAccounts_comid_AccCode",
                table: "Acc_ChartOfAccounts",
                columns: new[] { "comid", "AccCode" },
                unique: true,
                filter: "[comid] IS NOT NULL AND [AccCode] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Acc_ChartOfAccount_PF_ParentID",
                table: "Acc_ChartOfAccount_PF",
                column: "ParentID");

            migrationBuilder.CreateIndex(
                name: "IX_Acc_ChartOfAccount_PF_comid_AccCode",
                table: "Acc_ChartOfAccount_PF",
                columns: new[] { "comid", "AccCode" },
                unique: true,
                filter: "[comid] IS NOT NULL AND [AccCode] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Acc_VoucherMain_PF_CountryId",
                table: "Acc_VoucherMain_PF",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Acc_VoucherMain_PF_CountryIdLocal",
                table: "Acc_VoucherMain_PF",
                column: "CountryIdLocal");

            migrationBuilder.CreateIndex(
                name: "IX_Acc_VoucherMain_PF_FiscalMonthId",
                table: "Acc_VoucherMain_PF",
                column: "FiscalMonthId");

            migrationBuilder.CreateIndex(
                name: "IX_Acc_VoucherMain_PF_FiscalYearId",
                table: "Acc_VoucherMain_PF",
                column: "FiscalYearId");

            migrationBuilder.CreateIndex(
                name: "IX_Acc_VoucherMain_PF_PrdUnitId",
                table: "Acc_VoucherMain_PF",
                column: "PrdUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Acc_VoucherMain_PF_VoucherTypeId",
                table: "Acc_VoucherMain_PF",
                column: "VoucherTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Acc_VoucherMain_PF_comid_VoucherNo_FiscalYearId_FiscalMonthId",
                table: "Acc_VoucherMain_PF",
                columns: new[] { "comid", "VoucherNo", "FiscalYearId", "FiscalMonthId" },
                unique: true,
                filter: "[comid] IS NOT NULL AND [VoucherNo] IS NOT NULL AND [FiscalYearId] IS NOT NULL AND [FiscalMonthId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Acc_VoucherSub_PF_AccId",
                table: "Acc_VoucherSub_PF",
                column: "AccId");

            migrationBuilder.CreateIndex(
                name: "IX_Acc_VoucherSub_PF_CurrencyForeignId",
                table: "Acc_VoucherSub_PF",
                column: "CurrencyForeignId");

            migrationBuilder.CreateIndex(
                name: "IX_Acc_VoucherSub_PF_CurrencyId",
                table: "Acc_VoucherSub_PF",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Acc_VoucherSub_PF_CustomerId",
                table: "Acc_VoucherSub_PF",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Acc_VoucherSub_PF_EmpId",
                table: "Acc_VoucherSub_PF",
                column: "EmpId");

            migrationBuilder.CreateIndex(
                name: "IX_Acc_VoucherSub_PF_SupplierId",
                table: "Acc_VoucherSub_PF",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_Acc_VoucherSub_PF_VoucherId",
                table: "Acc_VoucherSub_PF",
                column: "VoucherId");

            migrationBuilder.CreateIndex(
                name: "IX_Acc_VoucherSub_PFCheckno_AccId",
                table: "Acc_VoucherSub_PFCheckno",
                column: "AccId");

            migrationBuilder.CreateIndex(
                name: "IX_Acc_VoucherSub_PFCheckno_VoucherSubId",
                table: "Acc_VoucherSub_PFCheckno",
                column: "VoucherSubId");

            migrationBuilder.CreateIndex(
                name: "IX_Acc_VoucherSub_PFSection_SubSectionSubSectId",
                table: "Acc_VoucherSub_PFSection",
                column: "SubSectionSubSectId");

            migrationBuilder.CreateIndex(
                name: "IX_Acc_VoucherSub_PFSection_VoucherSubId",
                table: "Acc_VoucherSub_PFSection",
                column: "VoucherSubId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Acc_VoucherSub_PFCheckno");

            migrationBuilder.DropTable(
                name: "Acc_VoucherSub_PFSection");

            migrationBuilder.DropTable(
                name: "Acc_VoucherSub_PF");

            migrationBuilder.DropTable(
                name: "Acc_ChartOfAccount_PF");

            migrationBuilder.DropTable(
                name: "Acc_VoucherMain_PF");

            migrationBuilder.DropIndex(
                name: "IX_Suppliers_comid_SupplierCode",
                table: "Suppliers");

            migrationBuilder.DropIndex(
                name: "IX_Acc_VoucherMains_comid_VoucherNo_FiscalYearId_FiscalMonthId",
                table: "Acc_VoucherMains");

            migrationBuilder.DropIndex(
                name: "IX_Acc_ChartOfAccounts_comid_AccCode",
                table: "Acc_ChartOfAccounts");

            migrationBuilder.AlterColumn<string>(
                name: "SupplierCode",
                table: "Suppliers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
