using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class fa44444444449999 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FA_DetailsId",
                table: "Depreciations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FA_MasterId",
                table: "Depreciations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Depreciations_FA_DetailsId",
                table: "Depreciations",
                column: "FA_DetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_Depreciations_FA_MasterId",
                table: "Depreciations",
                column: "FA_MasterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Depreciations_FA_Details_FA_DetailsId",
                table: "Depreciations",
                column: "FA_DetailsId",
                principalTable: "FA_Details",
                principalColumn: "FA_DetailsId",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Depreciations_fA_Masters_FA_MasterId",
                table: "Depreciations",
                column: "FA_MasterId",
                principalTable: "fA_Masters",
                principalColumn: "FA_MasterId",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Depreciations_FA_Details_FA_DetailsId",
                table: "Depreciations");

            migrationBuilder.DropForeignKey(
                name: "FK_Depreciations_fA_Masters_FA_MasterId",
                table: "Depreciations");

            migrationBuilder.DropIndex(
                name: "IX_Depreciations_FA_DetailsId",
                table: "Depreciations");

            migrationBuilder.DropIndex(
                name: "IX_Depreciations_FA_MasterId",
                table: "Depreciations");

            migrationBuilder.DropColumn(
                name: "FA_DetailsId",
                table: "Depreciations");

            migrationBuilder.DropColumn(
                name: "FA_MasterId",
                table: "Depreciations");
        }
    }
}
