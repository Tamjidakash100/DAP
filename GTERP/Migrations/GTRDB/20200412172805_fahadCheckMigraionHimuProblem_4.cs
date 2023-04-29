using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace GTERP.Migrations.GTRDB
{
    public partial class fahadCheckMigraionHimuProblem_4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.AddColumn<int>(
                        name: "SalesTypeId",
                        table: "PurchaseSubs",
                        nullable: true);


            migrationBuilder.CreateTable(
                name: "PrdUnits",
                columns: table => new
                {
                    PrdUnitId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrdUnitCode = table.Column<string>(maxLength: 10, nullable: true),
                    PrdUnitName = table.Column<string>(nullable: true),
                    PrdUnitShortName = table.Column<string>(maxLength: 10, nullable: true),
                    PrdUnitBanglaName = table.Column<string>(nullable: true),
                    SLNo = table.Column<int>(nullable: false),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    Updatedby = table.Column<string>(nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: true),
                    userid = table.Column<string>(maxLength: 128, nullable: true),
                    useridUpdate = table.Column<string>(maxLength: 128, nullable: true),
                    comid = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrdUnits", x => x.PrdUnitId);
                });

            migrationBuilder.CreateTable(
                name: "VoucherNoCreatedType",
                columns: table => new
                {
                    VoucherNoCreatedTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VoucherNoCreatedTypeCode = table.Column<string>(nullable: false),
                    VoucherNoCreatedTypeName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VoucherNoCreatedType", x => x.VoucherNoCreatedTypeId);
                });

            migrationBuilder.CreateTable(
                name: "VoucherNoPrefixs",
                columns: table => new
                {
                    VoucherNoPrefixId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VoucherTypeId = table.Column<int>(nullable: false),
                    VoucherShortPrefix = table.Column<string>(nullable: true),
                    comid = table.Column<string>(nullable: true),
                    Length = table.Column<int>(nullable: false),
                    isVisible = table.Column<bool>(nullable: false),
                    userid = table.Column<string>(maxLength: 128, nullable: true),
                    useridUpdate = table.Column<string>(maxLength: 128, nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VoucherNoPrefixs", x => x.VoucherNoPrefixId);
                    table.ForeignKey(
                        name: "FK_VoucherNoPrefixs_VoucherTypes_VoucherTypeId",
                        column: x => x.VoucherTypeId,
                        principalTable: "VoucherTypes",
                        principalColumn: "VoucherTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Warehouses_ParentId",
                table: "Warehouses",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_VoucherMains_PrdUnitId",
                table: "VoucherMains",
                column: "PrdUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Companys_VoucherNoCreatedTypeId",
                table: "Companys",
                column: "VoucherNoCreatedTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_VoucherNoPrefixs_VoucherTypeId",
                table: "VoucherNoPrefixs",
                column: "VoucherTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Companys_VoucherNoCreatedType_VoucherNoCreatedTypeId",
                table: "Companys",
                column: "VoucherNoCreatedTypeId",
                principalTable: "VoucherNoCreatedType",
                principalColumn: "VoucherNoCreatedTypeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_VoucherMains_PrdUnits_PrdUnitId",
                table: "VoucherMains",
                column: "PrdUnitId",
                principalTable: "PrdUnits",
                principalColumn: "PrdUnitId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Warehouses_Warehouses_ParentId",
                table: "Warehouses",
                column: "ParentId",
                principalTable: "Warehouses",
                principalColumn: "WarehouseId",
                onDelete: ReferentialAction.Restrict);


            //migrationBuilder.AlterColumn<string>(
            //    name: "UpdateByUserId",
            //    table: "Payroll_SalaryAddition",
            //    maxLength: 80,
            //    nullable: true,
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(max)",
            //    oldNullable: true);

            //migrationBuilder.AlterColumn<DateTime>(
            //    name: "DtJoin",
            //    table: "Payroll_SalaryAddition",
            //    nullable: false,
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(max)",
            //    oldNullable: true);

            //migrationBuilder.AlterColumn<DateTime>(
            //    name: "DtInput",
            //    table: "Payroll_SalaryAddition",
            //    nullable: false,
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(max)",
            //    oldNullable: true);

            //migrationBuilder.AddColumn<string>(
            //    name: "OtherAddType",
            //    table: "Payroll_SalaryAddition",
            //    maxLength: 100,
            //    nullable: true);



            //migrationBuilder.AlterColumn<string>(
            //    name: "LvType",
            //    table: "HR_Leave_Avail",
            //    maxLength: 25,
            //    nullable: true,
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(25)",
            //    oldMaxLength: 25);

            //migrationBuilder.AlterColumn<float>(
            //    name: "LvApp",
            //    table: "HR_Leave_Avail",
            //    nullable: true,
            //    oldClrType: typeof(float),
            //    oldType: "real");

            //migrationBuilder.AlterColumn<DateTime>(
            //    name: "DtInput",
            //    table: "HR_Leave_Avail",
            //    nullable: true,
            //    oldClrType: typeof(DateTime),
            //    oldType: "datetime2");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
