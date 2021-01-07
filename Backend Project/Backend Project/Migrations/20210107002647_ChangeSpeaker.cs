using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend_Project.Migrations
{
    public partial class ChangeSpeaker : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Speakers");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "EventDetails",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Position",
                table: "EventDetails",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SpeakerName",
                table: "EventDetails",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "EventDetails");

            migrationBuilder.DropColumn(
                name: "Position",
                table: "EventDetails");

            migrationBuilder.DropColumn(
                name: "SpeakerName",
                table: "EventDetails");

            migrationBuilder.CreateTable(
                name: "Speakers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventDetailsId = table.Column<int>(type: "int", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpeakerName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Speakers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Speakers_EventDetails_EventDetailsId",
                        column: x => x.EventDetailsId,
                        principalTable: "EventDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Speakers_EventDetailsId",
                table: "Speakers",
                column: "EventDetailsId");
        }
    }
}
