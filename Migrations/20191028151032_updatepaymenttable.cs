using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Asp.MVCCoreWeb.Migrations
{
    public partial class updatepaymenttable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PAYMENTMODE",
                table: "Payments",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RESPCODE",
                table: "Payments",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Sataus",
                table: "Payments",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TXNID",
                table: "Payments",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTime>(
                name: "time",
                table: "Payments",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PAYMENTMODE",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "RESPCODE",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "Sataus",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "TXNID",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "time",
                table: "Payments");
        }
    }
}
