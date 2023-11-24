using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class Language
    {
        [Key]
        public int LanguageId { get; set; } 

        public string Name { get; set; }    
        public ICollection<Movies> Movies { get; set; }
    }
}
