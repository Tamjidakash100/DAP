using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace GTERP.Migrations.GTRDB
{
    public partial class AllSalesTableDrop : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesPaymentSubs_SalesMains_SalesMainSalesId",
                table: "SalesPaymentSubs");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesPaymentSubs_Acc_ChartOfAccounts_vChartofAccountsAccId",
                table: "SalesPaymentSubs");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesTermsSubs_SalesMains_SalesMainSalesId",
                table: "SalesTermsSubs");

            migrationBuilder.DropIndex(
                name: "IX_SalesTermsSubs_SalesMainSalesId",
                table: "SalesTermsSubs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SalesSubs",
                table: "SalesSubs");

            migrationBuilder.DropIndex(
                name: "IX_SalesPaymentSubs_SalesMainSalesId",
                table: "SalesPaymentSubs");

            migrationBuilder.DropIndex(
                name: "IX_SalesPaymentSubs_vChartofAccountsAccId",
                table: "SalesPaymentSubs");

            Console.WriteLine("38");



            migrationBuilder.DropColumn(
                name: "SalesMainSalesId",
                table: "SalesTermsSubs");

            migrationBuilder.DropColumn(
                name: "SalesId",
                table: "SalesSubs");

            migrationBuilder.DropColumn(
                name: "SalesMainSalesId",
                table: "SalesPaymentSubs");

            migrationBuilder.DropColumn(
                name: "vChartofAccountsAccId",
                table: "SalesPaymentSubs");

            Console.WriteLine("53");

           


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesPaymentSubs_Acc_ChartOfAccounts_AccId",
                table: "SalesPaymentSubs");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesPaymentSubs_SalesMains_SalesId",
                table: "SalesPaymentSubs");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesTermsSubs_SalesMains_SalesId",
                table: "SalesTermsSubs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SalesSubs",
                table: "SalesSubs");

            migrationBuilder.DropIndex(
                name: "IX_SalesPaymentSubs_AccId",
                table: "SalesPaymentSubs");

            migrationBuilder.DropIndex(
                name: "IX_SalesPaymentSubs_SalesId",
                table: "SalesPaymentSubs");

            migrationBuilder.DropColumn(
                name: "testid",
                table: "SalesSubs");

            migrationBuilder.AlterColumn<int>(
                name: "SalesId",
                table: "SalesTermsSubs",
                type: "int",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "SalesMainSalesId",
                table: "SalesTermsSubs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SalesId",
                table: "SalesSubs",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "SalesMainSalesId",
                table: "SalesPaymentSubs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "vChartofAccountsAccId",
                table: "SalesPaymentSubs",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SalesSubs",
                table: "SalesSubs",
                column: "SalesId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesTermsSubs_SalesMainSalesId",
                table: "SalesTermsSubs",
                column: "SalesMainSalesId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesPaymentSubs_SalesMainSalesId",
                table: "SalesPaymentSubs",
                column: "SalesMainSalesId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesPaymentSubs_vChartofAccountsAccId",
                table: "SalesPaymentSubs",
                column: "vChartofAccountsAccId");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesPaymentSubs_SalesMains_SalesMainSalesId",
                table: "SalesPaymentSubs",
                column: "SalesMainSalesId",
                principalTable: "SalesMains",
                principalColumn: "SalesId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesPaymentSubs_Acc_ChartOfAccounts_vChartofAccountsAccId",
                table: "SalesPaymentSubs",
                column: "vChartofAccountsAccId",
                principalTable: "Acc_ChartOfAccounts",
                principalColumn: "AccId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesTermsSubs_SalesMains_SalesMainSalesId",
                table: "SalesTermsSubs",
                column: "SalesMainSalesId",
                principalTable: "SalesMains",
                principalColumn: "SalesId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
