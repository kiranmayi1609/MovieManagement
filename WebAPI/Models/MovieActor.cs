using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class MovieActor
    {
        [Key]
        public int Id { get; set; }
        public int MoviesId { get; set; }
        public Movies Movies { get; set; }
        public Actor Actor { get; set; }

        public int ActorId { get; set; }
    }
}
