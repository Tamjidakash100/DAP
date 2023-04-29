using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class BOMMainId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BOMMainId",
                table: "IssueMain",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_IssueMain_BOMMainId",
                table: "IssueMain",
                column: "BOMMainId");

            migrationBuilder.AddForeignKey(
                name: "FK_IssueMain_BOMMain_BOMMainId",
                table: "IssueMain",
                column: "BOMMainId",
                principalTable: "BOMMain",
                principalColumn: "BOMMainId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IssueMain_BOMMain_BOMMainId",
                table: "IssueMain");

            migrationBuilder.DropIndex(
                name: "IX_IssueMain_BOMMainId",
                table: "IssueMain");

            migrationBuilder.DropColumn(
                name: "BOMMainId",
                table: "IssueMain");
        }
    }
}
