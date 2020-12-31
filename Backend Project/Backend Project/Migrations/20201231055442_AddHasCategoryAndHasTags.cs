using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend_Project.Migrations
{
    public partial class AddHasCategoryAndHasTags : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "hasTags",
                table: "Tags",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "hasCategory",
                table: "Categories",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "hasTags",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "hasCategory",
                table: "Categories");
        }
    }
}
