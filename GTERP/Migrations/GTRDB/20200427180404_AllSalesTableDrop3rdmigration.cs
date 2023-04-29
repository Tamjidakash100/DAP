using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace GTERP.Migrations.GTRDB
{
    public partial class AllSalesTableDrop3rdmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                           name: "IX_SalesPaymentSubs_SalesId",
                           table: "SalesPaymentSubs",
                           column: "SalesId");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesPaymentSubs_Acc_ChartOfAccounts_AccId",
                table: "SalesPaymentSubs",
                column: "AccId",
                principalTable: "Acc_ChartOfAccounts",
                principalColumn: "AccId",
                onDelete: ReferentialAction.Restrict);


            Console.WriteLine("111");



            migrationBuilder.AddForeignKey(
                name: "FK_SalesPaymentSubs_SalesMains_SalesId",
                table: "SalesPaymentSubs",
                column: "SalesId",
                principalTable: "SalesMains",
                principalColumn: "SalesId",
                onDelete: ReferentialAction.Cascade);

            Console.WriteLine("123");




        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
