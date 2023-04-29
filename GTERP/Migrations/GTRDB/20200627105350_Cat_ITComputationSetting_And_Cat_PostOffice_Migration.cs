using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class Cat_ITComputationSetting_And_Cat_PostOffice_Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cat_ITComputationSetting_Cat_PostOffice_POId",
                table: "Cat_ITComputationSetting");

            migrationBuilder.DropIndex(
                name: "IX_Cat_ITComputationSetting_POId",
                table: "Cat_ITComputationSetting");

            migrationBuilder.DropColumn(
                name: "POId",
                table: "Cat_ITComputationSetting");

            //migrationBuilder.AddColumn<int>(
            //    name: "ProductMainGroupId",
            //    table: "Products",
            //    nullable: true);

            //migrationBuilder.AddColumn<double>(
            //    name: "NewHRExp",
            //    table: "HR_Emp_Increment",
            //    nullable: true);

            //migrationBuilder.AddColumn<double>(
            //    name: "OldHRExp",
            //    table: "HR_Emp_Increment",
            //    nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PStationId",
                table: "Cat_PostOffice",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProssType",
                table: "Cat_IncomeTaxChk",
                maxLength: 12,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            //migrationBuilder.CreateTable(
            //    name: "ProductMainGroups",
            //    columns: table => new
            //    {
            //        ProductMainGroupId = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        ProductMainGroupCode = table.Column<string>(nullable: false),
            //        Name = table.Column<string>(nullable: false),
            //        ProductMainGroupDescription = table.Column<string>(maxLength: 300, nullable: false),
            //        SLNo = table.Column<int>(nullable: false),
            //        comid = table.Column<string>(maxLength: 128, nullable: true),
            //        userid = table.Column<string>(maxLength: 128, nullable: true),
            //        useridUpdate = table.Column<string>(maxLength: 128, nullable: true),
            //        DateAdded = table.Column<DateTime>(nullable: true),
            //        DateUpdated = table.Column<DateTime>(nullable: true),
            //        IsInActive = table.Column<bool>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_ProductMainGroups", x => x.ProductMainGroupId);
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_Products_ProductMainGroupId",
            //    table: "Products",
            //    column: "ProductMainGroupId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Cat_PostOffice_PStationId",
            //    table: "Cat_PostOffice",
            //    column: "PStationId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Cat_PostOffice_Cat_PoliceStation_PStationId",
            //    table: "Cat_PostOffice",
            //    column: "PStationId",
            //    principalTable: "Cat_PoliceStation",
            //    principalColumn: "PStationId",
            //    onDelete: ReferentialAction.Restrict);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Products_ProductMainGroups_ProductMainGroupId",
            //    table: "Products",
            //    column: "ProductMainGroupId",
            //    principalTable: "ProductMainGroups",
            //    principalColumn: "ProductMainGroupId",
            //    onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cat_PostOffice_Cat_PoliceStation_PStationId",
                table: "Cat_PostOffice");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductMainGroups_ProductMainGroupId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "ProductMainGroups");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProductMainGroupId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Cat_PostOffice_PStationId",
                table: "Cat_PostOffice");

            migrationBuilder.DropColumn(
                name: "ProductMainGroupId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "NewHRExp",
                table: "HR_Emp_Increment");

            migrationBuilder.DropColumn(
                name: "OldHRExp",
                table: "HR_Emp_Increment");

            migrationBuilder.DropColumn(
                name: "PStationId",
                table: "Cat_PostOffice");

            migrationBuilder.AddColumn<int>(
                name: "POId",
                table: "Cat_ITComputationSetting",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "ProssType",
                table: "Cat_IncomeTaxChk",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 12,
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cat_ITComputationSetting_POId",
                table: "Cat_ITComputationSetting",
                column: "POId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cat_ITComputationSetting_Cat_PostOffice_POId",
                table: "Cat_ITComputationSetting",
                column: "POId",
                principalTable: "Cat_PostOffice",
                principalColumn: "POId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
