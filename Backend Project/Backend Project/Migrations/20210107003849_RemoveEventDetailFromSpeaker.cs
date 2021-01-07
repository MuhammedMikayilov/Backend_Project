using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend_Project.Migrations
{
    public partial class RemoveEventDetailFromSpeaker : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EventDetailsId",
                table: "Speakers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EventDetailsId",
                table: "Speakers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
