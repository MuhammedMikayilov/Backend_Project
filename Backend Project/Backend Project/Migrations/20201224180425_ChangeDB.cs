using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend_Project.Migrations
{
    public partial class ChangeDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Boards_Notices_NoticeId",
                table: "Boards");

            migrationBuilder.DropTable(
                name: "CourseFeatures");

            migrationBuilder.DropIndex(
                name: "IX_Boards_NoticeId",
                table: "Boards");

            migrationBuilder.DropColumn(
                name: "NoticeId",
                table: "Boards");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EventDate",
                table: "Events",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Assesments",
                table: "CourseDetails",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ClassDuration",
                table: "CourseDetails",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "CoursePrice",
                table: "CourseDetails",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Duration",
                table: "CourseDetails",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Language",
                table: "CourseDetails",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SkillLevel",
                table: "CourseDetails",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Starts",
                table: "CourseDetails",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StudentsCount",
                table: "CourseDetails",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Assesments",
                table: "CourseDetails");

            migrationBuilder.DropColumn(
                name: "ClassDuration",
                table: "CourseDetails");

            migrationBuilder.DropColumn(
                name: "CoursePrice",
                table: "CourseDetails");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "CourseDetails");

            migrationBuilder.DropColumn(
                name: "Language",
                table: "CourseDetails");

            migrationBuilder.DropColumn(
                name: "SkillLevel",
                table: "CourseDetails");

            migrationBuilder.DropColumn(
                name: "Starts",
                table: "CourseDetails");

            migrationBuilder.DropColumn(
                name: "StudentsCount",
                table: "CourseDetails");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EventDate",
                table: "Events",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AddColumn<int>(
                name: "NoticeId",
                table: "Boards",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CourseFeatures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Assesments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClassDuration = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CourseDetailId = table.Column<int>(type: "int", nullable: false),
                    CoursePrice = table.Column<double>(type: "float", nullable: false),
                    Duration = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SkillLevel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Starts = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StudentsCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseFeatures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseFeatures_CourseDetails_CourseDetailId",
                        column: x => x.CourseDetailId,
                        principalTable: "CourseDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Boards_NoticeId",
                table: "Boards",
                column: "NoticeId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseFeatures_CourseDetailId",
                table: "CourseFeatures",
                column: "CourseDetailId");

            migrationBuilder.AddForeignKey(
                name: "FK_Boards_Notices_NoticeId",
                table: "Boards",
                column: "NoticeId",
                principalTable: "Notices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
