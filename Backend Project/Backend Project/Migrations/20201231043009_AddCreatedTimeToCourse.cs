using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend_Project.Migrations
{
    public partial class AddCreatedTimeToCourse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedTime",
                table: "Courses",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedTime",
                table: "Courses");
        }
    }
}
