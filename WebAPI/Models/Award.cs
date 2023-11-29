using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class Award
    {
        [Key]
        public int AwardId { get; set; }
        public string AwardName { get; set; }   
        
        public int MoviesId { get; set; }
        public Movies Movies { get; set; }//
    }
}
