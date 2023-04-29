using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace GTERP.Migrations.GTRDB
{
    public partial class AllSalesTableDrop2ndtest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {




            migrationBuilder.AddColumn<int>(
                name: "testid",
                table: "SalesSubs",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");


            Console.WriteLine("80");


            migrationBuilder.AddPrimaryKey(
                name: "PK_SalesSubs",
                table: "SalesSubs",
                column: "testid");

            migrationBuilder.CreateIndex(
                name: "IX_SalesPaymentSubs_AccId",
                table: "SalesPaymentSubs",
                column: "AccId");

            Console.WriteLine("93");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
