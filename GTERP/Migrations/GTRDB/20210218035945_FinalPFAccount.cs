using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace GTERP.Migrations.GTRDB
{
    public partial class FinalPFAccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cat_PFIntegrationSummary_Acc_ChartOfAccounts_PF_AccId",
                table: "Cat_PFIntegrationSummary");

            migrationBuilder.DropTable(
                name: "Acc_VoucherSub_PFCheckno");

            migrationBuilder.DropTable(
                name: "Acc_VoucherSub_PFSection");

            migrationBuilder.DropTable(
                name: "Acc_VoucherSub_PF");

            migrationBuilder.DropTable(
                name: "Acc_ChartOfAccounts_PF");

            migrationBuilder.DropTable(
                name: "Acc_VoucherMain_PF");

            migrationBuilder.CreateTable(
                name: "PF_ChartOfAccounts",
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
                    table.PrimaryKey("PK_PF_ChartOfAccounts", x => x.AccId);
                    table.ForeignKey(
                        name: "FK_PF_ChartOfAccounts_PF_ChartOfAccounts_ParentID",
                        column: x => x.ParentID,
                        principalTable: "PF_ChartOfAccounts",
                        principalColumn: "AccId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PF_VoucherMains",
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
                    table.PrimaryKey("PK_PF_VoucherMains", x => x.VoucherId);
                    table.ForeignKey(
                        name: "FK_PF_VoucherMains_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PF_VoucherMains_Countries_CountryIdLocal",
                        column: x => x.CountryIdLocal,
                        principalTable: "Countries",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PF_VoucherMains_Acc_FiscalMonths_FiscalMonthId",
                        column: x => x.FiscalMonthId,
                        principalTable: "Acc_FiscalMonths",
                        principalColumn: "FiscalMonthId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PF_VoucherMains_Acc_FiscalYears_FiscalYearId",
                        column: x => x.FiscalYearId,
                        principalTable: "Acc_FiscalYears",
                        principalColumn: "FiscalYearId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PF_VoucherMains_PrdUnits_PrdUnitId",
                        column: x => x.PrdUnitId,
                        principalTable: "PrdUnits",
                        principalColumn: "PrdUnitId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PF_VoucherMains_Acc_VoucherTypes_VoucherTypeId",
                        column: x => x.VoucherTypeId,
                        principalTable: "Acc_VoucherTypes",
                        principalColumn: "VoucherTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PF_VoucherSubs",
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
                    table.PrimaryKey("PK_PF_VoucherSubs", x => x.VoucherSubId);
                    table.ForeignKey(
                        name: "FK_PF_VoucherSubs_PF_ChartOfAccounts_AccId",
                        column: x => x.AccId,
                        principalTable: "PF_ChartOfAccounts",
                        principalColumn: "AccId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PF_VoucherSubs_Countries_CurrencyForeignId",
                        column: x => x.CurrencyForeignId,
                        principalTable: "Countries",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PF_VoucherSubs_Countries_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Countries",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PF_VoucherSubs_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PF_VoucherSubs_HR_Emp_Info_EmpId",
                        column: x => x.EmpId,
                        principalTable: "HR_Emp_Info",
                        principalColumn: "EmpId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PF_VoucherSubs_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "SupplierId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PF_VoucherSubs_PF_VoucherMains_VoucherId",
                        column: x => x.VoucherId,
                        principalTable: "PF_VoucherMains",
                        principalColumn: "VoucherId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PF_VoucherSubChecnos",
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
                    table.PrimaryKey("PK_PF_VoucherSubChecnos", x => x.VoucherSubCheckId);
                    table.ForeignKey(
                        name: "FK_PF_VoucherSubChecnos_PF_ChartOfAccounts_AccId",
                        column: x => x.AccId,
                        principalTable: "PF_ChartOfAccounts",
                        principalColumn: "AccId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PF_VoucherSubChecnos_PF_VoucherSubs_VoucherSubId",
                        column: x => x.VoucherSubId,
                        principalTable: "PF_VoucherSubs",
                        principalColumn: "VoucherSubId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PF_VoucherSubSections",
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
                    table.PrimaryKey("PK_PF_VoucherSubSections", x => x.VoucherSubSectionId);
                    table.ForeignKey(
                        name: "FK_PF_VoucherSubSections_Cat_SubSection_SubSectionSubSectId",
                        column: x => x.SubSectionSubSectId,
                        principalTable: "Cat_SubSection",
                        principalColumn: "SubSectId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PF_VoucherSubSections_PF_VoucherSubs_VoucherSubId",
                        column: x => x.VoucherSubId,
                        principalTable: "PF_VoucherSubs",
                        principalColumn: "VoucherSubId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PF_ChartOfAccounts_ParentID",
                table: "PF_ChartOfAccounts",
                column: "ParentID");

            migrationBuilder.CreateIndex(
                name: "IX_PF_ChartOfAccounts_comid_AccCode",
                table: "PF_ChartOfAccounts",
                columns: new[] { "comid", "AccCode" },
                unique: true,
                filter: "[comid] IS NOT NULL AND [AccCode] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_PF_VoucherMains_CountryId",
                table: "PF_VoucherMains",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_PF_VoucherMains_CountryIdLocal",
                table: "PF_VoucherMains",
                column: "CountryIdLocal");

            migrationBuilder.CreateIndex(
                name: "IX_PF_VoucherMains_FiscalMonthId",
                table: "PF_VoucherMains",
                column: "FiscalMonthId");

            migrationBuilder.CreateIndex(
                name: "IX_PF_VoucherMains_FiscalYearId",
                table: "PF_VoucherMains",
                column: "FiscalYearId");

            migrationBuilder.CreateIndex(
                name: "IX_PF_VoucherMains_PrdUnitId",
                table: "PF_VoucherMains",
                column: "PrdUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_PF_VoucherMains_VoucherTypeId",
                table: "PF_VoucherMains",
                column: "VoucherTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PF_VoucherMains_comid_VoucherNo_FiscalYearId_FiscalMonthId",
                table: "PF_VoucherMains",
                columns: new[] { "comid", "VoucherNo", "FiscalYearId", "FiscalMonthId" },
                unique: true,
                filter: "[comid] IS NOT NULL AND [VoucherNo] IS NOT NULL AND [FiscalYearId] IS NOT NULL AND [FiscalMonthId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_PF_VoucherSubChecnos_AccId",
                table: "PF_VoucherSubChecnos",
                column: "AccId");

            migrationBuilder.CreateIndex(
                name: "IX_PF_VoucherSubChecnos_VoucherSubId",
                table: "PF_VoucherSubChecnos",
                column: "VoucherSubId");

            migrationBuilder.CreateIndex(
                name: "IX_PF_VoucherSubs_AccId",
                table: "PF_VoucherSubs",
                column: "AccId");

            migrationBuilder.CreateIndex(
                name: "IX_PF_VoucherSubs_CurrencyForeignId",
                table: "PF_VoucherSubs",
                column: "CurrencyForeignId");

            migrationBuilder.CreateIndex(
                name: "IX_PF_VoucherSubs_CurrencyId",
                table: "PF_VoucherSubs",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_PF_VoucherSubs_CustomerId",
                table: "PF_VoucherSubs",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_PF_VoucherSubs_EmpId",
                table: "PF_VoucherSubs",
                column: "EmpId");

            migrationBuilder.CreateIndex(
                name: "IX_PF_VoucherSubs_SupplierId",
                table: "PF_VoucherSubs",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_PF_VoucherSubs_VoucherId",
                table: "PF_VoucherSubs",
                column: "VoucherId");

            migrationBuilder.CreateIndex(
                name: "IX_PF_VoucherSubSections_SubSectionSubSectId",
                table: "PF_VoucherSubSections",
                column: "SubSectionSubSectId");

            migrationBuilder.CreateIndex(
                name: "IX_PF_VoucherSubSections_VoucherSubId",
                table: "PF_VoucherSubSections",
                column: "VoucherSubId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cat_PFIntegrationSummary_PF_ChartOfAccounts_AccId",
                table: "Cat_PFIntegrationSummary",
                column: "AccId",
                principalTable: "PF_ChartOfAccounts",
                principalColumn: "AccId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cat_PFIntegrationSummary_PF_ChartOfAccounts_AccId",
                table: "Cat_PFIntegrationSummary");

            migrationBuilder.DropTable(
                name: "PF_VoucherSubChecnos");

            migrationBuilder.DropTable(
                name: "PF_VoucherSubSections");

            migrationBuilder.DropTable(
                name: "PF_VoucherSubs");

            migrationBuilder.DropTable(
                name: "PF_ChartOfAccounts");

            migrationBuilder.DropTable(
                name: "PF_VoucherMains");

            migrationBuilder.CreateTable(
                name: "Acc_ChartOfAccounts_PF",
                columns: table => new
                {
                    AccId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    AccCode_Old = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    AccSubId = table.Column<int>(type: "int", nullable: true),
                    AccType = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    Balance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CountryID = table.Column<int>(type: "int", nullable: false),
                    CountryIdLocal = table.Column<int>(type: "int", nullable: false),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsBankItem = table.Column<bool>(type: "bit", nullable: false),
                    IsCashItem = table.Column<bool>(type: "bit", nullable: false),
                    IsChkRef = table.Column<bool>(type: "bit", nullable: false),
                    IsEntryBankLiability = table.Column<int>(type: "int", nullable: false),
                    IsItemAccmulateddDep = table.Column<bool>(type: "bit", nullable: false),
                    IsItemBS = table.Column<int>(type: "int", nullable: false),
                    IsItemCS = table.Column<int>(type: "int", nullable: false),
                    IsItemDepExp = table.Column<bool>(type: "bit", nullable: false),
                    IsItemPL = table.Column<int>(type: "int", nullable: false),
                    IsItemTA = table.Column<int>(type: "int", nullable: false),
                    IsShowCOA = table.Column<int>(type: "int", nullable: false),
                    IsSysDefined = table.Column<int>(type: "int", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: true),
                    OpCredit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OpCreditLocal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OpDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OpDebit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OpDebitLocal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ParentCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    ParentID = table.Column<int>(type: "int", nullable: true),
                    Rate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RelatedId = table.Column<int>(type: "int", nullable: false),
                    comid = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    isInactive = table.Column<bool>(type: "bit", nullable: false),
                    isItemConsumed = table.Column<bool>(type: "bit", nullable: false),
                    isItemInventory = table.Column<bool>(type: "bit", nullable: false),
                    isShowUg = table.Column<bool>(type: "bit", nullable: false),
                    opFYId = table.Column<int>(type: "int", nullable: false),
                    userid = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    useridUpdate = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acc_ChartOfAccounts_PF", x => x.AccId);
                    table.ForeignKey(
                        name: "FK_Acc_ChartOfAccounts_PF_Acc_ChartOfAccounts_PF_ParentID",
                        column: x => x.ParentID,
                        principalTable: "Acc_ChartOfAccounts_PF",
                        principalColumn: "AccId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Acc_VoucherMain_PF",
                columns: table => new
                {
                    VoucherId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConvRate = table.Column<double>(type: "float", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    CountryIdLocal = table.Column<int>(type: "int", nullable: false),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FiscalMonthId = table.Column<int>(type: "int", nullable: true),
                    FiscalYearId = table.Column<int>(type: "int", nullable: true),
                    IsCash = table.Column<bool>(type: "bit", nullable: false),
                    PrdUnitId = table.Column<int>(type: "int", nullable: true),
                    Referance = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReferanceThree = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReferanceTwo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Source = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SourceId = table.Column<int>(type: "int", nullable: false),
                    VAmount = table.Column<double>(type: "float", nullable: false),
                    VAmountLocal = table.Column<double>(type: "float", nullable: false),
                    VoucherDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VoucherDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VoucherInputDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VoucherNo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    VoucherSerialId = table.Column<int>(type: "int", nullable: false),
                    VoucherTypeId = table.Column<int>(type: "int", nullable: false),
                    YearlyVoucherTypeWiseSerial = table.Column<int>(type: "int", nullable: true),
                    comid = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    isAutoEntry = table.Column<bool>(type: "bit", nullable: false),
                    isPosted = table.Column<bool>(type: "bit", nullable: false),
                    userid = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    useridApprove = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    useridCheck = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    useridUpdate = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    vAmountInWords = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    VoucherSubId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccId = table.Column<int>(type: "int", nullable: false),
                    CurrencyForeignId = table.Column<int>(type: "int", nullable: false),
                    CurrencyId = table.Column<int>(type: "int", nullable: false),
                    CurrencyRate = table.Column<double>(type: "float", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: true),
                    EmpId = table.Column<int>(type: "int", nullable: true),
                    Note1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefId = table.Column<int>(type: "int", nullable: true),
                    RowNo = table.Column<int>(type: "int", nullable: true),
                    SLNo = table.Column<int>(type: "int", nullable: true),
                    SRowNo = table.Column<int>(type: "int", nullable: false),
                    SupplierId = table.Column<int>(type: "int", nullable: true),
                    TKCredit = table.Column<double>(type: "float", nullable: false),
                    TKCreditLocal = table.Column<double>(type: "float", nullable: false),
                    TKDebit = table.Column<double>(type: "float", nullable: false),
                    TKDebitLocal = table.Column<double>(type: "float", nullable: false),
                    VoucherId = table.Column<int>(type: "int", nullable: false),
                    ccId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acc_VoucherSub_PF", x => x.VoucherSubId);
                    table.ForeignKey(
                        name: "FK_Acc_VoucherSub_PF_Acc_ChartOfAccounts_PF_AccId",
                        column: x => x.AccId,
                        principalTable: "Acc_ChartOfAccounts_PF",
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
                    VoucherSubCheckId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ChkNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Criteria = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InterestRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RowNoChk = table.Column<int>(type: "int", nullable: false),
                    SRowNo = table.Column<int>(type: "int", nullable: true),
                    VoucherId = table.Column<int>(type: "int", nullable: true),
                    VoucherSubId = table.Column<int>(type: "int", nullable: true),
                    comid = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    dtChk = table.Column<DateTime>(type: "datetime2", nullable: true),
                    dtChkClear = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dtChkTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isClear = table.Column<bool>(type: "bit", nullable: false),
                    isManualEntry = table.Column<bool>(type: "bit", nullable: false),
                    userid = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    useridApprove = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    useridCheck = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    useridUpdate = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acc_VoucherSub_PFCheckno", x => x.VoucherSubCheckId);
                    table.ForeignKey(
                        name: "FK_Acc_VoucherSub_PFCheckno_Acc_ChartOfAccounts_PF_AccId",
                        column: x => x.AccId,
                        principalTable: "Acc_ChartOfAccounts_PF",
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
                    VoucherSubSectionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    Note1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RowNoSSec = table.Column<int>(type: "int", nullable: false),
                    SRowNo = table.Column<int>(type: "int", nullable: false),
                    SubSectId = table.Column<int>(type: "int", nullable: false),
                    SubSectionSubSectId = table.Column<int>(type: "int", nullable: true),
                    VoucherId = table.Column<int>(type: "int", nullable: false),
                    VoucherSubId = table.Column<int>(type: "int", nullable: false)
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
                name: "IX_Acc_ChartOfAccounts_PF_ParentID",
                table: "Acc_ChartOfAccounts_PF",
                column: "ParentID");

            migrationBuilder.CreateIndex(
                name: "IX_Acc_ChartOfAccounts_PF_comid_AccCode",
                table: "Acc_ChartOfAccounts_PF",
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

            migrationBuilder.AddForeignKey(
                name: "FK_Cat_PFIntegrationSummary_Acc_ChartOfAccounts_PF_AccId",
                table: "Cat_PFIntegrationSummary",
                column: "AccId",
                principalTable: "Acc_ChartOfAccounts_PF",
                principalColumn: "AccId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
