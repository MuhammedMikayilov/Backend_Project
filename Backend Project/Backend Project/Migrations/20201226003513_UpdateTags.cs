using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend_Project.Migrations
{
    public partial class UpdateTags : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TagCourse_Courses_CourseId",
                table: "TagCourse");

            migrationBuilder.DropForeignKey(
                name: "FK_TagCourse_Tags_TagsId",
                table: "TagCourse");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TagCourse",
                table: "TagCourse");

            migrationBuilder.RenameTable(
                name: "TagCourse",
                newName: "TagCourses");

            migrationBuilder.RenameIndex(
                name: "IX_TagCourse_TagsId",
                table: "TagCourses",
                newName: "IX_TagCourses_TagsId");

            migrationBuilder.RenameIndex(
                name: "IX_TagCourse_CourseId",
                table: "TagCourses",
                newName: "IX_TagCourses_CourseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TagCourses",
                table: "TagCourses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TagCourses_Courses_CourseId",
                table: "TagCourses",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TagCourses_Tags_TagsId",
                table: "TagCourses",
                column: "TagsId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TagCourses_Courses_CourseId",
                table: "TagCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_TagCourses_Tags_TagsId",
                table: "TagCourses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TagCourses",
                table: "TagCourses");

            migrationBuilder.RenameTable(
                name: "TagCourses",
                newName: "TagCourse");

            migrationBuilder.RenameIndex(
                name: "IX_TagCourses_TagsId",
                table: "TagCourse",
                newName: "IX_TagCourse_TagsId");

            migrationBuilder.RenameIndex(
                name: "IX_TagCourses_CourseId",
                table: "TagCourse",
                newName: "IX_TagCourse_CourseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TagCourse",
                table: "TagCourse",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TagCourse_Courses_CourseId",
                table: "TagCourse",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TagCourse_Tags_TagsId",
                table: "TagCourse",
                column: "TagsId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
