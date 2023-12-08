using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }
        public string Comment { get; set; }

        public int Rating { get; set; }
        public Movies Movies { get; set; }
        public int MoviesId { get; set; }


    }
}
