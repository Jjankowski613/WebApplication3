using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication3.Data.Migrations
{
    /// <inheritdoc />
    public partial class filmy30 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRatings_Movie_MovieId1",
                table: "UserRatings");

            migrationBuilder.DropIndex(
                name: "IX_UserRatings_MovieId1",
                table: "UserRatings");

            migrationBuilder.DropColumn(
                name: "MovieId1",
                table: "UserRatings");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MovieId1",
                table: "UserRatings",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserRatings_MovieId1",
                table: "UserRatings",
                column: "MovieId1");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRatings_Movie_MovieId1",
                table: "UserRatings",
                column: "MovieId1",
                principalTable: "Movie",
                principalColumn: "Id");
        }
    }
}
