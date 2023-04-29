using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class Salary : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SalaryProcess",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dtPayment = table.Column<string>(nullable: true),
                    dtFirst = table.Column<string>(nullable: true),
                    dtLast = table.Column<string>(nullable: true),
                    dtFest = table.Column<string>(nullable: true),
                    dtFestEffect = table.Column<string>(nullable: true),
                    Days = table.Column<string>(nullable: true),
                    dtSalAdv = table.Column<string>(nullable: true),
                    dtELPrcFirst = table.Column<string>(nullable: true),
                    dtELPrcLast = table.Column<string>(nullable: true),
                    SalType = table.Column<string>(nullable: true),
                    FestType = table.Column<string>(nullable: true),
                    Religion = table.Column<string>(nullable: true),
                    AdvType = table.Column<string>(nullable: true),
                    AdvFestType = table.Column<string>(nullable: true),
                    salDesc = table.Column<string>(nullable: true),
                    bonusPer = table.Column<string>(nullable: true),
                    bonusAdvPer = table.Column<string>(nullable: true),
                    EmpType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalaryProcess", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SalaryProcess");
        }
    }
}
