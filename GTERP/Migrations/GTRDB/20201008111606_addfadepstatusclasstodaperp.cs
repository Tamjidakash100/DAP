using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class addfadepstatusclasstodaperp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FA_Dep_StatusId",
                table: "FA_Details",
                nullable: false,
                defaultValue: 0);

            

           
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
        }
    }
}
