using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class ChartOfAccountInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Acc_ChartOfAccount_Initials",
                columns: table => new
                {
                    InitialAccId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    comid = table.Column<string>(nullable: true),
                    AccName = table.Column<string>(maxLength: 200, nullable: false),
                    AccCode = table.Column<string>(maxLength: 20, nullable: true),
                    AccType = table.Column<string>(maxLength: 1, nullable: true),
                    ParentID = table.Column<int>(nullable: true),
                    ParentCode = table.Column<string>(maxLength: 20, nullable: true),
                    userid = table.Column<string>(maxLength: 128, nullable: true),
                    useridUpdate = table.Column<string>(maxLength: 128, nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: true),
                    IsItemBS = table.Column<int>(nullable: false),
                    IsItemPL = table.Column<int>(nullable: false),
                    IsItemTA = table.Column<int>(nullable: false),
                    IsItemCS = table.Column<int>(nullable: false),
                    IsShowCOA = table.Column<int>(nullable: false),
                    IsChkRef = table.Column<int>(nullable: false),
                    IsEntryDep = table.Column<int>(nullable: false),
                    IsEntryBankLiability = table.Column<int>(nullable: false),
                    IsSysDefined = table.Column<int>(nullable: false),
                    CountryID = table.Column<int>(nullable: false),
                    CountryIdLocal = table.Column<int>(nullable: false),
                    Rate = table.Column<int>(nullable: false),
                    OpDebitLocal = table.Column<float>(nullable: false),
                    OpCreditLocal = table.Column<float>(nullable: false),
                    isInactive = table.Column<int>(nullable: false),
                    isItemConsumed = table.Column<int>(nullable: false),
                    isItemInventory = table.Column<int>(nullable: false),
                    isShowUg = table.Column<int>(nullable: false),
                    Level = table.Column<int>(nullable: true),
                    AccSubId = table.Column<int>(nullable: true),
                    IsCashItem = table.Column<int>(nullable: false),
                    IsBankItem = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acc_ChartOfAccount_Initials", x => x.InitialAccId);
                    table.ForeignKey(
                        name: "FK_Acc_ChartOfAccount_Initials_Acc_ChartOfAccount_Initials_ParentID",
                        column: x => x.ParentID,
                        principalTable: "Acc_ChartOfAccount_Initials",
                        principalColumn: "InitialAccId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Acc_ChartOfAccount_Initials_ParentID",
                table: "Acc_ChartOfAccount_Initials",
                column: "ParentID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Acc_ChartOfAccount_Initials");
        }
    }
}
