using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class issuemainDept : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Department",
                table: "IssueMain");

            migrationBuilder.AddColumn<int>(
                name: "DeptId",
                table: "IssueMain",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_IssueMain_DeptId",
                table: "IssueMain",
                column: "DeptId");

            migrationBuilder.AddForeignKey(
                name: "FK_IssueMain_Cat_Department_DeptId",
                table: "IssueMain",
                column: "DeptId",
                principalTable: "Cat_Department",
                principalColumn: "DeptId",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IssueMain_Cat_Department_DeptId",
                table: "IssueMain");

            migrationBuilder.DropIndex(
                name: "IX_IssueMain_DeptId",
                table: "IssueMain");

            migrationBuilder.DropColumn(
                name: "DeptId",
                table: "IssueMain");

            migrationBuilder.AddColumn<string>(
                name: "Department",
                table: "IssueMain",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
