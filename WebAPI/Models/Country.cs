using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class Country
    {
        [Key]
        public int CountryId { get; set; }  
        public string Name { get; set; }
        public ICollection<Movies> MoviesProduced { get; set; }
    }
}
