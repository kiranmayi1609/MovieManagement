﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebAPI.Repo;

#nullable disable

namespace WebAPI.Migrations
{
    [DbContext(typeof(MovieDbContext))]
    partial class MovieDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.24")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("WebAPI.Models.Actor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("actors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Actor1"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Actor2"
                        });
                });

            modelBuilder.Entity("WebAPI.Models.Award", b =>
                {
                    b.Property<int>("AwardId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AwardId"), 1L, 1);

                    b.Property<string>("AwardName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MoviesId")
                        .HasColumnType("int");

                    b.HasKey("AwardId");

                    b.HasIndex("MoviesId");

                    b.ToTable("awards");

                    b.HasData(
                        new
                        {
                            AwardId = 1,
                            AwardName = "Best Actor",
                            MoviesId = 1
                        },
                        new
                        {
                            AwardId = 2,
                            AwardName = "Best Director",
                            MoviesId = 2
                        });
                });

            modelBuilder.Entity("WebAPI.Models.Booking", b =>
                {
                    b.Property<int>("BookingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookingId"), 1L, 1);

                    b.Property<DateTime>("BookingDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("MoviesId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("BookingId");

                    b.HasIndex("MoviesId");

                    b.HasIndex("UserId");

                    b.ToTable("bookings");

                    b.HasData(
                        new
                        {
                            BookingId = 1,
                            BookingDate = new DateTime(2023, 12, 8, 10, 33, 31, 285, DateTimeKind.Local).AddTicks(1620),
                            MoviesId = 1,
                            UserId = 1
                        },
                        new
                        {
                            BookingId = 2,
                            BookingDate = new DateTime(2023, 12, 8, 10, 33, 31, 285, DateTimeKind.Local).AddTicks(1659),
                            MoviesId = 2,
                            UserId = 2
                        });
                });

            modelBuilder.Entity("WebAPI.Models.Country", b =>
                {
                    b.Property<int>("CountryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CountryId"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CountryId");

                    b.ToTable("countries");

                    b.HasData(
                        new
                        {
                            CountryId = 1,
                            Name = "USA"
                        },
                        new
                        {
                            CountryId = 2,
                            Name = "Canada"
                        });
                });

            modelBuilder.Entity("WebAPI.Models.Director", b =>
                {
                    b.Property<int>("DirectorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DirectorId"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DirectorId");

                    b.ToTable("directors");

                    b.HasData(
                        new
                        {
                            DirectorId = 1,
                            Name = "Director 1"
                        },
                        new
                        {
                            DirectorId = 2,
                            Name = "Director2"
                        });
                });

            modelBuilder.Entity("WebAPI.Models.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("genres");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Action"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Comedy"
                        });
                });

            modelBuilder.Entity("WebAPI.Models.Language", b =>
                {
                    b.Property<int>("LanguageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LanguageId"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LanguageId");

                    b.ToTable("languages");

                    b.HasData(
                        new
                        {
                            LanguageId = 1,
                            Name = "English"
                        },
                        new
                        {
                            LanguageId = 2,
                            Name = "Spanish "
                        });
                });

            modelBuilder.Entity("WebAPI.Models.MovieActor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ActorId")
                        .HasColumnType("int");

                    b.Property<int>("MoviesId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ActorId");

                    b.HasIndex("MoviesId");

                    b.ToTable("movieActors");
                });

            modelBuilder.Entity("WebAPI.Models.MovieGenre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("GenreId")
                        .HasColumnType("int");

                    b.Property<int>("MoviesId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GenreId");

                    b.HasIndex("MoviesId");

                    b.ToTable("movieGenres");
                });

            modelBuilder.Entity("WebAPI.Models.Movies", b =>
                {
                    b.Property<int>("MovieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MovieId"), 1L, 1);

                    b.Property<int?>("CountryId")
                        .HasColumnType("int");

                    b.Property<int>("DirectorId")
                        .HasColumnType("int");

                    b.Property<int?>("LanguageId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MovieId");

                    b.HasIndex("CountryId");

                    b.HasIndex("DirectorId");

                    b.HasIndex("LanguageId");

                    b.ToTable("movies");

                    b.HasData(
                        new
                        {
                            MovieId = 1,
                            DirectorId = 1,
                            Title = "Movie 1"
                        },
                        new
                        {
                            MovieId = 2,
                            DirectorId = 2,
                            Title = "Movie 2"
                        });
                });

            modelBuilder.Entity("WebAPI.Models.Review", b =>
                {
                    b.Property<int>("ReviewId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReviewId"), 1L, 1);

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MoviesId")
                        .HasColumnType("int");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ReviewId");

                    b.HasIndex("MoviesId");

                    b.HasIndex("UserId");

                    b.ToTable("reviews");

                    b.HasData(
                        new
                        {
                            ReviewId = 1,
                            Comment = "Great movie!",
                            MoviesId = 1,
                            Rating = 5
                        },
                        new
                        {
                            ReviewId = 2,
                            Comment = "Awesome director!",
                            MoviesId = 2,
                            Rating = 4
                        });
                });

            modelBuilder.Entity("WebAPI.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            FirstName = "John",
                            LastName = "Doe",
                            Password = "password",
                            Role = "Admin",
                            UserName = "john.doe"
                        },
                        new
                        {
                            UserId = 2,
                            FirstName = "Jane",
                            LastName = "Doe",
                            Password = "password",
                            Role = "User",
                            UserName = "jane.doe"
                        });
                });

            modelBuilder.Entity("WebAPI.Models.Award", b =>
                {
                    b.HasOne("WebAPI.Models.Movies", "Movies")
                        .WithMany("Awards")
                        .HasForeignKey("MoviesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movies");
                });

            modelBuilder.Entity("WebAPI.Models.Booking", b =>
                {
                    b.HasOne("WebAPI.Models.Movies", "Movies")
                        .WithMany()
                        .HasForeignKey("MoviesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebAPI.Models.User", "User")
                        .WithMany("Bookings")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movies");

                    b.Navigation("User");
                });

            modelBuilder.Entity("WebAPI.Models.MovieActor", b =>
                {
                    b.HasOne("WebAPI.Models.Actor", "Actor")
                        .WithMany("MovieActor")
                        .HasForeignKey("ActorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebAPI.Models.Movies", "Movies")
                        .WithMany()
                        .HasForeignKey("MoviesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Actor");

                    b.Navigation("Movies");
                });

            modelBuilder.Entity("WebAPI.Models.MovieGenre", b =>
                {
                    b.HasOne("WebAPI.Models.Genre", "Genre")
                        .WithMany("Movies")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebAPI.Models.Movies", "Movies")
                        .WithMany("MoviesGenre")
                        .HasForeignKey("MoviesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genre");

                    b.Navigation("Movies");
                });

            modelBuilder.Entity("WebAPI.Models.Movies", b =>
                {
                    b.HasOne("WebAPI.Models.Country", null)
                        .WithMany("MoviesProduced")
                        .HasForeignKey("CountryId");

                    b.HasOne("WebAPI.Models.Director", "Director")
                        .WithMany("MovieDirector")
                        .HasForeignKey("DirectorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebAPI.Models.Language", null)
                        .WithMany("Movies")
                        .HasForeignKey("LanguageId");

                    b.Navigation("Director");
                });

            modelBuilder.Entity("WebAPI.Models.Review", b =>
                {
                    b.HasOne("WebAPI.Models.Movies", "Movies")
                        .WithMany("Reviews")
                        .HasForeignKey("MoviesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebAPI.Models.User", null)
                        .WithMany("Reviews")
                        .HasForeignKey("UserId");

                    b.Navigation("Movies");
                });

            modelBuilder.Entity("WebAPI.Models.Actor", b =>
                {
                    b.Navigation("MovieActor");
                });

            modelBuilder.Entity("WebAPI.Models.Country", b =>
                {
                    b.Navigation("MoviesProduced");
                });

            modelBuilder.Entity("WebAPI.Models.Director", b =>
                {
                    b.Navigation("MovieDirector");
                });

            modelBuilder.Entity("WebAPI.Models.Genre", b =>
                {
                    b.Navigation("Movies");
                });

            modelBuilder.Entity("WebAPI.Models.Language", b =>
                {
                    b.Navigation("Movies");
                });

            modelBuilder.Entity("WebAPI.Models.Movies", b =>
                {
                    b.Navigation("Awards");

                    b.Navigation("MoviesGenre");

                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("WebAPI.Models.User", b =>
                {
                    b.Navigation("Bookings");

                    b.Navigation("Reviews");
                });
#pragma warning restore 612, 618
        }
    }
}
