using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorMovies.Server.Migrations
{
    public partial class NewDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GenresRecords",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenresRecords", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MoviesRecords",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: false),
                    ReleaseDate = table.Column<DateTime>(nullable: false),
                    Poster = table.Column<string>(nullable: true),
                    Summary = table.Column<string>(nullable: true),
                    InTheaters = table.Column<bool>(nullable: false),
                    Trailer = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoviesRecords", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersonRecords",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Biography = table.Column<string>(nullable: true),
                    Picture = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonRecords", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MoviesGenresRecords",
                columns: table => new
                {
                    MovieId = table.Column<int>(nullable: false),
                    GenreId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoviesGenresRecords", x => new { x.MovieId, x.GenreId });
                    table.ForeignKey(
                        name: "FK_MoviesGenresRecords_GenresRecords_GenreId",
                        column: x => x.GenreId,
                        principalTable: "GenresRecords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MoviesGenresRecords_MoviesRecords_MovieId",
                        column: x => x.MovieId,
                        principalTable: "MoviesRecords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MoviesActorsRecords",
                columns: table => new
                {
                    PersonId = table.Column<int>(nullable: false),
                    MovieId = table.Column<int>(nullable: false),
                    CharacterName = table.Column<string>(nullable: true),
                    Order = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoviesActorsRecords", x => new { x.MovieId, x.PersonId });
                    table.ForeignKey(
                        name: "FK_MoviesActorsRecords_MoviesRecords_MovieId",
                        column: x => x.MovieId,
                        principalTable: "MoviesRecords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MoviesActorsRecords_PersonRecords_PersonId",
                        column: x => x.PersonId,
                        principalTable: "PersonRecords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MoviesActorsRecords_PersonId",
                table: "MoviesActorsRecords",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_MoviesGenresRecords_GenreId",
                table: "MoviesGenresRecords",
                column: "GenreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MoviesActorsRecords");

            migrationBuilder.DropTable(
                name: "MoviesGenresRecords");

            migrationBuilder.DropTable(
                name: "PersonRecords");

            migrationBuilder.DropTable(
                name: "GenresRecords");

            migrationBuilder.DropTable(
                name: "MoviesRecords");
        }
    }
}
