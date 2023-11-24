using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class Director
    {
        [Key]
        public int DirectorId { get; set; }
        public string Name { get; set; }
        public ICollection<Movies>MovieDirector { get; set; }

    }
}
