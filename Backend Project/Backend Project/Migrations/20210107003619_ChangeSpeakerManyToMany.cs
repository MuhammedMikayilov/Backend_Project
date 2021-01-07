using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend_Project.Migrations
{
    public partial class ChangeSpeakerManyToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(nullable: true),
                    SpeakerName = table.Column<string>(nullable: true),
                    Position = table.Column<string>(nullable: true),
                    EventDetailsId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Speakers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EventSpeakers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventId = table.Column<int>(nullable: false),
                    SpeakersId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventSpeakers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventSpeakers_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventSpeakers_Speakers_SpeakersId",
                        column: x => x.SpeakersId,
                        principalTable: "Speakers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventSpeakers_EventId",
                table: "EventSpeakers",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_EventSpeakers_SpeakersId",
                table: "EventSpeakers",
                column: "SpeakersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventSpeakers");

            migrationBuilder.DropTable(
                name: "Speakers");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "EventDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Position",
                table: "EventDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SpeakerName",
                table: "EventDetails",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
