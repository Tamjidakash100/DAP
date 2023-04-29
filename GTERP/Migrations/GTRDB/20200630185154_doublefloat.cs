using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class doublefloat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropColumn(
            //    name: "PurchaseQty",
            //    table: "IssueSub");

            //migrationBuilder.AddColumn<int>(
            //    name: "IssueQty",
            //    table: "IssueSub",
            //    nullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "RemainingQty",
                table: "DeliveryOrder",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<float>(
                name: "Qty",
                table: "DeliveryOrder",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IssueQty",
                table: "IssueSub");

            migrationBuilder.AddColumn<int>(
                name: "PurchaseQty",
                table: "IssueSub",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "RemainingQty",
                table: "DeliveryOrder",
                type: "float",
                nullable: false,
                oldClrType: typeof(float));

            migrationBuilder.AlterColumn<double>(
                name: "Qty",
                table: "DeliveryOrder",
                type: "float",
                nullable: false,
                oldClrType: typeof(float));
        }
    }
}
