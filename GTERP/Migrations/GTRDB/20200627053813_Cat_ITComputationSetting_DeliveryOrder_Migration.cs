using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class Cat_ITComputationSetting_DeliveryOrder_Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "PayInSlipNo",
                table: "DeliveryOrder",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DONo",
                table: "DeliveryOrder",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Cat_ITComputationSetting",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaxComputation = table.Column<float>(nullable: false),
                    Amount = table.Column<float>(nullable: false),
                    Rate = table.Column<float>(nullable: false),
                    dtFrom = table.Column<DateTime>(nullable: false),
                    dtTo = table.Column<DateTime>(nullable: false),
                    FiscalYear = table.Column<string>(nullable: true),
                    POId = table.Column<int>(nullable: false),
                    ComId = table.Column<string>(maxLength: 80, nullable: true),
                    UserId = table.Column<string>(maxLength: 80, nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    UpdateByUserId = table.Column<string>(maxLength: 80, nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cat_ITComputationSetting", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cat_ITComputationSetting_Cat_PostOffice_POId",
                        column: x => x.POId,
                        principalTable: "Cat_PostOffice",
                        principalColumn: "POId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cat_ITComputationSetting_POId",
                table: "Cat_ITComputationSetting",
                column: "POId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cat_ITComputationSetting");

            migrationBuilder.AlterColumn<string>(
                name: "PayInSlipNo",
                table: "DeliveryOrder",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "DONo",
                table: "DeliveryOrder",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
