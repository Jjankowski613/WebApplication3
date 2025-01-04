using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication3.Data.Migrations
{
    /// <inheritdoc />
    public partial class UserNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Session_AspNetUsers_UserID",
                table: "Session");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Session",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Session_UserID",
                table: "Session",
                newName: "IX_Session_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Session_AspNetUsers_UserId",
                table: "Session",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Session_AspNetUsers_UserId",
                table: "Session");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Session",
                newName: "UserID");

            migrationBuilder.RenameIndex(
                name: "IX_Session_UserId",
                table: "Session",
                newName: "IX_Session_UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Session_AspNetUsers_UserID",
                table: "Session",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
