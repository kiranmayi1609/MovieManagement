using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Repo
{
    public class MovieDbContext:DbContext
    {
        //Constructor used to pass DbcontextOptions to the base class (DbContext)
        //This provides connection information to the databse 

        public MovieDbContext(DbContextOptions<MovieDbContext>options):base(options)
        {

        }
        //Dbset properties repressent tables in the database 
        //These will be used to interact with corresponding entities 

        public DbSet<Actor>actors { get; set; }
        public DbSet<Award>awards { get; set; }
        public DbSet<Booking>bookings { get; set; }
        public DbSet<Country>countries { get; set; }
        public DbSet<Director> directors { get; set; }
        public DbSet<Genre>genres { get; set; }

        public DbSet<Language> languages { get; set; }
        public DbSet<MovieActor>movieActors { get; set; }
        public DbSet<MovieGenre> movieGenres { get; set; }
        public DbSet<Movies>movies { get; set; }    
        public DbSet <Review>reviews { get; set; }
        public DbSet<User>users { get; set; }   

        protected override  void OnModelCreating(ModelBuilder modelBuilder)
        {
            // seed the data for Actors 

                 modelBuilder.Entity<Actor>().HasData(
                       new Actor { Id = 1, Name = "Actor1" },
                       new Actor { Id = 2, Name = "Actor2" }

                   );


                  modelBuilder.Entity<Award>().HasData(
                         new Award { AwardId = 1, AwardName = "Best Actor", MoviesId = 1 },
                         new Award { AwardId = 2, AwardName = "Best Director", MoviesId = 2 }
                   );
            //Directors 
                 modelBuilder.Entity<Director>().HasData(
                        new Director { DirectorId = 1, Name = "Director 1" },
                        new Director { DirectorId = 2, Name = "Director2" });

                 modelBuilder.Entity<Movies>().HasData(
                        new Movies { MovieId = 1, Title = "Movie 1" ,DirectorId=1},
                        new Movies { MovieId = 2, Title = "Movie 2",  DirectorId=2 }
                        );
            
           
            //Genres
                  modelBuilder.Entity<Genre>().HasData(
                           new Genre { Id = 1, Name = "Action" },
                           new Genre { Id = 2, Name = "Comedy" });
            //Language 
                  modelBuilder.Entity<Language>().HasData(
                           new Language { LanguageId = 1, Name = "English" },
                           new Language { LanguageId = 2, Name = "Spanish " });


            // Seed the data for Users
            modelBuilder.Entity<User>().HasData(
                new User { UserId = 1, FirstName = "John", LastName = "Doe", UserName = "john.doe", Password = "password", Role = "Admin" },
                new User { UserId = 2, FirstName = "Jane", LastName = "Doe", UserName = "jane.doe", Password = "password", Role = "User" }
            );

            // Seed the data for Reviews
            modelBuilder.Entity<Review>().HasData(
                new Review { ReviewId = 1, Comment = "Great movie!", Rating = 5, MoviesId = 1 },
                new Review { ReviewId = 2, Comment = "Awesome director!", Rating = 4, MoviesId = 2 }
            );

            // Seed the data for Bookings
            modelBuilder.Entity<Booking>().HasData(
                new Booking { BookingId = 1, BookingDate = DateTime.Now, UserId = 1, MoviesId = 1 },
                new Booking { BookingId = 2, BookingDate = DateTime.Now, UserId = 2, MoviesId = 2 }
            );

            // Seed the data for Countries
            modelBuilder.Entity<Country>().HasData(
                new Country { CountryId = 1, Name = "USA" },
                new Country { CountryId = 2, Name = "Canada" }
            );


        }

    }
}
