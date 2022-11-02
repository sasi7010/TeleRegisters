using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeleRegister.Migrations
{
    public partial class dbcontext_updategender : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Patient",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Doctor",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Patient");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Doctor");
        }
    }
}
