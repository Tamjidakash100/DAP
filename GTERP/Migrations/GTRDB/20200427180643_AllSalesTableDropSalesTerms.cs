using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace GTERP.Migrations.GTRDB
{
    public partial class AllSalesTableDropSalesTerms : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropColumn(
            //name: "SalesId",
            //table: "SalesTermsSubs");


            //migrationBuilder.AddColumn<int>(
            //    name: "SalesId",
            //    table: "SalesTermsSubs",
            //    nullable: false,
            //    defaultValue: 0)
            //    .Annotation("SqlServer:Identity", "1, 1");


            ////migrationBuilder.AlterColumn<int>(
            ////               name: "SalesId",
            ////               table: "SalesTermsSubs",
            ////               nullable: false,
            ////               oldClrType: typeof(int),
            ////               oldType: "int")
            ////               .OldAnnotation("SqlServer:Identity", "1, 1");

            //Console.WriteLine("68");




            //migrationBuilder.AddForeignKey(
            //    name: "FK_SalesTermsSubs_SalesMains_SalesId",
            //    table: "SalesTermsSubs",
            //    column: "SalesId",
            //    principalTable: "SalesMains",
            //    principalColumn: "SalesId",
            //    onDelete: ReferentialAction.Cascade);


            //Console.WriteLine("final");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
