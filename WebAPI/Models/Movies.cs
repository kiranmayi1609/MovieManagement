using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class Movies
    {
        [Key]
        public int MovieId { get; set; }
        public string Title { get; set; }
        //one to many relationship with reviews 
        //Navigate Properties 

        public ICollection<Review>Reviews { get; set; }
        //Many to many relationship with genre through MlovieGaenre 

        public ICollection<MovieGenre> MoviesGenre { get; set; }
        public ICollection<Award> Awards { get; set; }
        public Director Director { get; set; } //Navigating properties 

        public int DirectorId { get; set; }//ForeignKey 


    }
}
