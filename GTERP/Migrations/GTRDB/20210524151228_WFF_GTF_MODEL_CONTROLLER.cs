using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace GTERP.Migrations.GTRDB
{
    public partial class WFF_GTF_MODEL_CONTROLLER : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GTF_ChartOfAccounts",
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
                    table.PrimaryKey("PK_GTF_ChartOfAccounts", x => x.AccId);
                    table.ForeignKey(
                        name: "FK_GTF_ChartOfAccounts_GTF_ChartOfAccounts_ParentID",
                        column: x => x.ParentID,
                        principalTable: "GTF_ChartOfAccounts",
                        principalColumn: "AccId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GTF_VoucherMains",
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
                    table.PrimaryKey("PK_GTF_VoucherMains", x => x.VoucherId);
                    table.ForeignKey(
                        name: "FK_GTF_VoucherMains_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GTF_VoucherMains_Countries_CountryIdLocal",
                        column: x => x.CountryIdLocal,
                        principalTable: "Countries",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GTF_VoucherMains_Acc_FiscalMonths_FiscalMonthId",
                        column: x => x.FiscalMonthId,
                        principalTable: "Acc_FiscalMonths",
                        principalColumn: "FiscalMonthId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GTF_VoucherMains_Acc_FiscalYears_FiscalYearId",
                        column: x => x.FiscalYearId,
                        principalTable: "Acc_FiscalYears",
                        principalColumn: "FiscalYearId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GTF_VoucherMains_PrdUnits_PrdUnitId",
                        column: x => x.PrdUnitId,
                        principalTable: "PrdUnits",
                        principalColumn: "PrdUnitId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GTF_VoucherMains_Acc_VoucherTypes_VoucherTypeId",
                        column: x => x.VoucherTypeId,
                        principalTable: "Acc_VoucherTypes",
                        principalColumn: "VoucherTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WFF_ChartOfAccounts",
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
                    table.PrimaryKey("PK_WFF_ChartOfAccounts", x => x.AccId);
                    table.ForeignKey(
                        name: "FK_WFF_ChartOfAccounts_WFF_ChartOfAccounts_ParentID",
                        column: x => x.ParentID,
                        principalTable: "WFF_ChartOfAccounts",
                        principalColumn: "AccId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WFF_VoucherMains",
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
                    table.PrimaryKey("PK_WFF_VoucherMains", x => x.VoucherId);
                    table.ForeignKey(
                        name: "FK_WFF_VoucherMains_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WFF_VoucherMains_Countries_CountryIdLocal",
                        column: x => x.CountryIdLocal,
                        principalTable: "Countries",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WFF_VoucherMains_Acc_FiscalMonths_FiscalMonthId",
                        column: x => x.FiscalMonthId,
                        principalTable: "Acc_FiscalMonths",
                        principalColumn: "FiscalMonthId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WFF_VoucherMains_Acc_FiscalYears_FiscalYearId",
                        column: x => x.FiscalYearId,
                        principalTable: "Acc_FiscalYears",
                        principalColumn: "FiscalYearId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WFF_VoucherMains_PrdUnits_PrdUnitId",
                        column: x => x.PrdUnitId,
                        principalTable: "PrdUnits",
                        principalColumn: "PrdUnitId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WFF_VoucherMains_Acc_VoucherTypes_VoucherTypeId",
                        column: x => x.VoucherTypeId,
                        principalTable: "Acc_VoucherTypes",
                        principalColumn: "VoucherTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cat_GTFIntegrationSummary",
                columns: table => new
                {
                    Cat_GTFIntegrationSummaryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataType = table.Column<string>(nullable: true),
                    EmployeeType = table.Column<string>(nullable: true),
                    AccId = table.Column<int>(nullable: false),
                    FiscalYearId = table.Column<int>(nullable: true),
                    FiscalMonthId = table.Column<int>(nullable: true),
                    TKDebitLocal = table.Column<double>(nullable: false),
                    TKCreditLocal = table.Column<double>(nullable: false),
                    SLNo = table.Column<string>(nullable: true),
                    ComId = table.Column<string>(nullable: true),
                    PcName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(maxLength: 128, nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    UpdateByUserId = table.Column<string>(nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: true),
                    FromDate = table.Column<DateTime>(nullable: false),
                    ToDate = table.Column<DateTime>(nullable: false),
                    Note1 = table.Column<string>(nullable: true),
                    Note2 = table.Column<string>(nullable: true),
                    Note3 = table.Column<string>(nullable: true),
                    Remarks = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cat_GTFIntegrationSummary", x => x.Cat_GTFIntegrationSummaryId);
                    table.ForeignKey(
                        name: "FK_Cat_GTFIntegrationSummary_GTF_ChartOfAccounts_AccId",
                        column: x => x.AccId,
                        principalTable: "GTF_ChartOfAccounts",
                        principalColumn: "AccId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cat_GTFIntegrationSummary_Acc_FiscalMonths_FiscalMonthId",
                        column: x => x.FiscalMonthId,
                        principalTable: "Acc_FiscalMonths",
                        principalColumn: "FiscalMonthId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cat_GTFIntegrationSummary_Acc_FiscalYears_FiscalYearId",
                        column: x => x.FiscalYearId,
                        principalTable: "Acc_FiscalYears",
                        principalColumn: "FiscalYearId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GTF_VoucherSubs",
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
                    table.PrimaryKey("PK_GTF_VoucherSubs", x => x.VoucherSubId);
                    table.ForeignKey(
                        name: "FK_GTF_VoucherSubs_GTF_ChartOfAccounts_AccId",
                        column: x => x.AccId,
                        principalTable: "GTF_ChartOfAccounts",
                        principalColumn: "AccId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GTF_VoucherSubs_Countries_CurrencyForeignId",
                        column: x => x.CurrencyForeignId,
                        principalTable: "Countries",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GTF_VoucherSubs_Countries_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Countries",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GTF_VoucherSubs_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GTF_VoucherSubs_HR_Emp_Info_EmpId",
                        column: x => x.EmpId,
                        principalTable: "HR_Emp_Info",
                        principalColumn: "EmpId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GTF_VoucherSubs_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "SupplierId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GTF_VoucherSubs_GTF_VoucherMains_VoucherId",
                        column: x => x.VoucherId,
                        principalTable: "GTF_VoucherMains",
                        principalColumn: "VoucherId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cat_WFFIntegrationSummary",
                columns: table => new
                {
                    Cat_WFFIntegrationSummaryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataType = table.Column<string>(nullable: true),
                    EmployeeType = table.Column<string>(nullable: true),
                    AccId = table.Column<int>(nullable: false),
                    FiscalYearId = table.Column<int>(nullable: true),
                    FiscalMonthId = table.Column<int>(nullable: true),
                    TKDebitLocal = table.Column<double>(nullable: false),
                    TKCreditLocal = table.Column<double>(nullable: false),
                    SLNo = table.Column<string>(nullable: true),
                    ComId = table.Column<string>(nullable: true),
                    PcName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(maxLength: 128, nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    UpdateByUserId = table.Column<string>(nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: true),
                    FromDate = table.Column<DateTime>(nullable: false),
                    ToDate = table.Column<DateTime>(nullable: false),
                    Note1 = table.Column<string>(nullable: true),
                    Note2 = table.Column<string>(nullable: true),
                    Note3 = table.Column<string>(nullable: true),
                    Remarks = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cat_WFFIntegrationSummary", x => x.Cat_WFFIntegrationSummaryId);
                    table.ForeignKey(
                        name: "FK_Cat_WFFIntegrationSummary_WFF_ChartOfAccounts_AccId",
                        column: x => x.AccId,
                        principalTable: "WFF_ChartOfAccounts",
                        principalColumn: "AccId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cat_WFFIntegrationSummary_Acc_FiscalMonths_FiscalMonthId",
                        column: x => x.FiscalMonthId,
                        principalTable: "Acc_FiscalMonths",
                        principalColumn: "FiscalMonthId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cat_WFFIntegrationSummary_Acc_FiscalYears_FiscalYearId",
                        column: x => x.FiscalYearId,
                        principalTable: "Acc_FiscalYears",
                        principalColumn: "FiscalYearId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WFF_VoucherSubs",
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
                    table.PrimaryKey("PK_WFF_VoucherSubs", x => x.VoucherSubId);
                    table.ForeignKey(
                        name: "FK_WFF_VoucherSubs_WFF_ChartOfAccounts_AccId",
                        column: x => x.AccId,
                        principalTable: "WFF_ChartOfAccounts",
                        principalColumn: "AccId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WFF_VoucherSubs_Countries_CurrencyForeignId",
                        column: x => x.CurrencyForeignId,
                        principalTable: "Countries",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WFF_VoucherSubs_Countries_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Countries",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WFF_VoucherSubs_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WFF_VoucherSubs_HR_Emp_Info_EmpId",
                        column: x => x.EmpId,
                        principalTable: "HR_Emp_Info",
                        principalColumn: "EmpId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WFF_VoucherSubs_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "SupplierId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WFF_VoucherSubs_WFF_VoucherMains_VoucherId",
                        column: x => x.VoucherId,
                        principalTable: "WFF_VoucherMains",
                        principalColumn: "VoucherId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GTF_VoucherSubChecnos",
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
                    table.PrimaryKey("PK_GTF_VoucherSubChecnos", x => x.VoucherSubCheckId);
                    table.ForeignKey(
                        name: "FK_GTF_VoucherSubChecnos_GTF_ChartOfAccounts_AccId",
                        column: x => x.AccId,
                        principalTable: "GTF_ChartOfAccounts",
                        principalColumn: "AccId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GTF_VoucherSubChecnos_GTF_VoucherSubs_VoucherSubId",
                        column: x => x.VoucherSubId,
                        principalTable: "GTF_VoucherSubs",
                        principalColumn: "VoucherSubId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GTF_VoucherSubSections",
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
                    table.PrimaryKey("PK_GTF_VoucherSubSections", x => x.VoucherSubSectionId);
                    table.ForeignKey(
                        name: "FK_GTF_VoucherSubSections_Cat_SubSection_SubSectionSubSectId",
                        column: x => x.SubSectionSubSectId,
                        principalTable: "Cat_SubSection",
                        principalColumn: "SubSectId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GTF_VoucherSubSections_GTF_VoucherSubs_VoucherSubId",
                        column: x => x.VoucherSubId,
                        principalTable: "GTF_VoucherSubs",
                        principalColumn: "VoucherSubId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WFF_VoucherSubChecnos",
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
                    table.PrimaryKey("PK_WFF_VoucherSubChecnos", x => x.VoucherSubCheckId);
                    table.ForeignKey(
                        name: "FK_WFF_VoucherSubChecnos_WFF_ChartOfAccounts_AccId",
                        column: x => x.AccId,
                        principalTable: "WFF_ChartOfAccounts",
                        principalColumn: "AccId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WFF_VoucherSubChecnos_WFF_VoucherSubs_VoucherSubId",
                        column: x => x.VoucherSubId,
                        principalTable: "WFF_VoucherSubs",
                        principalColumn: "VoucherSubId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WFF_VoucherSubSections",
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
                    table.PrimaryKey("PK_WFF_VoucherSubSections", x => x.VoucherSubSectionId);
                    table.ForeignKey(
                        name: "FK_WFF_VoucherSubSections_Cat_SubSection_SubSectionSubSectId",
                        column: x => x.SubSectionSubSectId,
                        principalTable: "Cat_SubSection",
                        principalColumn: "SubSectId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WFF_VoucherSubSections_WFF_VoucherSubs_VoucherSubId",
                        column: x => x.VoucherSubId,
                        principalTable: "WFF_VoucherSubs",
                        principalColumn: "VoucherSubId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cat_GTFIntegrationSummary_AccId",
                table: "Cat_GTFIntegrationSummary",
                column: "AccId");

            migrationBuilder.CreateIndex(
                name: "IX_Cat_GTFIntegrationSummary_FiscalMonthId",
                table: "Cat_GTFIntegrationSummary",
                column: "FiscalMonthId");

            migrationBuilder.CreateIndex(
                name: "IX_Cat_GTFIntegrationSummary_FiscalYearId",
                table: "Cat_GTFIntegrationSummary",
                column: "FiscalYearId");

            migrationBuilder.CreateIndex(
                name: "IX_Cat_WFFIntegrationSummary_AccId",
                table: "Cat_WFFIntegrationSummary",
                column: "AccId");

            migrationBuilder.CreateIndex(
                name: "IX_Cat_WFFIntegrationSummary_FiscalMonthId",
                table: "Cat_WFFIntegrationSummary",
                column: "FiscalMonthId");

            migrationBuilder.CreateIndex(
                name: "IX_Cat_WFFIntegrationSummary_FiscalYearId",
                table: "Cat_WFFIntegrationSummary",
                column: "FiscalYearId");

            migrationBuilder.CreateIndex(
                name: "IX_GTF_ChartOfAccounts_ParentID",
                table: "GTF_ChartOfAccounts",
                column: "ParentID");

            migrationBuilder.CreateIndex(
                name: "IX_GTF_VoucherMains_CountryId",
                table: "GTF_VoucherMains",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_GTF_VoucherMains_CountryIdLocal",
                table: "GTF_VoucherMains",
                column: "CountryIdLocal");

            migrationBuilder.CreateIndex(
                name: "IX_GTF_VoucherMains_FiscalMonthId",
                table: "GTF_VoucherMains",
                column: "FiscalMonthId");

            migrationBuilder.CreateIndex(
                name: "IX_GTF_VoucherMains_FiscalYearId",
                table: "GTF_VoucherMains",
                column: "FiscalYearId");

            migrationBuilder.CreateIndex(
                name: "IX_GTF_VoucherMains_PrdUnitId",
                table: "GTF_VoucherMains",
                column: "PrdUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_GTF_VoucherMains_VoucherTypeId",
                table: "GTF_VoucherMains",
                column: "VoucherTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_GTF_VoucherSubChecnos_AccId",
                table: "GTF_VoucherSubChecnos",
                column: "AccId");

            migrationBuilder.CreateIndex(
                name: "IX_GTF_VoucherSubChecnos_VoucherSubId",
                table: "GTF_VoucherSubChecnos",
                column: "VoucherSubId");

            migrationBuilder.CreateIndex(
                name: "IX_GTF_VoucherSubs_AccId",
                table: "GTF_VoucherSubs",
                column: "AccId");

            migrationBuilder.CreateIndex(
                name: "IX_GTF_VoucherSubs_CurrencyForeignId",
                table: "GTF_VoucherSubs",
                column: "CurrencyForeignId");

            migrationBuilder.CreateIndex(
                name: "IX_GTF_VoucherSubs_CurrencyId",
                table: "GTF_VoucherSubs",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_GTF_VoucherSubs_CustomerId",
                table: "GTF_VoucherSubs",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_GTF_VoucherSubs_EmpId",
                table: "GTF_VoucherSubs",
                column: "EmpId");

            migrationBuilder.CreateIndex(
                name: "IX_GTF_VoucherSubs_SupplierId",
                table: "GTF_VoucherSubs",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_GTF_VoucherSubs_VoucherId",
                table: "GTF_VoucherSubs",
                column: "VoucherId");

            migrationBuilder.CreateIndex(
                name: "IX_GTF_VoucherSubSections_SubSectionSubSectId",
                table: "GTF_VoucherSubSections",
                column: "SubSectionSubSectId");

            migrationBuilder.CreateIndex(
                name: "IX_GTF_VoucherSubSections_VoucherSubId",
                table: "GTF_VoucherSubSections",
                column: "VoucherSubId");

            migrationBuilder.CreateIndex(
                name: "IX_WFF_ChartOfAccounts_ParentID",
                table: "WFF_ChartOfAccounts",
                column: "ParentID");

            migrationBuilder.CreateIndex(
                name: "IX_WFF_VoucherMains_CountryId",
                table: "WFF_VoucherMains",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_WFF_VoucherMains_CountryIdLocal",
                table: "WFF_VoucherMains",
                column: "CountryIdLocal");

            migrationBuilder.CreateIndex(
                name: "IX_WFF_VoucherMains_FiscalMonthId",
                table: "WFF_VoucherMains",
                column: "FiscalMonthId");

            migrationBuilder.CreateIndex(
                name: "IX_WFF_VoucherMains_FiscalYearId",
                table: "WFF_VoucherMains",
                column: "FiscalYearId");

            migrationBuilder.CreateIndex(
                name: "IX_WFF_VoucherMains_PrdUnitId",
                table: "WFF_VoucherMains",
                column: "PrdUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_WFF_VoucherMains_VoucherTypeId",
                table: "WFF_VoucherMains",
                column: "VoucherTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_WFF_VoucherSubChecnos_AccId",
                table: "WFF_VoucherSubChecnos",
                column: "AccId");

            migrationBuilder.CreateIndex(
                name: "IX_WFF_VoucherSubChecnos_VoucherSubId",
                table: "WFF_VoucherSubChecnos",
                column: "VoucherSubId");

            migrationBuilder.CreateIndex(
                name: "IX_WFF_VoucherSubs_AccId",
                table: "WFF_VoucherSubs",
                column: "AccId");

            migrationBuilder.CreateIndex(
                name: "IX_WFF_VoucherSubs_CurrencyForeignId",
                table: "WFF_VoucherSubs",
                column: "CurrencyForeignId");

            migrationBuilder.CreateIndex(
                name: "IX_WFF_VoucherSubs_CurrencyId",
                table: "WFF_VoucherSubs",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_WFF_VoucherSubs_CustomerId",
                table: "WFF_VoucherSubs",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_WFF_VoucherSubs_EmpId",
                table: "WFF_VoucherSubs",
                column: "EmpId");

            migrationBuilder.CreateIndex(
                name: "IX_WFF_VoucherSubs_SupplierId",
                table: "WFF_VoucherSubs",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_WFF_VoucherSubs_VoucherId",
                table: "WFF_VoucherSubs",
                column: "VoucherId");

            migrationBuilder.CreateIndex(
                name: "IX_WFF_VoucherSubSections_SubSectionSubSectId",
                table: "WFF_VoucherSubSections",
                column: "SubSectionSubSectId");

            migrationBuilder.CreateIndex(
                name: "IX_WFF_VoucherSubSections_VoucherSubId",
                table: "WFF_VoucherSubSections",
                column: "VoucherSubId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cat_GTFIntegrationSummary");

            migrationBuilder.DropTable(
                name: "Cat_WFFIntegrationSummary");

            migrationBuilder.DropTable(
                name: "GTF_VoucherSubChecnos");

            migrationBuilder.DropTable(
                name: "GTF_VoucherSubSections");

            migrationBuilder.DropTable(
                name: "WFF_VoucherSubChecnos");

            migrationBuilder.DropTable(
                name: "WFF_VoucherSubSections");

            migrationBuilder.DropTable(
                name: "GTF_VoucherSubs");

            migrationBuilder.DropTable(
                name: "WFF_VoucherSubs");

            migrationBuilder.DropTable(
                name: "GTF_ChartOfAccounts");

            migrationBuilder.DropTable(
                name: "GTF_VoucherMains");

            migrationBuilder.DropTable(
                name: "WFF_ChartOfAccounts");

            migrationBuilder.DropTable(
                name: "WFF_VoucherMains");
        }
    }
}
