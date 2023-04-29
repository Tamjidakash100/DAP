using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class note123remarks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Note1",
                table: "Cat_PayrollIntegrationSummary",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Note2",
                table: "Cat_PayrollIntegrationSummary",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Note3",
                table: "Cat_PayrollIntegrationSummary",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Remarks",
                table: "Cat_PayrollIntegrationSummary",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VoucherTypeId",
                table: "Cat_Integration_Setting_Mains",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cat_Integration_Setting_Mains_VoucherTypeId",
                table: "Cat_Integration_Setting_Mains",
                column: "VoucherTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cat_Integration_Setting_Mains_Acc_VoucherTypes_VoucherTypeId",
                table: "Cat_Integration_Setting_Mains",
                column: "VoucherTypeId",
                principalTable: "Acc_VoucherTypes",
                principalColumn: "VoucherTypeId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cat_Integration_Setting_Mains_Acc_VoucherTypes_VoucherTypeId",
                table: "Cat_Integration_Setting_Mains");

            migrationBuilder.DropIndex(
                name: "IX_Cat_Integration_Setting_Mains_VoucherTypeId",
                table: "Cat_Integration_Setting_Mains");

            migrationBuilder.DropColumn(
                name: "Note1",
                table: "Cat_PayrollIntegrationSummary");

            migrationBuilder.DropColumn(
                name: "Note2",
                table: "Cat_PayrollIntegrationSummary");

            migrationBuilder.DropColumn(
                name: "Note3",
                table: "Cat_PayrollIntegrationSummary");

            migrationBuilder.DropColumn(
                name: "Remarks",
                table: "Cat_PayrollIntegrationSummary");

            migrationBuilder.DropColumn(
                name: "VoucherTypeId",
                table: "Cat_Integration_Setting_Mains");
        }
    }
}
