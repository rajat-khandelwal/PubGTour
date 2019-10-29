using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Asp.MVCCoreWeb.Migrations
{
    public partial class Tounaments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "Payments",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "tournment",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Date_Time = table.Column<DateTime>(nullable: false),
                    type = table.Column<string>(nullable: true),
                    Slots = table.Column<int>(nullable: false),
                    fee = table.Column<double>(nullable: false),
                    Prize = table.Column<double>(nullable: false),
                    Details = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tournment", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tournment");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Payments");
        }
    }
}
