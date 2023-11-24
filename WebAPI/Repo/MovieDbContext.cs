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



    }
}
