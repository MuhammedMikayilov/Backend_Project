using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend_Project.Migrations
{
    public partial class CreateFooter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Footer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Logo = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Facebook = table.Column<string>(nullable: true),
                    Pinterest = table.Column<string>(nullable: true),
                    Vimeo = table.Column<string>(nullable: true),
                    Twitter = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: false),
                    Phono1 = table.Column<string>(nullable: true),
                    Phone2 = table.Column<string>(nullable: true),
                    EmailUs = table.Column<string>(nullable: true),
                    OurSite = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Footer", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Footer");
        }
    }
}
