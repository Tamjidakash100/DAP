using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class ChartofAccountchangename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Acc_ChartOfAccount_PF_Acc_ChartOfAccount_PF_ParentID",
                table: "Acc_ChartOfAccount_PF");

            migrationBuilder.DropForeignKey(
                name: "FK_Acc_VoucherSub_PF_Acc_ChartOfAccount_PF_AccId",
                table: "Acc_VoucherSub_PF");

            migrationBuilder.DropForeignKey(
                name: "FK_Acc_VoucherSub_PFCheckno_Acc_ChartOfAccount_PF_AccId",
                table: "Acc_VoucherSub_PFCheckno");

            migrationBuilder.DropForeignKey(
                name: "FK_Cat_PFIntegrationSummary_Acc_ChartOfAccount_PF_AccId",
                table: "Cat_PFIntegrationSummary");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Acc_ChartOfAccount_PF",
                table: "Acc_ChartOfAccount_PF");

            migrationBuilder.RenameTable(
                name: "Acc_ChartOfAccount_PF",
                newName: "Acc_ChartOfAccounts_PF");

            migrationBuilder.RenameIndex(
                name: "IX_Acc_ChartOfAccount_PF_comid_AccCode",
                table: "Acc_ChartOfAccounts_PF",
                newName: "IX_Acc_ChartOfAccounts_PF_comid_AccCode");

            migrationBuilder.RenameIndex(
                name: "IX_Acc_ChartOfAccount_PF_ParentID",
                table: "Acc_ChartOfAccounts_PF",
                newName: "IX_Acc_ChartOfAccounts_PF_ParentID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Acc_ChartOfAccounts_PF",
                table: "Acc_ChartOfAccounts_PF",
                column: "AccId");

            migrationBuilder.AddForeignKey(
                name: "FK_Acc_ChartOfAccounts_PF_Acc_ChartOfAccounts_PF_ParentID",
                table: "Acc_ChartOfAccounts_PF",
                column: "ParentID",
                principalTable: "Acc_ChartOfAccounts_PF",
                principalColumn: "AccId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Acc_VoucherSub_PF_Acc_ChartOfAccounts_PF_AccId",
                table: "Acc_VoucherSub_PF",
                column: "AccId",
                principalTable: "Acc_ChartOfAccounts_PF",
                principalColumn: "AccId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Acc_VoucherSub_PFCheckno_Acc_ChartOfAccounts_PF_AccId",
                table: "Acc_VoucherSub_PFCheckno",
                column: "AccId",
                principalTable: "Acc_ChartOfAccounts_PF",
                principalColumn: "AccId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cat_PFIntegrationSummary_Acc_ChartOfAccounts_PF_AccId",
                table: "Cat_PFIntegrationSummary",
                column: "AccId",
                principalTable: "Acc_ChartOfAccounts_PF",
                principalColumn: "AccId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Acc_ChartOfAccounts_PF_Acc_ChartOfAccounts_PF_ParentID",
                table: "Acc_ChartOfAccounts_PF");

            migrationBuilder.DropForeignKey(
                name: "FK_Acc_VoucherSub_PF_Acc_ChartOfAccounts_PF_AccId",
                table: "Acc_VoucherSub_PF");

            migrationBuilder.DropForeignKey(
                name: "FK_Acc_VoucherSub_PFCheckno_Acc_ChartOfAccounts_PF_AccId",
                table: "Acc_VoucherSub_PFCheckno");

            migrationBuilder.DropForeignKey(
                name: "FK_Cat_PFIntegrationSummary_Acc_ChartOfAccounts_PF_AccId",
                table: "Cat_PFIntegrationSummary");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Acc_ChartOfAccounts_PF",
                table: "Acc_ChartOfAccounts_PF");

            migrationBuilder.RenameTable(
                name: "Acc_ChartOfAccounts_PF",
                newName: "Acc_ChartOfAccount_PF");

            migrationBuilder.RenameIndex(
                name: "IX_Acc_ChartOfAccounts_PF_comid_AccCode",
                table: "Acc_ChartOfAccount_PF",
                newName: "IX_Acc_ChartOfAccount_PF_comid_AccCode");

            migrationBuilder.RenameIndex(
                name: "IX_Acc_ChartOfAccounts_PF_ParentID",
                table: "Acc_ChartOfAccount_PF",
                newName: "IX_Acc_ChartOfAccount_PF_ParentID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Acc_ChartOfAccount_PF",
                table: "Acc_ChartOfAccount_PF",
                column: "AccId");

            migrationBuilder.AddForeignKey(
                name: "FK_Acc_ChartOfAccount_PF_Acc_ChartOfAccount_PF_ParentID",
                table: "Acc_ChartOfAccount_PF",
                column: "ParentID",
                principalTable: "Acc_ChartOfAccount_PF",
                principalColumn: "AccId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Acc_VoucherSub_PF_Acc_ChartOfAccount_PF_AccId",
                table: "Acc_VoucherSub_PF",
                column: "AccId",
                principalTable: "Acc_ChartOfAccount_PF",
                principalColumn: "AccId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Acc_VoucherSub_PFCheckno_Acc_ChartOfAccount_PF_AccId",
                table: "Acc_VoucherSub_PFCheckno",
                column: "AccId",
                principalTable: "Acc_ChartOfAccount_PF",
                principalColumn: "AccId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cat_PFIntegrationSummary_Acc_ChartOfAccount_PF_AccId",
                table: "Cat_PFIntegrationSummary",
                column: "AccId",
                principalTable: "Acc_ChartOfAccount_PF",
                principalColumn: "AccId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
