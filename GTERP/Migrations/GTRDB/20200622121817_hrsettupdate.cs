using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class hrsettupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BId",
                table: "Cat_HRSetting",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cat_HRSetting_BId",
                table: "Cat_HRSetting",
                column: "BId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cat_HRSetting_Cat_BuildingType_BId",
                table: "Cat_HRSetting",
                column: "BId",
                principalTable: "Cat_BuildingType",
                principalColumn: "BId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cat_HRSetting_Cat_BuildingType_BId",
                table: "Cat_HRSetting");

            migrationBuilder.DropIndex(
                name: "IX_Cat_HRSetting_BId",
                table: "Cat_HRSetting");

            migrationBuilder.DropColumn(
                name: "BId",
                table: "Cat_HRSetting");
        }
    }
}
