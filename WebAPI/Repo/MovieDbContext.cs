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
                new Actor { ActorId = 1, Name = "Actor1" },
                new Actor { ActorId = 2, Name = "Actor2" }

                );

            //seed the data for Awards 
            modelBuilder.Entity<Award>().HasData (
                  new Award { AwardId=1,AwardName="Best Actor",MovieId=1},
                   new Award { AwardId=2,AwardName="Best Director",MovieId =2}

                );
            //Movies 
            modelBuilder.Entity<Movies>().HasData(
                new Movies { MovieId = 1, Title = "Movie 1", DirectorId = 1 },
                new Movies { MovieId = 2, Title = "Movie 2", DirectorId = 2 });
            //Directors 
            modelBuilder.Entity<Director>().HasData(
                new Director { DirectorId = 1, Name = "Director 1" },
                new Director { DirectorId = 2, Name = "Director2" });
            //Genres
            modelBuilder.Entity<Genre>().HasData(
                new Genre { GenreId = 1, Name = "Action" },
                new Genre { GenreId = 2, Name = "Comedy" });
            //Language 
            modelBuilder.Entity<Language>().HasData(
                new Language { LanguageId = 1, Name = "English" },
                new Language { LanguageId = 2, Name = "Spanish " });

        }

    }
}
