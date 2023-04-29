using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class FAfieldsadd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AnticipatedScrapValue",
                table: "fA_Masters",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ControlCodeNo",
                table: "fA_Masters",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CostCenter",
                table: "fA_Masters",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CountyOfOrigin",
                table: "fA_Masters",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeliveryDate",
                table: "fA_Masters",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DepreciationRate",
                table: "fA_Masters",
                maxLength: 5,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DisposalDate",
                table: "fA_Masters",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ErectionContractor",
                table: "fA_Masters",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Folio",
                table: "fA_Masters",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ForeignExchangeCost",
                table: "fA_Masters",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdentificationCode",
                table: "fA_Masters",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "InstallationDate",
                table: "fA_Masters",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ItemNo",
                table: "fA_Masters",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "fA_Masters",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Maker",
                table: "fA_Masters",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Mark",
                table: "fA_Masters",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PONoAndDate",
                table: "fA_Masters",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SubCodeNo",
                table: "fA_Masters",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SupplierName",
                table: "fA_Masters",
                maxLength: 200,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnticipatedScrapValue",
                table: "fA_Masters");

            migrationBuilder.DropColumn(
                name: "ControlCodeNo",
                table: "fA_Masters");

            migrationBuilder.DropColumn(
                name: "CostCenter",
                table: "fA_Masters");

            migrationBuilder.DropColumn(
                name: "CountyOfOrigin",
                table: "fA_Masters");

            migrationBuilder.DropColumn(
                name: "DeliveryDate",
                table: "fA_Masters");

            migrationBuilder.DropColumn(
                name: "DepreciationRate",
                table: "fA_Masters");

            migrationBuilder.DropColumn(
                name: "DisposalDate",
                table: "fA_Masters");

            migrationBuilder.DropColumn(
                name: "ErectionContractor",
                table: "fA_Masters");

            migrationBuilder.DropColumn(
                name: "Folio",
                table: "fA_Masters");

            migrationBuilder.DropColumn(
                name: "ForeignExchangeCost",
                table: "fA_Masters");

            migrationBuilder.DropColumn(
                name: "IdentificationCode",
                table: "fA_Masters");

            migrationBuilder.DropColumn(
                name: "InstallationDate",
                table: "fA_Masters");

            migrationBuilder.DropColumn(
                name: "ItemNo",
                table: "fA_Masters");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "fA_Masters");

            migrationBuilder.DropColumn(
                name: "Maker",
                table: "fA_Masters");

            migrationBuilder.DropColumn(
                name: "Mark",
                table: "fA_Masters");

            migrationBuilder.DropColumn(
                name: "PONoAndDate",
                table: "fA_Masters");

            migrationBuilder.DropColumn(
                name: "SubCodeNo",
                table: "fA_Masters");

            migrationBuilder.DropColumn(
                name: "SupplierName",
                table: "fA_Masters");
        }
    }
}
