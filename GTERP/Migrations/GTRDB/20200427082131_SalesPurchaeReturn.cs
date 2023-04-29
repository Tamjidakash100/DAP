using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class SalesPurchaeReturn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ComId",
                table: "PurchaseMains",
                newName: "comid");

            migrationBuilder.AddColumn<int>(
                name: "RowNo",
                table: "SalesSubs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "userid",
                table: "PurchaseMains",
                maxLength: 128,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "comid",
                table: "PurchaseMains",
                maxLength: 128,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateAdded",
                table: "PurchaseMains",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdated",
                table: "PurchaseMains",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "useridUpdate",
                table: "PurchaseMains",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "comid",
                table: "PrdUnits",
                maxLength: 128,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "comid",
                table: "Acc_VoucherNoPrefixes",
                maxLength: 128,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "comid",
                table: "Acc_VoucherMains",
                maxLength: 128,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "comid",
                table: "Acc_FiscalYears",
                maxLength: 128,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ComId",
                table: "Acc_FiscalQtrs",
                maxLength: 128,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ComId",
                table: "Acc_FiscalMonths",
                maxLength: 128,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ComId",
                table: "Acc_FiscalHalfYears",
                maxLength: 128,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "comid",
                table: "Acc_ChartOfAccounts",
                maxLength: 128,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "comid",
                table: "Acc_ChartOfAccount_Initials",
                maxLength: 128,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Acc_BudgetMains",
                columns: table => new
                {
                    BudgetId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BudgetSerialId = table.Column<int>(nullable: false),
                    BudgetNo = table.Column<string>(maxLength: 100, nullable: true),
                    BudgetDate = table.Column<DateTime>(nullable: false),
                    FiscalYearId = table.Column<int>(nullable: true),
                    vFiscalYearFiscalYearId = table.Column<int>(nullable: true),
                    FiscalMonthId = table.Column<int>(nullable: true),
                    vFiscalMonthFiscalMonthId = table.Column<int>(nullable: true),
                    PrdUnitId = table.Column<int>(nullable: true),
                    BudgetDesc = table.Column<string>(nullable: true),
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
                    ConvRate = table.Column<double>(nullable: false),
                    VAmountLocal = table.Column<double>(nullable: false),
                    Referance = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acc_BudgetMains", x => x.BudgetId);
                    table.ForeignKey(
                        name: "FK_Acc_BudgetMains_PrdUnits_PrdUnitId",
                        column: x => x.PrdUnitId,
                        principalTable: "PrdUnits",
                        principalColumn: "PrdUnitId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Acc_BudgetMains_Acc_FiscalMonths_vFiscalMonthFiscalMonthId",
                        column: x => x.vFiscalMonthFiscalMonthId,
                        principalTable: "Acc_FiscalMonths",
                        principalColumn: "FiscalMonthId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Acc_BudgetMains_Acc_FiscalYears_vFiscalYearFiscalYearId",
                        column: x => x.vFiscalYearFiscalYearId,
                        principalTable: "Acc_FiscalYears",
                        principalColumn: "FiscalYearId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PurchasePaymentSubs",
                columns: table => new
                {
                    PurchasePaymentSubId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurchaseId = table.Column<int>(nullable: false),
                    PaymentTypeId = table.Column<int>(nullable: false),
                    PaymentCardNo = table.Column<string>(nullable: true),
                    isPosted = table.Column<bool>(nullable: false),
                    AccId = table.Column<int>(nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RowNo = table.Column<int>(nullable: true),
                    ComId = table.Column<string>(maxLength: 128, nullable: false),
                    userid = table.Column<string>(maxLength: 128, nullable: false),
                    PurchaseMainPurchaseId = table.Column<int>(nullable: true),
                    vChartofAccountsAccId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchasePaymentSubs", x => x.PurchasePaymentSubId);
                    table.ForeignKey(
                        name: "FK_PurchasePaymentSubs_PaymentTypes_PaymentTypeId",
                        column: x => x.PaymentTypeId,
                        principalTable: "PaymentTypes",
                        principalColumn: "PaymentTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchasePaymentSubs_PurchaseMains_PurchaseMainPurchaseId",
                        column: x => x.PurchaseMainPurchaseId,
                        principalTable: "PurchaseMains",
                        principalColumn: "PurchaseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchasePaymentSubs_Acc_ChartOfAccounts_vChartofAccountsAccId",
                        column: x => x.vChartofAccountsAccId,
                        principalTable: "Acc_ChartOfAccounts",
                        principalColumn: "AccId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseReturnMains",
                columns: table => new
                {
                    PurchaseReturnId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReferenceNo = table.Column<string>(maxLength: 50, nullable: true),
                    PurchaseReturnNo = table.Column<string>(maxLength: 20, nullable: true),
                    PurchaseReturnDate = table.Column<DateTime>(nullable: false),
                    PurchaseReturnPerson = table.Column<string>(nullable: true),
                    SupplierId = table.Column<int>(nullable: false),
                    SupplierName = table.Column<string>(nullable: true),
                    PrimaryAddress = table.Column<string>(nullable: true),
                    SecoundaryAddress = table.Column<string>(nullable: true),
                    PhoneNo = table.Column<string>(nullable: false),
                    PostalCode = table.Column<string>(maxLength: 50, nullable: true),
                    EmailId = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    CardNo = table.Column<string>(nullable: true),
                    ttlSumQty = table.Column<decimal>(nullable: false),
                    ttlCountQty = table.Column<decimal>(nullable: false),
                    ttlUnitPrice = table.Column<decimal>(nullable: false),
                    ttlIndVat = table.Column<decimal>(nullable: false),
                    ttlIndDisAmt = table.Column<decimal>(nullable: false),
                    ttlIndPrice = table.Column<decimal>(nullable: false),
                    ttlSumAmt = table.Column<decimal>(nullable: false),
                    DisPer = table.Column<decimal>(nullable: false),
                    DisAmt = table.Column<decimal>(nullable: false),
                    ServiceCharge = table.Column<decimal>(nullable: false),
                    Shipping = table.Column<decimal>(nullable: false),
                    TotalVat = table.Column<decimal>(nullable: false),
                    NetAmount = table.Column<decimal>(nullable: false),
                    PaidAmt = table.Column<decimal>(nullable: false),
                    DueAmt = table.Column<decimal>(nullable: false),
                    CountryId = table.Column<int>(nullable: false),
                    CurrencyRate = table.Column<decimal>(nullable: false),
                    NetAmountBDT = table.Column<decimal>(nullable: false),
                    Remarks = table.Column<string>(maxLength: 200, nullable: true),
                    PaidInWords = table.Column<string>(nullable: true),
                    NetInWords = table.Column<string>(nullable: true),
                    ChkPer = table.Column<bool>(nullable: false),
                    comid = table.Column<string>(maxLength: 128, nullable: true),
                    userid = table.Column<string>(maxLength: 128, nullable: true),
                    useridUpdate = table.Column<string>(maxLength: 128, nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: true),
                    AccountId = table.Column<int>(nullable: false),
                    SupplierContactId = table.Column<int>(nullable: false),
                    isPost = table.Column<bool>(nullable: false),
                    isDirectReturn = table.Column<bool>(nullable: false),
                    PurchaseId = table.Column<int>(nullable: true),
                    vPurchaseMainsPurchaseId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseReturnMains", x => x.PurchaseReturnId);
                    table.ForeignKey(
                        name: "FK_PurchaseReturnMains_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseReturnMains_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "SupplierId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseReturnMains_PurchaseMains_vPurchaseMainsPurchaseId",
                        column: x => x.vPurchaseMainsPurchaseId,
                        principalTable: "PurchaseMains",
                        principalColumn: "PurchaseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SalesReturnMains",
                columns: table => new
                {
                    SalesReturnId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReferenceNo = table.Column<string>(maxLength: 50, nullable: true),
                    SalesReturnNo = table.Column<string>(maxLength: 20, nullable: true),
                    SalesReturnDate = table.Column<DateTime>(nullable: false),
                    SalesReturnPerson = table.Column<string>(nullable: true),
                    CustomerId = table.Column<int>(nullable: false),
                    CustomerName = table.Column<string>(nullable: true),
                    PrimaryAddress = table.Column<string>(nullable: true),
                    SecoundaryAddress = table.Column<string>(nullable: true),
                    PhoneNo = table.Column<string>(nullable: false),
                    PostalCode = table.Column<string>(maxLength: 50, nullable: true),
                    EmailId = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    CardNo = table.Column<string>(nullable: true),
                    ttlSumQty = table.Column<decimal>(nullable: false),
                    ttlCountQty = table.Column<decimal>(nullable: false),
                    ttlUnitPrice = table.Column<decimal>(nullable: false),
                    ttlIndVat = table.Column<decimal>(nullable: false),
                    ttlIndDisAmt = table.Column<decimal>(nullable: false),
                    ttlIndPrice = table.Column<decimal>(nullable: false),
                    ttlSumAmt = table.Column<decimal>(nullable: false),
                    DisPer = table.Column<decimal>(nullable: false),
                    DisAmt = table.Column<decimal>(nullable: false),
                    ServiceCharge = table.Column<decimal>(nullable: false),
                    Shipping = table.Column<decimal>(nullable: false),
                    TotalVat = table.Column<decimal>(nullable: false),
                    NetAmount = table.Column<decimal>(nullable: false),
                    PaidAmt = table.Column<decimal>(nullable: false),
                    DueAmt = table.Column<decimal>(nullable: false),
                    CountryId = table.Column<int>(nullable: false),
                    CurrencyRate = table.Column<decimal>(nullable: false),
                    NetAmountBDT = table.Column<decimal>(nullable: false),
                    Remarks = table.Column<string>(maxLength: 200, nullable: true),
                    PaidInWords = table.Column<string>(nullable: true),
                    NetInWords = table.Column<string>(nullable: true),
                    ChkPer = table.Column<bool>(nullable: false),
                    comid = table.Column<string>(maxLength: 128, nullable: true),
                    userid = table.Column<string>(maxLength: 128, nullable: true),
                    useridUpdate = table.Column<string>(maxLength: 128, nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: true),
                    AccountId = table.Column<int>(nullable: false),
                    CustomerContactId = table.Column<int>(nullable: false),
                    isPost = table.Column<bool>(nullable: false),
                    isDirectReturn = table.Column<bool>(nullable: false),
                    SalesId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesReturnMains", x => x.SalesReturnId);
                    table.ForeignKey(
                        name: "FK_SalesReturnMains_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesReturnMains_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesReturnMains_SalesMains_SalesId",
                        column: x => x.SalesId,
                        principalTable: "SalesMains",
                        principalColumn: "SalesId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Acc_BudgetSubs",
                columns: table => new
                {
                    BudgetSubId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BudgetId = table.Column<int>(nullable: false),
                    AccId = table.Column<int>(nullable: false),
                    ChartOfAccountAccId = table.Column<int>(nullable: true),
                    SRowNo = table.Column<int>(nullable: false),
                    CurrencyId = table.Column<int>(nullable: false),
                    CurrencyForeignId = table.Column<int>(nullable: false),
                    TKDebit = table.Column<double>(nullable: false),
                    TKCredit = table.Column<double>(nullable: false),
                    TKDebitLocal = table.Column<double>(nullable: false),
                    TKCreditLocal = table.Column<double>(nullable: false),
                    CurrencyRate = table.Column<double>(nullable: false),
                    Note1 = table.Column<string>(nullable: true),
                    Note2 = table.Column<string>(nullable: true),
                    RowNo = table.Column<int>(nullable: true),
                    Acc_BudgetMainBudgetId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acc_BudgetSubs", x => x.BudgetSubId);
                    table.ForeignKey(
                        name: "FK_Acc_BudgetSubs_Acc_BudgetMains_Acc_BudgetMainBudgetId",
                        column: x => x.Acc_BudgetMainBudgetId,
                        principalTable: "Acc_BudgetMains",
                        principalColumn: "BudgetId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Acc_BudgetSubs_Acc_ChartOfAccounts_ChartOfAccountAccId",
                        column: x => x.ChartOfAccountAccId,
                        principalTable: "Acc_ChartOfAccounts",
                        principalColumn: "AccId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Acc_BudgetSubs_Countries_CurrencyForeignId",
                        column: x => x.CurrencyForeignId,
                        principalTable: "Countries",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Acc_BudgetSubs_Countries_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Countries",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseReturnPaymentSubs",
                columns: table => new
                {
                    PurchaseReturnPaymentSubId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurchaseReturnId = table.Column<int>(nullable: false),
                    PaymentTypeId = table.Column<int>(nullable: false),
                    PaymentCardNo = table.Column<string>(nullable: true),
                    isPosted = table.Column<bool>(nullable: false),
                    AccId = table.Column<int>(nullable: true),
                    Amount = table.Column<decimal>(nullable: false),
                    RowNo = table.Column<int>(nullable: true),
                    comid = table.Column<string>(maxLength: 128, nullable: false),
                    userid = table.Column<string>(maxLength: 128, nullable: false),
                    PurchaseReturnMainPurchaseReturnId = table.Column<int>(nullable: true),
                    vChartofAccountsAccId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseReturnPaymentSubs", x => x.PurchaseReturnPaymentSubId);
                    table.ForeignKey(
                        name: "FK_PurchaseReturnPaymentSubs_PaymentTypes_PaymentTypeId",
                        column: x => x.PaymentTypeId,
                        principalTable: "PaymentTypes",
                        principalColumn: "PaymentTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseReturnPaymentSubs_PurchaseReturnMains_PurchaseReturnMainPurchaseReturnId",
                        column: x => x.PurchaseReturnMainPurchaseReturnId,
                        principalTable: "PurchaseReturnMains",
                        principalColumn: "PurchaseReturnId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseReturnPaymentSubs_Acc_ChartOfAccounts_vChartofAccountsAccId",
                        column: x => x.vChartofAccountsAccId,
                        principalTable: "Acc_ChartOfAccounts",
                        principalColumn: "AccId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseReturnSubs",
                columns: table => new
                {
                    PurchaseReturnSubId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurchaseReturnId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    SalesTypeId = table.Column<int>(nullable: true),
                    WarehouseId = table.Column<int>(nullable: false),
                    ProductSerialId = table.Column<int>(nullable: true),
                    ProductDescription = table.Column<string>(nullable: true),
                    Size = table.Column<string>(nullable: true),
                    Carton = table.Column<string>(nullable: true),
                    PCTN = table.Column<string>(nullable: true),
                    Qty = table.Column<int>(nullable: false),
                    UnitPrice = table.Column<decimal>(nullable: false),
                    IndVatPer = table.Column<decimal>(nullable: false),
                    IndVat = table.Column<decimal>(nullable: false),
                    IndDisPer = table.Column<decimal>(nullable: false),
                    IndDisAmt = table.Column<decimal>(nullable: false),
                    IndPrice = table.Column<decimal>(nullable: false),
                    IndChkPer = table.Column<int>(nullable: false),
                    Amount = table.Column<decimal>(nullable: false),
                    PurchaseReturnMainPurchaseReturnId = table.Column<int>(nullable: true),
                    RowNo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseReturnSubs", x => x.PurchaseReturnSubId);
                    table.ForeignKey(
                        name: "FK_PurchaseReturnSubs_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseReturnSubs_ProductSerial_ProductSerialId",
                        column: x => x.ProductSerialId,
                        principalTable: "ProductSerial",
                        principalColumn: "ProductSerialId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseReturnSubs_PurchaseReturnMains_PurchaseReturnMainPurchaseReturnId",
                        column: x => x.PurchaseReturnMainPurchaseReturnId,
                        principalTable: "PurchaseReturnMains",
                        principalColumn: "PurchaseReturnId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseReturnSubs_Warehouses_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "WarehouseId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseReturnTermsSubs",
                columns: table => new
                {
                    PurchaseReturnTermsSubId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurchaseReturnId = table.Column<int>(nullable: false),
                    Terms = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    RowNo = table.Column<int>(nullable: false),
                    PurchaseReturnMainPurchaseReturnId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseReturnTermsSubs", x => x.PurchaseReturnTermsSubId);
                    table.ForeignKey(
                        name: "FK_PurchaseReturnTermsSubs_PurchaseReturnMains_PurchaseReturnMainPurchaseReturnId",
                        column: x => x.PurchaseReturnMainPurchaseReturnId,
                        principalTable: "PurchaseReturnMains",
                        principalColumn: "PurchaseReturnId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SalesReturnPaymentSubs",
                columns: table => new
                {
                    SalesReturnPaymentSubId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalesReturnId = table.Column<int>(nullable: false),
                    PaymentTypeId = table.Column<int>(nullable: false),
                    PaymentCardNo = table.Column<string>(nullable: true),
                    isPosted = table.Column<bool>(nullable: false),
                    AccId = table.Column<int>(nullable: true),
                    Amount = table.Column<decimal>(nullable: false),
                    RowNo = table.Column<int>(nullable: true),
                    comid = table.Column<string>(maxLength: 128, nullable: false),
                    userid = table.Column<string>(maxLength: 128, nullable: false),
                    SalesReturnMainSalesReturnId = table.Column<int>(nullable: true),
                    vChartofAccountsAccId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesReturnPaymentSubs", x => x.SalesReturnPaymentSubId);
                    table.ForeignKey(
                        name: "FK_SalesReturnPaymentSubs_PaymentTypes_PaymentTypeId",
                        column: x => x.PaymentTypeId,
                        principalTable: "PaymentTypes",
                        principalColumn: "PaymentTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesReturnPaymentSubs_SalesReturnMains_SalesReturnMainSalesReturnId",
                        column: x => x.SalesReturnMainSalesReturnId,
                        principalTable: "SalesReturnMains",
                        principalColumn: "SalesReturnId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalesReturnPaymentSubs_Acc_ChartOfAccounts_vChartofAccountsAccId",
                        column: x => x.vChartofAccountsAccId,
                        principalTable: "Acc_ChartOfAccounts",
                        principalColumn: "AccId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SalesReturnSubs",
                columns: table => new
                {
                    SalesReturnSubId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalesReturnId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    SalesTypeId = table.Column<int>(nullable: false),
                    WarehouseId = table.Column<int>(nullable: false),
                    ProductSerialId = table.Column<int>(nullable: true),
                    ProductDescription = table.Column<string>(nullable: true),
                    Size = table.Column<string>(nullable: true),
                    Carton = table.Column<string>(nullable: true),
                    PCTN = table.Column<string>(nullable: true),
                    Qty = table.Column<int>(nullable: false),
                    UnitPrice = table.Column<decimal>(nullable: false),
                    IndVatPer = table.Column<decimal>(nullable: false),
                    IndVat = table.Column<decimal>(nullable: false),
                    IndDisPer = table.Column<decimal>(nullable: false),
                    IndDisAmt = table.Column<decimal>(nullable: false),
                    IndPrice = table.Column<decimal>(nullable: false),
                    IndChkPer = table.Column<int>(nullable: false),
                    Amount = table.Column<decimal>(nullable: false),
                    SalesReturnMainSalesReturnId = table.Column<int>(nullable: true),
                    RowNo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesReturnSubs", x => x.SalesReturnSubId);
                    table.ForeignKey(
                        name: "FK_SalesReturnSubs_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesReturnSubs_ProductSerial_ProductSerialId",
                        column: x => x.ProductSerialId,
                        principalTable: "ProductSerial",
                        principalColumn: "ProductSerialId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesReturnSubs_SalesReturnMains_SalesReturnMainSalesReturnId",
                        column: x => x.SalesReturnMainSalesReturnId,
                        principalTable: "SalesReturnMains",
                        principalColumn: "SalesReturnId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalesReturnSubs_SalesType_SalesTypeId",
                        column: x => x.SalesTypeId,
                        principalTable: "SalesType",
                        principalColumn: "SalesTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesReturnSubs_Warehouses_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "WarehouseId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SalesReturnTermsSubs",
                columns: table => new
                {
                    SalesReturnTermsSubId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalesReturnId = table.Column<int>(nullable: false),
                    Terms = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    RowNo = table.Column<int>(nullable: false),
                    SalesReturnMainSalesReturnId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesReturnTermsSubs", x => x.SalesReturnTermsSubId);
                    table.ForeignKey(
                        name: "FK_SalesReturnTermsSubs_SalesReturnMains_SalesReturnMainSalesReturnId",
                        column: x => x.SalesReturnMainSalesReturnId,
                        principalTable: "SalesReturnMains",
                        principalColumn: "SalesReturnId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Acc_BudgetSubSections",
                columns: table => new
                {
                    BudgetSubSectionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BudgetSubId = table.Column<int>(nullable: false),
                    RowNoSSec = table.Column<int>(nullable: false),
                    BudgetId = table.Column<int>(nullable: false),
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
                    table.PrimaryKey("PK_Acc_BudgetSubSections", x => x.BudgetSubSectionId);
                    table.ForeignKey(
                        name: "FK_Acc_BudgetSubSections_Acc_BudgetSubs_BudgetSubId",
                        column: x => x.BudgetSubId,
                        principalTable: "Acc_BudgetSubs",
                        principalColumn: "BudgetSubId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Acc_BudgetSubSections_Cat_SubSection_SubSectionSubSectId",
                        column: x => x.SubSectionSubSectId,
                        principalTable: "Cat_SubSection",
                        principalColumn: "SubSectId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Acc_BudgetMains_PrdUnitId",
                table: "Acc_BudgetMains",
                column: "PrdUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Acc_BudgetMains_vFiscalMonthFiscalMonthId",
                table: "Acc_BudgetMains",
                column: "vFiscalMonthFiscalMonthId");

            migrationBuilder.CreateIndex(
                name: "IX_Acc_BudgetMains_vFiscalYearFiscalYearId",
                table: "Acc_BudgetMains",
                column: "vFiscalYearFiscalYearId");

            migrationBuilder.CreateIndex(
                name: "IX_Acc_BudgetSubs_Acc_BudgetMainBudgetId",
                table: "Acc_BudgetSubs",
                column: "Acc_BudgetMainBudgetId");

            migrationBuilder.CreateIndex(
                name: "IX_Acc_BudgetSubs_ChartOfAccountAccId",
                table: "Acc_BudgetSubs",
                column: "ChartOfAccountAccId");

            migrationBuilder.CreateIndex(
                name: "IX_Acc_BudgetSubs_CurrencyForeignId",
                table: "Acc_BudgetSubs",
                column: "CurrencyForeignId");

            migrationBuilder.CreateIndex(
                name: "IX_Acc_BudgetSubs_CurrencyId",
                table: "Acc_BudgetSubs",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Acc_BudgetSubSections_BudgetSubId",
                table: "Acc_BudgetSubSections",
                column: "BudgetSubId");

            migrationBuilder.CreateIndex(
                name: "IX_Acc_BudgetSubSections_SubSectionSubSectId",
                table: "Acc_BudgetSubSections",
                column: "SubSectionSubSectId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchasePaymentSubs_PaymentTypeId",
                table: "PurchasePaymentSubs",
                column: "PaymentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchasePaymentSubs_PurchaseMainPurchaseId",
                table: "PurchasePaymentSubs",
                column: "PurchaseMainPurchaseId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchasePaymentSubs_vChartofAccountsAccId",
                table: "PurchasePaymentSubs",
                column: "vChartofAccountsAccId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseReturnMains_CountryId",
                table: "PurchaseReturnMains",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseReturnMains_SupplierId",
                table: "PurchaseReturnMains",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseReturnMains_vPurchaseMainsPurchaseId",
                table: "PurchaseReturnMains",
                column: "vPurchaseMainsPurchaseId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseReturnPaymentSubs_PaymentTypeId",
                table: "PurchaseReturnPaymentSubs",
                column: "PaymentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseReturnPaymentSubs_PurchaseReturnMainPurchaseReturnId",
                table: "PurchaseReturnPaymentSubs",
                column: "PurchaseReturnMainPurchaseReturnId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseReturnPaymentSubs_vChartofAccountsAccId",
                table: "PurchaseReturnPaymentSubs",
                column: "vChartofAccountsAccId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseReturnSubs_ProductId",
                table: "PurchaseReturnSubs",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseReturnSubs_ProductSerialId",
                table: "PurchaseReturnSubs",
                column: "ProductSerialId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseReturnSubs_PurchaseReturnMainPurchaseReturnId",
                table: "PurchaseReturnSubs",
                column: "PurchaseReturnMainPurchaseReturnId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseReturnSubs_WarehouseId",
                table: "PurchaseReturnSubs",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseReturnTermsSubs_PurchaseReturnMainPurchaseReturnId",
                table: "PurchaseReturnTermsSubs",
                column: "PurchaseReturnMainPurchaseReturnId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesReturnMains_CountryId",
                table: "SalesReturnMains",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesReturnMains_CustomerId",
                table: "SalesReturnMains",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesReturnMains_SalesId",
                table: "SalesReturnMains",
                column: "SalesId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesReturnPaymentSubs_PaymentTypeId",
                table: "SalesReturnPaymentSubs",
                column: "PaymentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesReturnPaymentSubs_SalesReturnMainSalesReturnId",
                table: "SalesReturnPaymentSubs",
                column: "SalesReturnMainSalesReturnId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesReturnPaymentSubs_vChartofAccountsAccId",
                table: "SalesReturnPaymentSubs",
                column: "vChartofAccountsAccId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesReturnSubs_ProductId",
                table: "SalesReturnSubs",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesReturnSubs_ProductSerialId",
                table: "SalesReturnSubs",
                column: "ProductSerialId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesReturnSubs_SalesReturnMainSalesReturnId",
                table: "SalesReturnSubs",
                column: "SalesReturnMainSalesReturnId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesReturnSubs_SalesTypeId",
                table: "SalesReturnSubs",
                column: "SalesTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesReturnSubs_WarehouseId",
                table: "SalesReturnSubs",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesReturnTermsSubs_SalesReturnMainSalesReturnId",
                table: "SalesReturnTermsSubs",
                column: "SalesReturnMainSalesReturnId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Acc_BudgetSubSections");

            migrationBuilder.DropTable(
                name: "PurchasePaymentSubs");

            migrationBuilder.DropTable(
                name: "PurchaseReturnPaymentSubs");

            migrationBuilder.DropTable(
                name: "PurchaseReturnSubs");

            migrationBuilder.DropTable(
                name: "PurchaseReturnTermsSubs");

            migrationBuilder.DropTable(
                name: "SalesReturnPaymentSubs");

            migrationBuilder.DropTable(
                name: "SalesReturnSubs");

            migrationBuilder.DropTable(
                name: "SalesReturnTermsSubs");

            migrationBuilder.DropTable(
                name: "Acc_BudgetSubs");

            migrationBuilder.DropTable(
                name: "PurchaseReturnMains");

            migrationBuilder.DropTable(
                name: "SalesReturnMains");

            migrationBuilder.DropTable(
                name: "Acc_BudgetMains");

            migrationBuilder.DropColumn(
                name: "RowNo",
                table: "SalesSubs");

            migrationBuilder.DropColumn(
                name: "DateAdded",
                table: "PurchaseMains");

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "PurchaseMains");

            migrationBuilder.DropColumn(
                name: "useridUpdate",
                table: "PurchaseMains");

            migrationBuilder.RenameColumn(
                name: "comid",
                table: "PurchaseMains",
                newName: "ComId");

            migrationBuilder.AlterColumn<string>(
                name: "userid",
                table: "PurchaseMains",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 128,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ComId",
                table: "PurchaseMains",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 128,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "comid",
                table: "PrdUnits",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 128,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "comid",
                table: "Acc_VoucherNoPrefixes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 128,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "comid",
                table: "Acc_VoucherMains",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 128,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "comid",
                table: "Acc_FiscalYears",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 128,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ComId",
                table: "Acc_FiscalQtrs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 128,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ComId",
                table: "Acc_FiscalMonths",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 128,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ComId",
                table: "Acc_FiscalHalfYears",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 128,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "comid",
                table: "Acc_ChartOfAccounts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 128,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "comid",
                table: "Acc_ChartOfAccount_Initials",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 128,
                oldNullable: true);
        }
    }
}
