using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend_Project.Migrations
{
    public partial class AddedIsDeleteToBlog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedTime",
                table: "Blogs",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isDelete",
                table: "Blogs",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeletedTime",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "isDelete",
                table: "Blogs");
        }
    }
}
