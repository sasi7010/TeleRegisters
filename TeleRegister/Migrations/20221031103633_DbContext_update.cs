using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeleRegister.Migrations
{
    public partial class DbContext_update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DOB",
                table: "Patient",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DOB",
                table: "Doctor",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DOB",
                table: "Patient");

            migrationBuilder.DropColumn(
                name: "DOB",
                table: "Doctor");
        }
    }
}
