using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend_Project.Migrations
{
    public partial class ChangeCount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LeaveReply",
                table: "EventDetails");

            migrationBuilder.DropColumn(
                name: "Reply",
                table: "CourseDetails");

            migrationBuilder.DropColumn(
                name: "Count",
                table: "Categories");

            migrationBuilder.AddColumn<int>(
                name: "Count",
                table: "EventDetails",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Count",
                table: "CourseDetails",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Count",
                table: "BlogDetails",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Count",
                table: "EventDetails");

            migrationBuilder.DropColumn(
                name: "Count",
                table: "CourseDetails");

            migrationBuilder.DropColumn(
                name: "Count",
                table: "BlogDetails");

            migrationBuilder.AddColumn<string>(
                name: "LeaveReply",
                table: "EventDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Reply",
                table: "CourseDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Count",
                table: "Categories",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
