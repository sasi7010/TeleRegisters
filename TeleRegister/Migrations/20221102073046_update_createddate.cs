using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeleRegister.Migrations
{
    public partial class update_createddate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedDate",
                table: "Register",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreatedDate",
                table: "Patient",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreatedDate",
                table: "Doctor",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Register");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Patient");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Doctor");
        }
    }
}
