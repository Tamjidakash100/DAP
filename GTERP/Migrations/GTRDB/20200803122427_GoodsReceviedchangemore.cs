using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class GoodsReceviedchangemore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GoodsReceiveMain_Cat_SubSection_SubSectId",
                table: "GoodsReceiveMain");

            migrationBuilder.DropIndex(
                name: "IX_GoodsReceiveMain_SubSectId",
                table: "GoodsReceiveMain");

            migrationBuilder.DropColumn(
                name: "SubSectId",
                table: "GoodsReceiveMain");

            migrationBuilder.DropColumn(
                name: "TermsAndCondition",
                table: "GoodsReceiveMain");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SubSectId",
                table: "GoodsReceiveMain",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TermsAndCondition",
                table: "GoodsReceiveMain",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_GoodsReceiveMain_SubSectId",
                table: "GoodsReceiveMain",
                column: "SubSectId");

            migrationBuilder.AddForeignKey(
                name: "FK_GoodsReceiveMain_Cat_SubSection_SubSectId",
                table: "GoodsReceiveMain",
                column: "SubSectId",
                principalTable: "Cat_SubSection",
                principalColumn: "SubSectId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
