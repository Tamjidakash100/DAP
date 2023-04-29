using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class AccountsModelAddAccPrefix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesPaymentSubs_ChartOfAccounts_vChartofAccountsAccId",
                table: "SalesPaymentSubs");

            migrationBuilder.DropForeignKey(
                name: "FK_VoucherNoPrefixes_VoucherTypes_VoucherTypeId",
                table: "VoucherNoPrefixes");

            migrationBuilder.DropTable(
                name: "FiscalYears");

            migrationBuilder.DropTable(
                name: "VoucherSubChecnos");

            migrationBuilder.DropTable(
                name: "VoucherSubSections");

            migrationBuilder.DropTable(
                name: "VoucherSubs");

            migrationBuilder.DropTable(
                name: "ChartOfAccounts");

            migrationBuilder.DropTable(
                name: "VoucherMains");

            migrationBuilder.DropTable(
                name: "VoucherTypes");

            migrationBuilder.DropIndex(
                name: "IX_VoucherNoPrefixes_VoucherTypeId",
                table: "VoucherNoPrefixes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FiscalQtrs",
                table: "FiscalQtrs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FiscalMonths",
                table: "FiscalMonths");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FiscalHalfYears",
                table: "FiscalHalfYears");

            migrationBuilder.RenameTable(
                name: "FiscalQtrs",
                newName: "Acc_FiscalQtrs");

            migrationBuilder.RenameTable(
                name: "FiscalMonths",
                newName: "Acc_FiscalMonths");

            migrationBuilder.RenameTable(
                name: "FiscalHalfYears",
                newName: "Acc_FiscalHalfYears");

            migrationBuilder.AddColumn<int>(
                name: "vVoucherTypesVoucherTypeId",
                table: "VoucherNoPrefixes",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Acc_FiscalQtrs",
                table: "Acc_FiscalQtrs",
                column: "FiscalQtrId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Acc_FiscalMonths",
                table: "Acc_FiscalMonths",
                column: "FiscalMonthId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Acc_FiscalHalfYears",
                table: "Acc_FiscalHalfYears",
                column: "FiscalHalfYearId");

            migrationBuilder.CreateTable(
                name: "Acc_ChartOfAccounts",
                columns: table => new
                {
                    AccId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    comid = table.Column<string>(nullable: true),
                    AccName = table.Column<string>(maxLength: 200, nullable: false),
                    AccCode = table.Column<string>(maxLength: 20, nullable: true),
                    AccType = table.Column<string>(maxLength: 1, nullable: true),
                    ParentID = table.Column<int>(nullable: true),
                    ParentCode = table.Column<string>(maxLength: 20, nullable: true),
                    OpDebit = table.Column<float>(nullable: false),
                    OpCredit = table.Column<float>(nullable: false),
                    userid = table.Column<string>(maxLength: 128, nullable: true),
                    useridUpdate = table.Column<string>(maxLength: 128, nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: true),
                    IsItemBS = table.Column<int>(nullable: false),
                    IsItemPL = table.Column<int>(nullable: false),
                    IsItemTA = table.Column<int>(nullable: false),
                    IsItemCS = table.Column<int>(nullable: false),
                    IsShowCOA = table.Column<int>(nullable: false),
                    IsChkRef = table.Column<int>(nullable: false),
                    IsEntryDep = table.Column<int>(nullable: false),
                    IsEntryBankLiability = table.Column<int>(nullable: false),
                    IsSysDefined = table.Column<int>(nullable: false),
                    CountryID = table.Column<int>(nullable: false),
                    CountryIdLocal = table.Column<int>(nullable: false),
                    Rate = table.Column<int>(nullable: false),
                    OpDebitLocal = table.Column<float>(nullable: false),
                    OpCreditLocal = table.Column<float>(nullable: false),
                    isInactive = table.Column<int>(nullable: false),
                    isItemConsumed = table.Column<int>(nullable: false),
                    isItemInventory = table.Column<int>(nullable: false),
                    isShowUg = table.Column<int>(nullable: false),
                    OpDate = table.Column<DateTime>(nullable: false),
                    opFYId = table.Column<int>(nullable: false),
                    Balance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RelatedId = table.Column<int>(nullable: false),
                    Level = table.Column<int>(nullable: true),
                    AccSubId = table.Column<int>(nullable: true),
                    IsCashItem = table.Column<int>(nullable: false),
                    IsBankItem = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acc_ChartOfAccounts", x => x.AccId);
                    table.ForeignKey(
                        name: "FK_Acc_ChartOfAccounts_Acc_ChartOfAccounts_ParentID",
                        column: x => x.ParentID,
                        principalTable: "Acc_ChartOfAccounts",
                        principalColumn: "AccId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Acc_FiscalYears",
                columns: table => new
                {
                    FiscalYearId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FYId = table.Column<int>(nullable: false),
                    FYName = table.Column<string>(nullable: true),
                    OpDate = table.Column<string>(nullable: true),
                    ClDate = table.Column<string>(nullable: true),
                    isWorking = table.Column<bool>(nullable: false),
                    isRunning = table.Column<bool>(nullable: false),
                    RowNo = table.Column<int>(nullable: true),
                    comid = table.Column<string>(nullable: true),
                    userid = table.Column<string>(maxLength: 128, nullable: true),
                    useridUpdate = table.Column<string>(maxLength: 128, nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acc_FiscalYears", x => x.FiscalYearId);
                });

            migrationBuilder.CreateTable(
                name: "Acc_VoucherTypes",
                columns: table => new
                {
                    VoucherTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VoucherTypeName = table.Column<string>(nullable: true),
                    VoucherTypeNameShort = table.Column<string>(nullable: true),
                    VoucherTypeClass = table.Column<string>(nullable: true),
                    VoucherTypeButtonClass = table.Column<string>(nullable: true),
                    isSystem = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acc_VoucherTypes", x => x.VoucherTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Acc_VoucherMains",
                columns: table => new
                {
                    VoucherId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VoucherSerialId = table.Column<int>(nullable: false),
                    VoucherNo = table.Column<string>(maxLength: 16, nullable: true),
                    VoucherDate = table.Column<DateTime>(nullable: false),
                    VoucherInputDate = table.Column<DateTime>(nullable: false),
                    VoucherTypeId = table.Column<int>(nullable: false),
                    PrdUnitId = table.Column<int>(nullable: true),
                    VoucherDesc = table.Column<string>(nullable: true),
                    comid = table.Column<string>(nullable: true),
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
                    Acc_VoucherTypeVoucherTypeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acc_VoucherMains", x => x.VoucherId);
                    table.ForeignKey(
                        name: "FK_Acc_VoucherMains_Acc_VoucherTypes_Acc_VoucherTypeVoucherTypeId",
                        column: x => x.Acc_VoucherTypeVoucherTypeId,
                        principalTable: "Acc_VoucherTypes",
                        principalColumn: "VoucherTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Acc_VoucherMains_PrdUnits_PrdUnitId",
                        column: x => x.PrdUnitId,
                        principalTable: "PrdUnits",
                        principalColumn: "PrdUnitId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Acc_VoucherSubs",
                columns: table => new
                {
                    VoucherSubId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VoucherId = table.Column<int>(nullable: false),
                    AccId = table.Column<int>(nullable: false),
                    Acc_ChartOfAccountAccId = table.Column<int>(nullable: true),
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
                    Acc_VoucherMainVoucherId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acc_VoucherSubs", x => x.VoucherSubId);
                    table.ForeignKey(
                        name: "FK_Acc_VoucherSubs_Acc_ChartOfAccounts_Acc_ChartOfAccountAccId",
                        column: x => x.Acc_ChartOfAccountAccId,
                        principalTable: "Acc_ChartOfAccounts",
                        principalColumn: "AccId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Acc_VoucherSubs_Acc_VoucherMains_Acc_VoucherMainVoucherId",
                        column: x => x.Acc_VoucherMainVoucherId,
                        principalTable: "Acc_VoucherMains",
                        principalColumn: "VoucherId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Acc_VoucherSubs_Countries_CurrencyForeignId",
                        column: x => x.CurrencyForeignId,
                        principalTable: "Countries",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Acc_VoucherSubs_Countries_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Countries",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Acc_VoucherSubChecnos",
                columns: table => new
                {
                    VoucherSubCheckId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VoucherSubId = table.Column<int>(nullable: false),
                    RowNoChk = table.Column<int>(nullable: false),
                    VoucherId = table.Column<int>(nullable: false),
                    AccId = table.Column<int>(nullable: false),
                    SRowNo = table.Column<int>(nullable: false),
                    ChkNo = table.Column<string>(nullable: true),
                    dtChk = table.Column<string>(nullable: true),
                    Remarks = table.Column<string>(nullable: true),
                    Amount = table.Column<double>(nullable: false),
                    Acc_VoucherSubVoucherSubId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acc_VoucherSubChecnos", x => x.VoucherSubCheckId);
                    table.ForeignKey(
                        name: "FK_Acc_VoucherSubChecnos_Acc_VoucherSubs_Acc_VoucherSubVoucherSubId",
                        column: x => x.Acc_VoucherSubVoucherSubId,
                        principalTable: "Acc_VoucherSubs",
                        principalColumn: "VoucherSubId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Acc_VoucherSubSections",
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
                    SubSectionSubSectId = table.Column<int>(nullable: true),
                    Acc_VoucherSubVoucherSubId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acc_VoucherSubSections", x => x.VoucherSubSectionId);
                    table.ForeignKey(
                        name: "FK_Acc_VoucherSubSections_Acc_VoucherSubs_Acc_VoucherSubVoucherSubId",
                        column: x => x.Acc_VoucherSubVoucherSubId,
                        principalTable: "Acc_VoucherSubs",
                        principalColumn: "VoucherSubId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Acc_VoucherSubSections_Cat_SubSection_SubSectionSubSectId",
                        column: x => x.SubSectionSubSectId,
                        principalTable: "Cat_SubSection",
                        principalColumn: "SubSectId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VoucherNoPrefixes_vVoucherTypesVoucherTypeId",
                table: "VoucherNoPrefixes",
                column: "vVoucherTypesVoucherTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Acc_ChartOfAccounts_ParentID",
                table: "Acc_ChartOfAccounts",
                column: "ParentID");

            migrationBuilder.CreateIndex(
                name: "IX_Acc_VoucherMains_Acc_VoucherTypeVoucherTypeId",
                table: "Acc_VoucherMains",
                column: "Acc_VoucherTypeVoucherTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Acc_VoucherMains_PrdUnitId",
                table: "Acc_VoucherMains",
                column: "PrdUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Acc_VoucherSubChecnos_Acc_VoucherSubVoucherSubId",
                table: "Acc_VoucherSubChecnos",
                column: "Acc_VoucherSubVoucherSubId");

            migrationBuilder.CreateIndex(
                name: "IX_Acc_VoucherSubs_Acc_ChartOfAccountAccId",
                table: "Acc_VoucherSubs",
                column: "Acc_ChartOfAccountAccId");

            migrationBuilder.CreateIndex(
                name: "IX_Acc_VoucherSubs_Acc_VoucherMainVoucherId",
                table: "Acc_VoucherSubs",
                column: "Acc_VoucherMainVoucherId");

            migrationBuilder.CreateIndex(
                name: "IX_Acc_VoucherSubs_CurrencyForeignId",
                table: "Acc_VoucherSubs",
                column: "CurrencyForeignId");

            migrationBuilder.CreateIndex(
                name: "IX_Acc_VoucherSubs_CurrencyId",
                table: "Acc_VoucherSubs",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Acc_VoucherSubSections_Acc_VoucherSubVoucherSubId",
                table: "Acc_VoucherSubSections",
                column: "Acc_VoucherSubVoucherSubId");

            migrationBuilder.CreateIndex(
                name: "IX_Acc_VoucherSubSections_SubSectionSubSectId",
                table: "Acc_VoucherSubSections",
                column: "SubSectionSubSectId");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesPaymentSubs_Acc_ChartOfAccounts_vChartofAccountsAccId",
                table: "SalesPaymentSubs",
                column: "vChartofAccountsAccId",
                principalTable: "Acc_ChartOfAccounts",
                principalColumn: "AccId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_VoucherNoPrefixes_Acc_VoucherTypes_vVoucherTypesVoucherTypeId",
                table: "VoucherNoPrefixes",
                column: "vVoucherTypesVoucherTypeId",
                principalTable: "Acc_VoucherTypes",
                principalColumn: "VoucherTypeId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesPaymentSubs_Acc_ChartOfAccounts_vChartofAccountsAccId",
                table: "SalesPaymentSubs");

            migrationBuilder.DropForeignKey(
                name: "FK_VoucherNoPrefixes_Acc_VoucherTypes_vVoucherTypesVoucherTypeId",
                table: "VoucherNoPrefixes");

            migrationBuilder.DropTable(
                name: "Acc_FiscalYears");

            migrationBuilder.DropTable(
                name: "Acc_VoucherSubChecnos");

            migrationBuilder.DropTable(
                name: "Acc_VoucherSubSections");

            migrationBuilder.DropTable(
                name: "Acc_VoucherSubs");

            migrationBuilder.DropTable(
                name: "Acc_ChartOfAccounts");

            migrationBuilder.DropTable(
                name: "Acc_VoucherMains");

            migrationBuilder.DropTable(
                name: "Acc_VoucherTypes");

            migrationBuilder.DropIndex(
                name: "IX_VoucherNoPrefixes_vVoucherTypesVoucherTypeId",
                table: "VoucherNoPrefixes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Acc_FiscalQtrs",
                table: "Acc_FiscalQtrs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Acc_FiscalMonths",
                table: "Acc_FiscalMonths");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Acc_FiscalHalfYears",
                table: "Acc_FiscalHalfYears");

            migrationBuilder.DropColumn(
                name: "vVoucherTypesVoucherTypeId",
                table: "VoucherNoPrefixes");

            migrationBuilder.RenameTable(
                name: "Acc_FiscalQtrs",
                newName: "FiscalQtrs");

            migrationBuilder.RenameTable(
                name: "Acc_FiscalMonths",
                newName: "FiscalMonths");

            migrationBuilder.RenameTable(
                name: "Acc_FiscalHalfYears",
                newName: "FiscalHalfYears");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FiscalQtrs",
                table: "FiscalQtrs",
                column: "FiscalQtrId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FiscalMonths",
                table: "FiscalMonths",
                column: "FiscalMonthId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FiscalHalfYears",
                table: "FiscalHalfYears",
                column: "FiscalHalfYearId");

            migrationBuilder.CreateTable(
                name: "ChartOfAccounts",
                columns: table => new
                {
                    AccId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    AccName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    AccSubId = table.Column<int>(type: "int", nullable: true),
                    AccType = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    Balance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CountryID = table.Column<int>(type: "int", nullable: false),
                    CountryIdLocal = table.Column<int>(type: "int", nullable: false),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsBankItem = table.Column<int>(type: "int", nullable: false),
                    IsCashItem = table.Column<int>(type: "int", nullable: false),
                    IsChkRef = table.Column<int>(type: "int", nullable: false),
                    IsEntryBankLiability = table.Column<int>(type: "int", nullable: false),
                    IsEntryDep = table.Column<int>(type: "int", nullable: false),
                    IsItemBS = table.Column<int>(type: "int", nullable: false),
                    IsItemCS = table.Column<int>(type: "int", nullable: false),
                    IsItemPL = table.Column<int>(type: "int", nullable: false),
                    IsItemTA = table.Column<int>(type: "int", nullable: false),
                    IsShowCOA = table.Column<int>(type: "int", nullable: false),
                    IsSysDefined = table.Column<int>(type: "int", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: true),
                    OpCredit = table.Column<float>(type: "real", nullable: false),
                    OpCreditLocal = table.Column<float>(type: "real", nullable: false),
                    OpDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OpDebit = table.Column<float>(type: "real", nullable: false),
                    OpDebitLocal = table.Column<float>(type: "real", nullable: false),
                    ParentCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    ParentID = table.Column<int>(type: "int", nullable: true),
                    Rate = table.Column<int>(type: "int", nullable: false),
                    RelatedId = table.Column<int>(type: "int", nullable: false),
                    comid = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isInactive = table.Column<int>(type: "int", nullable: false),
                    isItemConsumed = table.Column<int>(type: "int", nullable: false),
                    isItemInventory = table.Column<int>(type: "int", nullable: false),
                    isShowUg = table.Column<int>(type: "int", nullable: false),
                    opFYId = table.Column<int>(type: "int", nullable: false),
                    userid = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    useridUpdate = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChartOfAccounts", x => x.AccId);
                    table.ForeignKey(
                        name: "FK_ChartOfAccounts_ChartOfAccounts_ParentID",
                        column: x => x.ParentID,
                        principalTable: "ChartOfAccounts",
                        principalColumn: "AccId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FiscalYears",
                columns: table => new
                {
                    FiscalYearId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FYId = table.Column<int>(type: "int", nullable: false),
                    FYName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OpDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RowNo = table.Column<int>(type: "int", nullable: true),
                    comid = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isRunning = table.Column<bool>(type: "bit", nullable: false),
                    isWorking = table.Column<bool>(type: "bit", nullable: false),
                    userid = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    useridUpdate = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FiscalYears", x => x.FiscalYearId);
                });

            migrationBuilder.CreateTable(
                name: "VoucherTypes",
                columns: table => new
                {
                    VoucherTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VoucherTypeButtonClass = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VoucherTypeClass = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VoucherTypeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VoucherTypeNameShort = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isSystem = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VoucherTypes", x => x.VoucherTypeId);
                });

            migrationBuilder.CreateTable(
                name: "VoucherMains",
                columns: table => new
                {
                    VoucherId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConvRate = table.Column<double>(type: "float", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    CountryIdLocal = table.Column<int>(type: "int", nullable: false),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                    VoucherNo = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    VoucherSerialId = table.Column<int>(type: "int", nullable: false),
                    VoucherTypeId = table.Column<int>(type: "int", nullable: false),
                    comid = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_VoucherMains", x => x.VoucherId);
                    table.ForeignKey(
                        name: "FK_VoucherMains_PrdUnits_PrdUnitId",
                        column: x => x.PrdUnitId,
                        principalTable: "PrdUnits",
                        principalColumn: "PrdUnitId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VoucherMains_VoucherTypes_VoucherTypeId",
                        column: x => x.VoucherTypeId,
                        principalTable: "VoucherTypes",
                        principalColumn: "VoucherTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VoucherSubs",
                columns: table => new
                {
                    VoucherSubId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccId = table.Column<int>(type: "int", nullable: false),
                    ChartOfAccountAccId = table.Column<int>(type: "int", nullable: true),
                    CurrencyForeignId = table.Column<int>(type: "int", nullable: false),
                    CurrencyId = table.Column<int>(type: "int", nullable: false),
                    CurrencyRate = table.Column<double>(type: "float", nullable: false),
                    Note1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefId = table.Column<int>(type: "int", nullable: true),
                    RowNo = table.Column<int>(type: "int", nullable: true),
                    SRowNo = table.Column<int>(type: "int", nullable: false),
                    TKCredit = table.Column<double>(type: "float", nullable: false),
                    TKCreditLocal = table.Column<double>(type: "float", nullable: false),
                    TKDebit = table.Column<double>(type: "float", nullable: false),
                    TKDebitLocal = table.Column<double>(type: "float", nullable: false),
                    VoucherId = table.Column<int>(type: "int", nullable: false),
                    VoucherMainVoucherId = table.Column<int>(type: "int", nullable: true),
                    ccId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VoucherSubs", x => x.VoucherSubId);
                    table.ForeignKey(
                        name: "FK_VoucherSubs_ChartOfAccounts_ChartOfAccountAccId",
                        column: x => x.ChartOfAccountAccId,
                        principalTable: "ChartOfAccounts",
                        principalColumn: "AccId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VoucherSubs_Countries_CurrencyForeignId",
                        column: x => x.CurrencyForeignId,
                        principalTable: "Countries",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_VoucherSubs_Countries_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Countries",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_VoucherSubs_VoucherMains_VoucherMainVoucherId",
                        column: x => x.VoucherMainVoucherId,
                        principalTable: "VoucherMains",
                        principalColumn: "VoucherId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VoucherSubChecnos",
                columns: table => new
                {
                    VoucherSubCheckId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    ChkNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RowNoChk = table.Column<int>(type: "int", nullable: false),
                    SRowNo = table.Column<int>(type: "int", nullable: false),
                    VoucherId = table.Column<int>(type: "int", nullable: false),
                    VoucherSubId = table.Column<int>(type: "int", nullable: false),
                    dtChk = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VoucherSubChecnos", x => x.VoucherSubCheckId);
                    table.ForeignKey(
                        name: "FK_VoucherSubChecnos_VoucherSubs_VoucherSubId",
                        column: x => x.VoucherSubId,
                        principalTable: "VoucherSubs",
                        principalColumn: "VoucherSubId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VoucherSubSections",
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
                    table.PrimaryKey("PK_VoucherSubSections", x => x.VoucherSubSectionId);
                    table.ForeignKey(
                        name: "FK_VoucherSubSections_Cat_SubSection_SubSectionSubSectId",
                        column: x => x.SubSectionSubSectId,
                        principalTable: "Cat_SubSection",
                        principalColumn: "SubSectId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VoucherSubSections_VoucherSubs_VoucherSubId",
                        column: x => x.VoucherSubId,
                        principalTable: "VoucherSubs",
                        principalColumn: "VoucherSubId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VoucherNoPrefixes_VoucherTypeId",
                table: "VoucherNoPrefixes",
                column: "VoucherTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ChartOfAccounts_ParentID",
                table: "ChartOfAccounts",
                column: "ParentID");

            migrationBuilder.CreateIndex(
                name: "IX_VoucherMains_PrdUnitId",
                table: "VoucherMains",
                column: "PrdUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_VoucherMains_VoucherTypeId",
                table: "VoucherMains",
                column: "VoucherTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_VoucherSubChecnos_VoucherSubId",
                table: "VoucherSubChecnos",
                column: "VoucherSubId");

            migrationBuilder.CreateIndex(
                name: "IX_VoucherSubs_ChartOfAccountAccId",
                table: "VoucherSubs",
                column: "ChartOfAccountAccId");

            migrationBuilder.CreateIndex(
                name: "IX_VoucherSubs_CurrencyForeignId",
                table: "VoucherSubs",
                column: "CurrencyForeignId");

            migrationBuilder.CreateIndex(
                name: "IX_VoucherSubs_CurrencyId",
                table: "VoucherSubs",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_VoucherSubs_VoucherMainVoucherId",
                table: "VoucherSubs",
                column: "VoucherMainVoucherId");

            migrationBuilder.CreateIndex(
                name: "IX_VoucherSubSections_SubSectionSubSectId",
                table: "VoucherSubSections",
                column: "SubSectionSubSectId");

            migrationBuilder.CreateIndex(
                name: "IX_VoucherSubSections_VoucherSubId",
                table: "VoucherSubSections",
                column: "VoucherSubId");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesPaymentSubs_ChartOfAccounts_vChartofAccountsAccId",
                table: "SalesPaymentSubs",
                column: "vChartofAccountsAccId",
                principalTable: "ChartOfAccounts",
                principalColumn: "AccId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_VoucherNoPrefixes_VoucherTypes_VoucherTypeId",
                table: "VoucherNoPrefixes",
                column: "VoucherTypeId",
                principalTable: "VoucherTypes",
                principalColumn: "VoucherTypeId",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
