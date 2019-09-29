using Microsoft.EntityFrameworkCore.Migrations;

namespace OneMits.Data.Migrations
{
    public partial class LoginTableError : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoginTime_AspNetUsers_UserId",
                table: "LoginTime");

            migrationBuilder.DropIndex(
                name: "IX_LoginTime_UserId",
                table: "LoginTime");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "LoginTime",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "LoginTime",
                newName: "UserName");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "LoginTime",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "LoginTime",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "LoginTime",
                newName: "UserId");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "LoginTime",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LoginTime_UserId",
                table: "LoginTime",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_LoginTime_AspNetUsers_UserId",
                table: "LoginTime",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
