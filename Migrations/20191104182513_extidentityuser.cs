using Microsoft.EntityFrameworkCore.Migrations;

namespace Asp.MVCCoreWeb.Migrations
{
    public partial class extidentityuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PubG_UserName",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PubG_UserName",
                table: "AspNetUsers");
        }
    }
}
