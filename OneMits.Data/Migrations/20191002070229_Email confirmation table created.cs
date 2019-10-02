using Microsoft.EntityFrameworkCore.Migrations;

namespace OneMits.Data.Migrations
{
    public partial class Emailconfirmationtablecreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EnrollmentNumber",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "OtpTable",
                columns: table => new
                {
                    EnrollmentNumber = table.Column<string>(nullable: false),
                    DateOfBirth = table.Column<string>(nullable: true),
                    EmailAddress = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtpTable", x => x.EnrollmentNumber);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OtpTable");

            migrationBuilder.AddColumn<string>(
                name: "EnrollmentNumber",
                table: "AspNetUsers",
                nullable: true);
        }
    }
}
