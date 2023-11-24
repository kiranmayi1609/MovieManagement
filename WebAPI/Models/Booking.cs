using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class Booking
    {
        [Key]
        public int BookingId { get; set; }
        public DateTime BookingDate { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }

        public Movies Movies { get; set; }

        public int MovieId { get; set; }
    }
}
