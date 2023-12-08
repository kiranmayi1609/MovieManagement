using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class MovieGenre
    {
        [Key]
        public int Id { get; set; }
        public int MoviesId { get; set; }
        public Movies Movies { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
    }
}
