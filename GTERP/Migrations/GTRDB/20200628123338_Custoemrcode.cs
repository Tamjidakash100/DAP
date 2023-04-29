using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class Custoemrcode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "District",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "PoliceStation",
                table: "Customers");

            migrationBuilder.AlterColumn<string>(
                name: "PrimaryAddress",
                table: "Customers",
                maxLength: 300,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(300)",
                oldMaxLength: 300);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_comid_CustomerCode",
                table: "Customers",
                columns: new[] { "comid", "CustomerCode" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Customers_comid_CustomerCode",
                table: "Customers");

            migrationBuilder.AlterColumn<string>(
                name: "PrimaryAddress",
                table: "Customers",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 300,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "District",
                table: "Customers",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PoliceStation",
                table: "Customers",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true);
        }
    }
}
