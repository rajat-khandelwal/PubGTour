using Microsoft.EntityFrameworkCore.Migrations;

namespace Asp.MVCCoreWeb.Migrations
{
    public partial class newcoluserid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_PhoneNumber",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Employees",
                newName: "userid");

            migrationBuilder.AddColumn<string>(
                name: "Roomkey",
                table: "tournment",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Roompassword",
                table: "tournment",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Employees",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "AspNetUsers",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Roomkey",
                table: "tournment");

            migrationBuilder.DropColumn(
                name: "Roompassword",
                table: "tournment");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "userid",
                table: "Employees",
                newName: "UserName");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "AspNetUsers",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_PhoneNumber",
                table: "AspNetUsers",
                column: "PhoneNumber",
                unique: true,
                filter: "[PhoneNumber] IS NOT NULL");
        }
    }
}
