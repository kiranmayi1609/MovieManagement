using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; }

        public string  Password { get; set; }
        public string Role { get; set; }
        public ICollection<Review>Reviews { get; set; }
        public ICollection<Booking>Bookings { get; set; }
    }
}
