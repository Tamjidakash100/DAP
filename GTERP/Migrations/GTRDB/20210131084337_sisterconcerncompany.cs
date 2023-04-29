using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class sisterconcerncompany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BankAccountNoLienBanks_CommercialCompany_CommercialCompanyId",
                table: "BankAccountNoLienBanks");

            migrationBuilder.DropForeignKey(
                name: "FK_BankAccountNos_CommercialCompany_CommercialCompanyId",
                table: "BankAccountNos");

            migrationBuilder.DropForeignKey(
                name: "FK_COM_BBLC_Master_CommercialCompany_CommercialCompanyId",
                table: "COM_BBLC_Master");

            migrationBuilder.DropForeignKey(
                name: "FK_COM_CNFBillExportMasters_CommercialCompany_CommercialCompanyId",
                table: "COM_CNFBillExportMasters");

            migrationBuilder.DropForeignKey(
                name: "FK_COM_CNFBillImportMasters_CommercialCompany_CommercialCompanyId",
                table: "COM_CNFBillImportMasters");

            migrationBuilder.DropForeignKey(
                name: "FK_COM_CommercialInvoices_CommercialCompany_CommercialCompanyID",
                table: "COM_CommercialInvoices");

            migrationBuilder.DropForeignKey(
                name: "FK_COM_DocumentAcceptance_Masters_CommercialCompany_CommercialCompanyId",
                table: "COM_DocumentAcceptance_Masters");

            migrationBuilder.DropForeignKey(
                name: "FK_COM_GroupLC_Mains_CommercialCompany_CommercialCompanyId",
                table: "COM_GroupLC_Mains");

            migrationBuilder.DropForeignKey(
                name: "FK_COM_MachinaryLC_Masters_CommercialCompany_CommercialCompanyId",
                table: "COM_MachinaryLC_Masters");

            migrationBuilder.DropForeignKey(
                name: "FK_COM_MasterLCs_CommercialCompany_CommercialCompanyId",
                table: "COM_MasterLCs");

            migrationBuilder.DropForeignKey(
                name: "FK_COM_ProformaInvoices_CommercialCompany_CommercialCompanyId",
                table: "COM_ProformaInvoices");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_CommercialCompany_CommercialCompanyId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_ExportInvoiceMasters_CommercialCompany_CommercialCompanyId",
                table: "ExportInvoiceMasters");

            migrationBuilder.DropForeignKey(
                name: "FK_ExportInvoiceMasters_CommercialCompany_ManufactureId",
                table: "ExportInvoiceMasters");

            migrationBuilder.DropForeignKey(
                name: "FK_StyleInformation_CommercialCompany_CommercialCompanyId",
                table: "StyleInformation");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkOrderMasters_CommercialCompany_CommercialCompanyId",
                table: "WorkOrderMasters");

            migrationBuilder.DropTable(
                name: "ExportRealizationBankInfo");

            migrationBuilder.DropTable(
                name: "CommercialCompany");

            migrationBuilder.DropIndex(
                name: "IX_StyleInformation_CommercialCompanyId",
                table: "StyleInformation");

            migrationBuilder.DropIndex(
                name: "IX_COM_ProformaInvoices_CommercialCompanyId",
                table: "COM_ProformaInvoices");

            migrationBuilder.DropIndex(
                name: "IX_COM_MasterLCs_CommercialCompanyId",
                table: "COM_MasterLCs");

            migrationBuilder.DropIndex(
                name: "IX_COM_MachinaryLC_Masters_CommercialCompanyId",
                table: "COM_MachinaryLC_Masters");

            migrationBuilder.DropIndex(
                name: "IX_COM_GroupLC_Mains_CommercialCompanyId",
                table: "COM_GroupLC_Mains");

            migrationBuilder.DropIndex(
                name: "IX_COM_DocumentAcceptance_Masters_CommercialCompanyId",
                table: "COM_DocumentAcceptance_Masters");

            migrationBuilder.DropIndex(
                name: "IX_COM_CNFBillImportMasters_CommercialCompanyId",
                table: "COM_CNFBillImportMasters");

            migrationBuilder.DropIndex(
                name: "IX_COM_CNFBillExportMasters_CommercialCompanyId",
                table: "COM_CNFBillExportMasters");

            migrationBuilder.DropIndex(
                name: "IX_COM_BBLC_Master_CommercialCompanyId",
                table: "COM_BBLC_Master");

            migrationBuilder.DropIndex(
                name: "IX_BankAccountNos_CommercialCompanyId",
                table: "BankAccountNos");

            migrationBuilder.DropIndex(
                name: "IX_BankAccountNoLienBanks_CommercialCompanyId",
                table: "BankAccountNoLienBanks");

            migrationBuilder.AddColumn<int>(
                name: "CompanySisterConcernCompanyId",
                table: "StyleInformation",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CompanySisterConcernCompanyId",
                table: "COM_ProformaInvoices",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CommercialCompaniesSisterConcernCompanyId",
                table: "COM_MasterLCs",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CompanySisterConcernCompanyId",
                table: "COM_MachinaryLC_Masters",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CompanySisterConcernCompanyId",
                table: "COM_GroupLC_Mains",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CommercialCompanysSisterConcernCompanyId",
                table: "COM_DocumentAcceptance_Masters",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CompaniesSisterConcernCompanyId",
                table: "COM_CNFBillImportMasters",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CompaniesSisterConcernCompanyId",
                table: "COM_CNFBillExportMasters",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CompanySisterConcernCompanyId",
                table: "COM_BBLC_Master",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CommercialCompanysSisterConcernCompanyId",
                table: "BankAccountNos",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CommercialCompanysSisterConcernCompanyId",
                table: "BankAccountNoLienBanks",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PF_Ledgers",
                columns: table => new
                {
                    PFLedgerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BankAccountId = table.Column<int>(nullable: false),
                    VoucherNo = table.Column<string>(nullable: true),
                    ChequeNo = table.Column<string>(nullable: true),
                    Criteria = table.Column<string>(nullable: true),
                    AmountType = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    TranDate = table.Column<DateTime>(nullable: false),
                    Remarks = table.Column<string>(nullable: true),
                    ReceivedTK = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentTK = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Balance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    isPrinciple = table.Column<bool>(nullable: false),
                    comid = table.Column<string>(maxLength: 128, nullable: true),
                    userid = table.Column<string>(maxLength: 128, nullable: true),
                    useridCheck = table.Column<string>(maxLength: 128, nullable: true),
                    useridApprove = table.Column<string>(maxLength: 128, nullable: true),
                    useridUpdate = table.Column<string>(maxLength: 128, nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PF_Ledgers", x => x.PFLedgerId);
                    table.ForeignKey(
                        name: "FK_PF_Ledgers_BankAccountNos_BankAccountId",
                        column: x => x.BankAccountId,
                        principalTable: "BankAccountNos",
                        principalColumn: "BankAccountId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReportPermissions",
                columns: table => new
                {
                    ReportPermissionsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComId = table.Column<Guid>(maxLength: 128, nullable: false),
                    ReportId = table.Column<int>(nullable: false),
                    isChecked = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportPermissions", x => x.ReportPermissionsId);
                });

            migrationBuilder.CreateTable(
                name: "SisterConcernCompany",
                columns: table => new
                {
                    SisterConcernCompanyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(nullable: true),
                    CompanyShortName = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Address2 = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    FaxNumber = table.Column<string>(nullable: true),
                    EmailID = table.Column<string>(nullable: true),
                    Web = table.Column<string>(nullable: true),
                    ContactPerson = table.Column<string>(nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    TradeLicenceNo = table.Column<string>(nullable: true),
                    TINNo = table.Column<string>(nullable: true),
                    comid = table.Column<string>(maxLength: 128, nullable: true),
                    userid = table.Column<string>(maxLength: 128, nullable: true),
                    isDelete = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SisterConcernCompany", x => x.SisterConcernCompanyId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StyleInformation_CompanySisterConcernCompanyId",
                table: "StyleInformation",
                column: "CompanySisterConcernCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_COM_ProformaInvoices_CompanySisterConcernCompanyId",
                table: "COM_ProformaInvoices",
                column: "CompanySisterConcernCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_COM_MasterLCs_CommercialCompaniesSisterConcernCompanyId",
                table: "COM_MasterLCs",
                column: "CommercialCompaniesSisterConcernCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_COM_MachinaryLC_Masters_CompanySisterConcernCompanyId",
                table: "COM_MachinaryLC_Masters",
                column: "CompanySisterConcernCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_COM_GroupLC_Mains_CompanySisterConcernCompanyId",
                table: "COM_GroupLC_Mains",
                column: "CompanySisterConcernCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_COM_DocumentAcceptance_Masters_CommercialCompanysSisterConcernCompanyId",
                table: "COM_DocumentAcceptance_Masters",
                column: "CommercialCompanysSisterConcernCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_COM_CNFBillImportMasters_CompaniesSisterConcernCompanyId",
                table: "COM_CNFBillImportMasters",
                column: "CompaniesSisterConcernCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_COM_CNFBillExportMasters_CompaniesSisterConcernCompanyId",
                table: "COM_CNFBillExportMasters",
                column: "CompaniesSisterConcernCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_COM_BBLC_Master_CompanySisterConcernCompanyId",
                table: "COM_BBLC_Master",
                column: "CompanySisterConcernCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_BankAccountNos_CommercialCompanysSisterConcernCompanyId",
                table: "BankAccountNos",
                column: "CommercialCompanysSisterConcernCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_BankAccountNoLienBanks_CommercialCompanysSisterConcernCompanyId",
                table: "BankAccountNoLienBanks",
                column: "CommercialCompanysSisterConcernCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_PF_Ledgers_BankAccountId",
                table: "PF_Ledgers",
                column: "BankAccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_BankAccountNoLienBanks_SisterConcernCompany_CommercialCompanysSisterConcernCompanyId",
                table: "BankAccountNoLienBanks",
                column: "CommercialCompanysSisterConcernCompanyId",
                principalTable: "SisterConcernCompany",
                principalColumn: "SisterConcernCompanyId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BankAccountNos_SisterConcernCompany_CommercialCompanysSisterConcernCompanyId",
                table: "BankAccountNos",
                column: "CommercialCompanysSisterConcernCompanyId",
                principalTable: "SisterConcernCompany",
                principalColumn: "SisterConcernCompanyId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_COM_BBLC_Master_SisterConcernCompany_CompanySisterConcernCompanyId",
                table: "COM_BBLC_Master",
                column: "CompanySisterConcernCompanyId",
                principalTable: "SisterConcernCompany",
                principalColumn: "SisterConcernCompanyId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_COM_CNFBillExportMasters_SisterConcernCompany_CompaniesSisterConcernCompanyId",
                table: "COM_CNFBillExportMasters",
                column: "CompaniesSisterConcernCompanyId",
                principalTable: "SisterConcernCompany",
                principalColumn: "SisterConcernCompanyId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_COM_CNFBillImportMasters_SisterConcernCompany_CompaniesSisterConcernCompanyId",
                table: "COM_CNFBillImportMasters",
                column: "CompaniesSisterConcernCompanyId",
                principalTable: "SisterConcernCompany",
                principalColumn: "SisterConcernCompanyId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_COM_CommercialInvoices_SisterConcernCompany_CommercialCompanyID",
                table: "COM_CommercialInvoices",
                column: "CommercialCompanyID",
                principalTable: "SisterConcernCompany",
                principalColumn: "SisterConcernCompanyId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_COM_DocumentAcceptance_Masters_SisterConcernCompany_CommercialCompanysSisterConcernCompanyId",
                table: "COM_DocumentAcceptance_Masters",
                column: "CommercialCompanysSisterConcernCompanyId",
                principalTable: "SisterConcernCompany",
                principalColumn: "SisterConcernCompanyId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_COM_GroupLC_Mains_SisterConcernCompany_CompanySisterConcernCompanyId",
                table: "COM_GroupLC_Mains",
                column: "CompanySisterConcernCompanyId",
                principalTable: "SisterConcernCompany",
                principalColumn: "SisterConcernCompanyId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_COM_MachinaryLC_Masters_SisterConcernCompany_CompanySisterConcernCompanyId",
                table: "COM_MachinaryLC_Masters",
                column: "CompanySisterConcernCompanyId",
                principalTable: "SisterConcernCompany",
                principalColumn: "SisterConcernCompanyId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_COM_MasterLCs_SisterConcernCompany_CommercialCompaniesSisterConcernCompanyId",
                table: "COM_MasterLCs",
                column: "CommercialCompaniesSisterConcernCompanyId",
                principalTable: "SisterConcernCompany",
                principalColumn: "SisterConcernCompanyId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_COM_ProformaInvoices_SisterConcernCompany_CompanySisterConcernCompanyId",
                table: "COM_ProformaInvoices",
                column: "CompanySisterConcernCompanyId",
                principalTable: "SisterConcernCompany",
                principalColumn: "SisterConcernCompanyId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_SisterConcernCompany_CommercialCompanyId",
                table: "Employee",
                column: "CommercialCompanyId",
                principalTable: "SisterConcernCompany",
                principalColumn: "SisterConcernCompanyId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExportInvoiceMasters_SisterConcernCompany_CommercialCompanyId",
                table: "ExportInvoiceMasters",
                column: "CommercialCompanyId",
                principalTable: "SisterConcernCompany",
                principalColumn: "SisterConcernCompanyId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExportInvoiceMasters_SisterConcernCompany_ManufactureId",
                table: "ExportInvoiceMasters",
                column: "ManufactureId",
                principalTable: "SisterConcernCompany",
                principalColumn: "SisterConcernCompanyId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StyleInformation_SisterConcernCompany_CompanySisterConcernCompanyId",
                table: "StyleInformation",
                column: "CompanySisterConcernCompanyId",
                principalTable: "SisterConcernCompany",
                principalColumn: "SisterConcernCompanyId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkOrderMasters_SisterConcernCompany_CommercialCompanyId",
                table: "WorkOrderMasters",
                column: "CommercialCompanyId",
                principalTable: "SisterConcernCompany",
                principalColumn: "SisterConcernCompanyId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BankAccountNoLienBanks_SisterConcernCompany_CommercialCompanysSisterConcernCompanyId",
                table: "BankAccountNoLienBanks");

            migrationBuilder.DropForeignKey(
                name: "FK_BankAccountNos_SisterConcernCompany_CommercialCompanysSisterConcernCompanyId",
                table: "BankAccountNos");

            migrationBuilder.DropForeignKey(
                name: "FK_COM_BBLC_Master_SisterConcernCompany_CompanySisterConcernCompanyId",
                table: "COM_BBLC_Master");

            migrationBuilder.DropForeignKey(
                name: "FK_COM_CNFBillExportMasters_SisterConcernCompany_CompaniesSisterConcernCompanyId",
                table: "COM_CNFBillExportMasters");

            migrationBuilder.DropForeignKey(
                name: "FK_COM_CNFBillImportMasters_SisterConcernCompany_CompaniesSisterConcernCompanyId",
                table: "COM_CNFBillImportMasters");

            migrationBuilder.DropForeignKey(
                name: "FK_COM_CommercialInvoices_SisterConcernCompany_CommercialCompanyID",
                table: "COM_CommercialInvoices");

            migrationBuilder.DropForeignKey(
                name: "FK_COM_DocumentAcceptance_Masters_SisterConcernCompany_CommercialCompanysSisterConcernCompanyId",
                table: "COM_DocumentAcceptance_Masters");

            migrationBuilder.DropForeignKey(
                name: "FK_COM_GroupLC_Mains_SisterConcernCompany_CompanySisterConcernCompanyId",
                table: "COM_GroupLC_Mains");

            migrationBuilder.DropForeignKey(
                name: "FK_COM_MachinaryLC_Masters_SisterConcernCompany_CompanySisterConcernCompanyId",
                table: "COM_MachinaryLC_Masters");

            migrationBuilder.DropForeignKey(
                name: "FK_COM_MasterLCs_SisterConcernCompany_CommercialCompaniesSisterConcernCompanyId",
                table: "COM_MasterLCs");

            migrationBuilder.DropForeignKey(
                name: "FK_COM_ProformaInvoices_SisterConcernCompany_CompanySisterConcernCompanyId",
                table: "COM_ProformaInvoices");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_SisterConcernCompany_CommercialCompanyId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_ExportInvoiceMasters_SisterConcernCompany_CommercialCompanyId",
                table: "ExportInvoiceMasters");

            migrationBuilder.DropForeignKey(
                name: "FK_ExportInvoiceMasters_SisterConcernCompany_ManufactureId",
                table: "ExportInvoiceMasters");

            migrationBuilder.DropForeignKey(
                name: "FK_StyleInformation_SisterConcernCompany_CompanySisterConcernCompanyId",
                table: "StyleInformation");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkOrderMasters_SisterConcernCompany_CommercialCompanyId",
                table: "WorkOrderMasters");

            migrationBuilder.DropTable(
                name: "PF_Ledgers");

            migrationBuilder.DropTable(
                name: "ReportPermissions");

            migrationBuilder.DropTable(
                name: "SisterConcernCompany");

            migrationBuilder.DropIndex(
                name: "IX_StyleInformation_CompanySisterConcernCompanyId",
                table: "StyleInformation");

            migrationBuilder.DropIndex(
                name: "IX_COM_ProformaInvoices_CompanySisterConcernCompanyId",
                table: "COM_ProformaInvoices");

            migrationBuilder.DropIndex(
                name: "IX_COM_MasterLCs_CommercialCompaniesSisterConcernCompanyId",
                table: "COM_MasterLCs");

            migrationBuilder.DropIndex(
                name: "IX_COM_MachinaryLC_Masters_CompanySisterConcernCompanyId",
                table: "COM_MachinaryLC_Masters");

            migrationBuilder.DropIndex(
                name: "IX_COM_GroupLC_Mains_CompanySisterConcernCompanyId",
                table: "COM_GroupLC_Mains");

            migrationBuilder.DropIndex(
                name: "IX_COM_DocumentAcceptance_Masters_CommercialCompanysSisterConcernCompanyId",
                table: "COM_DocumentAcceptance_Masters");

            migrationBuilder.DropIndex(
                name: "IX_COM_CNFBillImportMasters_CompaniesSisterConcernCompanyId",
                table: "COM_CNFBillImportMasters");

            migrationBuilder.DropIndex(
                name: "IX_COM_CNFBillExportMasters_CompaniesSisterConcernCompanyId",
                table: "COM_CNFBillExportMasters");

            migrationBuilder.DropIndex(
                name: "IX_COM_BBLC_Master_CompanySisterConcernCompanyId",
                table: "COM_BBLC_Master");

            migrationBuilder.DropIndex(
                name: "IX_BankAccountNos_CommercialCompanysSisterConcernCompanyId",
                table: "BankAccountNos");

            migrationBuilder.DropIndex(
                name: "IX_BankAccountNoLienBanks_CommercialCompanysSisterConcernCompanyId",
                table: "BankAccountNoLienBanks");

            migrationBuilder.DropColumn(
                name: "CompanySisterConcernCompanyId",
                table: "StyleInformation");

            migrationBuilder.DropColumn(
                name: "CompanySisterConcernCompanyId",
                table: "COM_ProformaInvoices");

            migrationBuilder.DropColumn(
                name: "CommercialCompaniesSisterConcernCompanyId",
                table: "COM_MasterLCs");

            migrationBuilder.DropColumn(
                name: "CompanySisterConcernCompanyId",
                table: "COM_MachinaryLC_Masters");

            migrationBuilder.DropColumn(
                name: "CompanySisterConcernCompanyId",
                table: "COM_GroupLC_Mains");

            migrationBuilder.DropColumn(
                name: "CommercialCompanysSisterConcernCompanyId",
                table: "COM_DocumentAcceptance_Masters");

            migrationBuilder.DropColumn(
                name: "CompaniesSisterConcernCompanyId",
                table: "COM_CNFBillImportMasters");

            migrationBuilder.DropColumn(
                name: "CompaniesSisterConcernCompanyId",
                table: "COM_CNFBillExportMasters");

            migrationBuilder.DropColumn(
                name: "CompanySisterConcernCompanyId",
                table: "COM_BBLC_Master");

            migrationBuilder.DropColumn(
                name: "CommercialCompanysSisterConcernCompanyId",
                table: "BankAccountNos");

            migrationBuilder.DropColumn(
                name: "CommercialCompanysSisterConcernCompanyId",
                table: "BankAccountNoLienBanks");

            migrationBuilder.CreateTable(
                name: "CommercialCompany",
                columns: table => new
                {
                    CommercialCompanyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BKMEARegNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyShortName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactPerson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FaxNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IRCNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TINNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TradeLicenceNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VATNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Web = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    comid = table.Column<int>(type: "int", nullable: false),
                    isDelete = table.Column<bool>(type: "bit", nullable: false),
                    userid = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommercialCompany", x => x.CommercialCompanyId);
                });

            migrationBuilder.CreateTable(
                name: "ExportRealizationBankInfo",
                columns: table => new
                {
                    BankRefId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Addedby = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    BBLCMarginAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    BankRefDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BankRefNo = table.Column<string>(type: "VARCHAR(MAX)", maxLength: 200, nullable: false),
                    BuyerGroupId = table.Column<int>(type: "int", nullable: true),
                    CMAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CommercialCompanyId = table.Column<int>(type: "int", nullable: true),
                    CourierDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CourierNo = table.Column<string>(type: "VARCHAR(MAX)", maxLength: 200, nullable: true),
                    CurrencyId = table.Column<int>(type: "int", nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FileNo = table.Column<string>(type: "VARCHAR(MAX)", maxLength: 500, nullable: true),
                    OtherBankCharge = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    RealizationAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    RealizationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Remarks = table.Column<string>(type: "VARCHAR(MAX)", maxLength: 500, nullable: true),
                    TotalValue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Updatedby = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    comid = table.Column<int>(type: "int", nullable: true),
                    isDelete = table.Column<bool>(type: "bit", nullable: false),
                    userid = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    useridUpdate = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExportRealizationBankInfo", x => x.BankRefId);
                    table.ForeignKey(
                        name: "FK_ExportRealizationBankInfo_BuyerGroups_BuyerGroupId",
                        column: x => x.BuyerGroupId,
                        principalTable: "BuyerGroups",
                        principalColumn: "BuyerGroupId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExportRealizationBankInfo_CommercialCompany_CommercialCompanyId",
                        column: x => x.CommercialCompanyId,
                        principalTable: "CommercialCompany",
                        principalColumn: "CommercialCompanyId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExportRealizationBankInfo_Currency_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currency",
                        principalColumn: "CurrencyId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StyleInformation_CommercialCompanyId",
                table: "StyleInformation",
                column: "CommercialCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_COM_ProformaInvoices_CommercialCompanyId",
                table: "COM_ProformaInvoices",
                column: "CommercialCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_COM_MasterLCs_CommercialCompanyId",
                table: "COM_MasterLCs",
                column: "CommercialCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_COM_MachinaryLC_Masters_CommercialCompanyId",
                table: "COM_MachinaryLC_Masters",
                column: "CommercialCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_COM_GroupLC_Mains_CommercialCompanyId",
                table: "COM_GroupLC_Mains",
                column: "CommercialCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_COM_DocumentAcceptance_Masters_CommercialCompanyId",
                table: "COM_DocumentAcceptance_Masters",
                column: "CommercialCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_COM_CNFBillImportMasters_CommercialCompanyId",
                table: "COM_CNFBillImportMasters",
                column: "CommercialCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_COM_CNFBillExportMasters_CommercialCompanyId",
                table: "COM_CNFBillExportMasters",
                column: "CommercialCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_COM_BBLC_Master_CommercialCompanyId",
                table: "COM_BBLC_Master",
                column: "CommercialCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_BankAccountNos_CommercialCompanyId",
                table: "BankAccountNos",
                column: "CommercialCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_BankAccountNoLienBanks_CommercialCompanyId",
                table: "BankAccountNoLienBanks",
                column: "CommercialCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_ExportRealizationBankInfo_BuyerGroupId",
                table: "ExportRealizationBankInfo",
                column: "BuyerGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_ExportRealizationBankInfo_CommercialCompanyId",
                table: "ExportRealizationBankInfo",
                column: "CommercialCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_ExportRealizationBankInfo_CurrencyId",
                table: "ExportRealizationBankInfo",
                column: "CurrencyId");

            migrationBuilder.AddForeignKey(
                name: "FK_BankAccountNoLienBanks_CommercialCompany_CommercialCompanyId",
                table: "BankAccountNoLienBanks",
                column: "CommercialCompanyId",
                principalTable: "CommercialCompany",
                principalColumn: "CommercialCompanyId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BankAccountNos_CommercialCompany_CommercialCompanyId",
                table: "BankAccountNos",
                column: "CommercialCompanyId",
                principalTable: "CommercialCompany",
                principalColumn: "CommercialCompanyId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_COM_BBLC_Master_CommercialCompany_CommercialCompanyId",
                table: "COM_BBLC_Master",
                column: "CommercialCompanyId",
                principalTable: "CommercialCompany",
                principalColumn: "CommercialCompanyId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_COM_CNFBillExportMasters_CommercialCompany_CommercialCompanyId",
                table: "COM_CNFBillExportMasters",
                column: "CommercialCompanyId",
                principalTable: "CommercialCompany",
                principalColumn: "CommercialCompanyId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_COM_CNFBillImportMasters_CommercialCompany_CommercialCompanyId",
                table: "COM_CNFBillImportMasters",
                column: "CommercialCompanyId",
                principalTable: "CommercialCompany",
                principalColumn: "CommercialCompanyId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_COM_CommercialInvoices_CommercialCompany_CommercialCompanyID",
                table: "COM_CommercialInvoices",
                column: "CommercialCompanyID",
                principalTable: "CommercialCompany",
                principalColumn: "CommercialCompanyId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_COM_DocumentAcceptance_Masters_CommercialCompany_CommercialCompanyId",
                table: "COM_DocumentAcceptance_Masters",
                column: "CommercialCompanyId",
                principalTable: "CommercialCompany",
                principalColumn: "CommercialCompanyId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_COM_GroupLC_Mains_CommercialCompany_CommercialCompanyId",
                table: "COM_GroupLC_Mains",
                column: "CommercialCompanyId",
                principalTable: "CommercialCompany",
                principalColumn: "CommercialCompanyId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_COM_MachinaryLC_Masters_CommercialCompany_CommercialCompanyId",
                table: "COM_MachinaryLC_Masters",
                column: "CommercialCompanyId",
                principalTable: "CommercialCompany",
                principalColumn: "CommercialCompanyId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_COM_MasterLCs_CommercialCompany_CommercialCompanyId",
                table: "COM_MasterLCs",
                column: "CommercialCompanyId",
                principalTable: "CommercialCompany",
                principalColumn: "CommercialCompanyId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_COM_ProformaInvoices_CommercialCompany_CommercialCompanyId",
                table: "COM_ProformaInvoices",
                column: "CommercialCompanyId",
                principalTable: "CommercialCompany",
                principalColumn: "CommercialCompanyId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_CommercialCompany_CommercialCompanyId",
                table: "Employee",
                column: "CommercialCompanyId",
                principalTable: "CommercialCompany",
                principalColumn: "CommercialCompanyId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExportInvoiceMasters_CommercialCompany_CommercialCompanyId",
                table: "ExportInvoiceMasters",
                column: "CommercialCompanyId",
                principalTable: "CommercialCompany",
                principalColumn: "CommercialCompanyId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExportInvoiceMasters_CommercialCompany_ManufactureId",
                table: "ExportInvoiceMasters",
                column: "ManufactureId",
                principalTable: "CommercialCompany",
                principalColumn: "CommercialCompanyId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StyleInformation_CommercialCompany_CommercialCompanyId",
                table: "StyleInformation",
                column: "CommercialCompanyId",
                principalTable: "CommercialCompany",
                principalColumn: "CommercialCompanyId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkOrderMasters_CommercialCompany_CommercialCompanyId",
                table: "WorkOrderMasters",
                column: "CommercialCompanyId",
                principalTable: "CommercialCompany",
                principalColumn: "CommercialCompanyId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
