using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication3.Data.Migrations
{
    /// <inheritdoc />
    public partial class Filmy15 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AverageRating",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "NumberOfRatings",
                table: "Movie");

            migrationBuilder.CreateIndex(
                name: "IX_UserRatings_MovieId",
                table: "UserRatings",
                column: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRatings_Movie_MovieId",
                table: "UserRatings",
                column: "MovieId",
                principalTable: "Movie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRatings_Movie_MovieId",
                table: "UserRatings");

            migrationBuilder.DropIndex(
                name: "IX_UserRatings_MovieId",
                table: "UserRatings");

            migrationBuilder.AddColumn<double>(
                name: "AverageRating",
                table: "Movie",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfRatings",
                table: "Movie",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
