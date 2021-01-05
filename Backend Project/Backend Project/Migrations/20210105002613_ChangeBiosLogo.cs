using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend_Project.Migrations
{
    public partial class ChangeBiosLogo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FooterLogo",
                table: "Bios");

            migrationBuilder.AddColumn<string>(
                name: "HeaderLogo",
                table: "Bios",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HeaderLogo",
                table: "Bios");

            migrationBuilder.AddColumn<string>(
                name: "FooterLogo",
                table: "Bios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
