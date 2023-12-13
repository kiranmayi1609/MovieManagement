using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class Actor
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<MovieActor> MovieActor { get; set; }
    }
}
