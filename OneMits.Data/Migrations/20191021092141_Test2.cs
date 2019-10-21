using Microsoft.EntityFrameworkCore.Migrations;

namespace OneMits.Data.Migrations
{
    public partial class Test2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumberForums",
                table: "Categories",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NumberLike",
                table: "Categories",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NumberMember",
                table: "Categories",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NumberQuestions",
                table: "Categories",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NumberReplies",
                table: "Categories",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NumberUser",
                table: "Categories",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberForums",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "NumberLike",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "NumberMember",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "NumberQuestions",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "NumberReplies",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "NumberUser",
                table: "Categories");
        }
    }
}
