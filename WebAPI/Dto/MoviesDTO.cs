using WebAPI.Models;

namespace WebAPI.Dto
{
    public class MoviesDTO
    {
        public string Title { get; set; }
       
        public ICollection<Review> Reviews { get; set; }
        
        public ICollection<MovieGenre> MoviesGenre { get; set; }
        public ICollection<Award> Awards { get; set; }
        public Director Director { get; set; } 

        public int DirectorId { get; set; }
    }
}
