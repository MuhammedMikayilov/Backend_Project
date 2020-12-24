using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend_Project.Migrations
{
    public partial class CreateRelationForBlogToBlogDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DetailId",
                table: "Blogs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BlogsId",
                table: "BlogDetails",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_BlogDetails_BlogsId",
                table: "BlogDetails",
                column: "BlogsId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BlogDetails_Blogs_BlogsId",
                table: "BlogDetails",
                column: "BlogsId",
                principalTable: "Blogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogDetails_Blogs_BlogsId",
                table: "BlogDetails");

            migrationBuilder.DropIndex(
                name: "IX_BlogDetails_BlogsId",
                table: "BlogDetails");

            migrationBuilder.DropColumn(
                name: "DetailId",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "BlogsId",
                table: "BlogDetails");
        }
    }
}
