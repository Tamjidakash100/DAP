﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class GovtSchedule : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Acc_GovtSchedules",
                columns: table => new
                {
                    GovtScheduleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccId = table.Column<int>(nullable: false),
                    Criteria = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    FromDate = table.Column<DateTime>(nullable: false),
                    ToDate = table.Column<DateTime>(nullable: false),
                    Remarks = table.Column<string>(nullable: true),
                    Loan = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Development = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CDVAT = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    isPost = table.Column<bool>(nullable: false),
                    comid = table.Column<string>(maxLength: 128, nullable: true),
                    userid = table.Column<string>(maxLength: 128, nullable: true),
                    useridCheck = table.Column<string>(maxLength: 128, nullable: true),
                    useridApprove = table.Column<string>(maxLength: 128, nullable: true),
                    useridUpdate = table.Column<string>(maxLength: 128, nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acc_GovtSchedules", x => x.GovtScheduleId);
                    table.ForeignKey(
                        name: "FK_Acc_GovtSchedules_Acc_ChartOfAccounts_AccId",
                        column: x => x.AccId,
                        principalTable: "Acc_ChartOfAccounts",
                        principalColumn: "AccId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Acc_GovtSchedules_AccId",
                table: "Acc_GovtSchedules",
                column: "AccId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Acc_GovtSchedules");
        }
    }
}
