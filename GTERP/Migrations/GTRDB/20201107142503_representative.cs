using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class representative : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RepresentativeId",
                table: "DeliveryOrder",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Representative",
                columns: table => new
                {
                    RepresentativeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RepresentativeName = table.Column<string>(maxLength: 100, nullable: false),
                    comid = table.Column<string>(maxLength: 128, nullable: true),
                    userid = table.Column<string>(maxLength: 128, nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: true),
                    useridUpdate = table.Column<string>(maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Representative", x => x.RepresentativeId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryOrder_RepresentativeId",
                table: "DeliveryOrder",
                column: "RepresentativeId");

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryOrder_Representative_RepresentativeId",
                table: "DeliveryOrder",
                column: "RepresentativeId",
                principalTable: "Representative",
                principalColumn: "RepresentativeId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryOrder_Representative_RepresentativeId",
                table: "DeliveryOrder");

            migrationBuilder.DropTable(
                name: "Representative");

            migrationBuilder.DropIndex(
                name: "IX_DeliveryOrder_RepresentativeId",
                table: "DeliveryOrder");

            migrationBuilder.DropColumn(
                name: "RepresentativeId",
                table: "DeliveryOrder");
        }
    }
}
