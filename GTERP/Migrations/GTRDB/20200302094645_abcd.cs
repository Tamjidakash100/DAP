using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class abcd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserLogingInfos");

            migrationBuilder.CreateTable(
                name: "UserLogingInfos",
                columns: table => new
                {
                    UserLogingInfoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userid = table.Column<string>(maxLength: 128, nullable: false),
                    WebLink = table.Column<string>(nullable: true),
                    LoginDate = table.Column<DateTime>(nullable: true),
                    LoginTime = table.Column<DateTime>(nullable: true),
                    PcName = table.Column<string>(nullable: true),
                    MacAddress = table.Column<string>(nullable: true),
                    IPAddress = table.Column<string>(nullable: true),
                    DeviceType = table.Column<string>(nullable: true),
                    Platform = table.Column<string>(nullable: true),
                    WebBrowserName = table.Column<string>(nullable: true),
                    comid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogingInfos", x => x.UserLogingInfoId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserLogingInfos");

            migrationBuilder.CreateTable(
                name: "UserLogingInfos",
                columns: table => new
                {
                    UserLogingInfoId = table.Column<int>(name: "UserLogingInfoId", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeviceType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IPAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoginDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LoginTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MacAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PcName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Platform = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WebBrowserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WebLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    comid = table.Column<int>(type: "int", nullable: false),
                    userid = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogingInfos", x => x.UserLogingInfoId);
                });
        }
    }
}
