using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    public partial class Movieinit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "actors",
                columns: table => new
                {
                    ActorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_actors", x => x.ActorId);
                });

            migrationBuilder.CreateTable(
                name: "countries",
                columns: table => new
                {
                    CountryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_countries", x => x.CountryId);
                });

            migrationBuilder.CreateTable(
                name: "directors",
                columns: table => new
                {
                    DirectorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_directors", x => x.DirectorId);
                });

            migrationBuilder.CreateTable(
                name: "genres",
                columns: table => new
                {
                    GenreId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_genres", x => x.GenreId);
                });

            migrationBuilder.CreateTable(
                name: "languages",
                columns: table => new
                {
                    LanguageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_languages", x => x.LanguageId);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "movies",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DirectorId = table.Column<int>(type: "int", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: true),
                    LanguageId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_movies", x => x.MovieId);
                    table.ForeignKey(
                        name: "FK_movies_countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "countries",
                        principalColumn: "CountryId");
                    table.ForeignKey(
                        name: "FK_movies_directors_DirectorId",
                        column: x => x.DirectorId,
                        principalTable: "directors",
                        principalColumn: "DirectorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_movies_languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "languages",
                        principalColumn: "LanguageId");
                });

            migrationBuilder.CreateTable(
                name: "awards",
                columns: table => new
                {
                    AwardId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AwardName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MoviesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_awards", x => x.AwardId);
                    table.ForeignKey(
                        name: "FK_awards_movies_MoviesId",
                        column: x => x.MoviesId,
                        principalTable: "movies",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "bookings",
                columns: table => new
                {
                    BookingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    MoviesMovieId = table.Column<int>(type: "int", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bookings", x => x.BookingId);
                    table.ForeignKey(
                        name: "FK_bookings_movies_MoviesMovieId",
                        column: x => x.MoviesMovieId,
                        principalTable: "movies",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_bookings_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "movieActors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    MoviesMovieId = table.Column<int>(type: "int", nullable: false),
                    ActorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_movieActors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_movieActors_actors_ActorId",
                        column: x => x.ActorId,
                        principalTable: "actors",
                        principalColumn: "ActorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_movieActors_movies_MoviesMovieId",
                        column: x => x.MoviesMovieId,
                        principalTable: "movies",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "movieGenres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    MoviesMovieId = table.Column<int>(type: "int", nullable: false),
                    GenreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_movieGenres", x => x.Id);
                    table.ForeignKey(
                        name: "FK_movieGenres_genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "genres",
                        principalColumn: "GenreId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_movieGenres_movies_MoviesMovieId",
                        column: x => x.MoviesMovieId,
                        principalTable: "movies",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "reviews",
                columns: table => new
                {
                    ReviewId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    MoviesMovieId = table.Column<int>(type: "int", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reviews", x => x.ReviewId);
                    table.ForeignKey(
                        name: "FK_reviews_movies_MoviesMovieId",
                        column: x => x.MoviesMovieId,
                        principalTable: "movies",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_reviews_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "UserId");
                });

            migrationBuilder.InsertData(
                table: "actors",
                columns: new[] { "ActorId", "Name" },
                values: new object[,]
                {
                    { 1, "Actor1" },
                    { 2, "Actor2" }
                });

            migrationBuilder.InsertData(
                table: "directors",
                columns: new[] { "DirectorId", "Name" },
                values: new object[,]
                {
                    { 1, "Director 1" },
                    { 2, "Director2" }
                });

            migrationBuilder.InsertData(
                table: "genres",
                columns: new[] { "GenreId", "Name" },
                values: new object[,]
                {
                    { 1, "Action" },
                    { 2, "Comedy" }
                });

            migrationBuilder.InsertData(
                table: "languages",
                columns: new[] { "LanguageId", "Name" },
                values: new object[,]
                {
                    { 1, "English" },
                    { 2, "Spanish " }
                });

            migrationBuilder.InsertData(
                table: "movies",
                columns: new[] { "MovieId", "CountryId", "DirectorId", "LanguageId", "Title" },
                values: new object[] { 1, null, 1, null, "Movie 1" });

            migrationBuilder.InsertData(
                table: "movies",
                columns: new[] { "MovieId", "CountryId", "DirectorId", "LanguageId", "Title" },
                values: new object[] { 2, null, 1, null, "Movie 2" });

            migrationBuilder.InsertData(
                table: "awards",
                columns: new[] { "AwardId", "AwardName", "MoviesId" },
                values: new object[] { 1, "Best Actor", 1 });

            migrationBuilder.InsertData(
                table: "awards",
                columns: new[] { "AwardId", "AwardName", "MoviesId" },
                values: new object[] { 2, "Best Director", 2 });

            migrationBuilder.CreateIndex(
                name: "IX_awards_MoviesId",
                table: "awards",
                column: "MoviesId");

            migrationBuilder.CreateIndex(
                name: "IX_bookings_MoviesMovieId",
                table: "bookings",
                column: "MoviesMovieId");

            migrationBuilder.CreateIndex(
                name: "IX_bookings_UserId",
                table: "bookings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_movieActors_ActorId",
                table: "movieActors",
                column: "ActorId");

            migrationBuilder.CreateIndex(
                name: "IX_movieActors_MoviesMovieId",
                table: "movieActors",
                column: "MoviesMovieId");

            migrationBuilder.CreateIndex(
                name: "IX_movieGenres_GenreId",
                table: "movieGenres",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_movieGenres_MoviesMovieId",
                table: "movieGenres",
                column: "MoviesMovieId");

            migrationBuilder.CreateIndex(
                name: "IX_movies_CountryId",
                table: "movies",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_movies_DirectorId",
                table: "movies",
                column: "DirectorId");

            migrationBuilder.CreateIndex(
                name: "IX_movies_LanguageId",
                table: "movies",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_reviews_MoviesMovieId",
                table: "reviews",
                column: "MoviesMovieId");

            migrationBuilder.CreateIndex(
                name: "IX_reviews_UserId",
                table: "reviews",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "awards");

            migrationBuilder.DropTable(
                name: "bookings");

            migrationBuilder.DropTable(
                name: "movieActors");

            migrationBuilder.DropTable(
                name: "movieGenres");

            migrationBuilder.DropTable(
                name: "reviews");

            migrationBuilder.DropTable(
                name: "actors");

            migrationBuilder.DropTable(
                name: "genres");

            migrationBuilder.DropTable(
                name: "movies");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "countries");

            migrationBuilder.DropTable(
                name: "directors");

            migrationBuilder.DropTable(
                name: "languages");
        }
    }
}
