using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class saleschedule : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DepreciationScheduleSales_FA_Details_FA_DetailsId",
                table: "DepreciationScheduleSales");

            migrationBuilder.DropIndex(
                name: "IX_DepreciationScheduleSales_FA_DetailsId",
                table: "DepreciationScheduleSales");

            migrationBuilder.DropColumn(
                name: "FA_DetailsId",
                table: "DepreciationScheduleSales");

            migrationBuilder.AddColumn<int>(
                name: "FA_Dep_StatusId",
                table: "fA_Sells",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsDepRunning",
                table: "fA_Sells",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsInActive",
                table: "fA_Sells",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_fA_Sells_FA_Dep_StatusId",
                table: "fA_Sells",
                column: "FA_Dep_StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_fA_Sells_fA_Dep_Statuses_FA_Dep_StatusId",
                table: "fA_Sells",
                column: "FA_Dep_StatusId",
                principalTable: "fA_Dep_Statuses",
                principalColumn: "FA_Dep_StatusId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_fA_Sells_fA_Dep_Statuses_FA_Dep_StatusId",
                table: "fA_Sells");

            migrationBuilder.DropIndex(
                name: "IX_fA_Sells_FA_Dep_StatusId",
                table: "fA_Sells");

            migrationBuilder.DropColumn(
                name: "FA_Dep_StatusId",
                table: "fA_Sells");

            migrationBuilder.DropColumn(
                name: "IsDepRunning",
                table: "fA_Sells");

            migrationBuilder.DropColumn(
                name: "IsInActive",
                table: "fA_Sells");

            migrationBuilder.AddColumn<int>(
                name: "FA_DetailsId",
                table: "DepreciationScheduleSales",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_DepreciationScheduleSales_FA_DetailsId",
                table: "DepreciationScheduleSales",
                column: "FA_DetailsId");

            migrationBuilder.AddForeignKey(
                name: "FK_DepreciationScheduleSales_FA_Details_FA_DetailsId",
                table: "DepreciationScheduleSales",
                column: "FA_DetailsId",
                principalTable: "FA_Details",
                principalColumn: "FA_DetailsId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
