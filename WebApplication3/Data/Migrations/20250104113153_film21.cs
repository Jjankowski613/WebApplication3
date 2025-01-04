using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication3.Data.Migrations
{
    /// <inheritdoc />
    public partial class film21 : Migration
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
