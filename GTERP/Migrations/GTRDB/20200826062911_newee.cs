using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class newee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "WhType",
                table: "Warehouses",
                maxLength: 1,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "DepreciationSchedules",
                columns: table => new
                {
                    DepreciationScheduleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FA_DetailsId = table.Column<int>(nullable: false),
                    ScheduleDate = table.Column<DateTime>(nullable: false),
                    DepAmount = table.Column<decimal>(nullable: false),
                    AccumulateDepAmount = table.Column<decimal>(nullable: false),
                    AccumulateDepBooked = table.Column<int>(nullable: false),
                    AccumulateDepRemain = table.Column<int>(nullable: false),
                    JournalEntry = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepreciationSchedules", x => x.DepreciationScheduleId);
                    table.ForeignKey(
                        name: "FK_DepreciationSchedules_FA_Details_FA_DetailsId",
                        column: x => x.FA_DetailsId,
                        principalTable: "FA_Details",
                        principalColumn: "FA_DetailsId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DepreciationSchedules_FA_DetailsId",
                table: "DepreciationSchedules",
                column: "FA_DetailsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DepreciationSchedules");

            migrationBuilder.AlterColumn<string>(
                name: "WhType",
                table: "Warehouses",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 1,
                oldNullable: true);
        }
    }
}
