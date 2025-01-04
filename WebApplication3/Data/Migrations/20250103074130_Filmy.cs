using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication3.Data.Migrations
{
    /// <inheritdoc />
    public partial class Filmy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercise_ExerciseType_ExerciseTypeId",
                table: "Exercise");

            migrationBuilder.DropTable(
                name: "ExerciseType");

            migrationBuilder.CreateTable(
                name: "Repertuar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Repertuar", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Exercise_Repertuar_ExerciseTypeId",
                table: "Exercise",
                column: "ExerciseTypeId",
                principalTable: "Repertuar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercise_Repertuar_ExerciseTypeId",
                table: "Exercise");

            migrationBuilder.DropTable(
                name: "Repertuar");

            migrationBuilder.CreateTable(
                name: "ExerciseType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseType", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Exercise_ExerciseType_ExerciseTypeId",
                table: "Exercise",
                column: "ExerciseTypeId",
                principalTable: "ExerciseType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
