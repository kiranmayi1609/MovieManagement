using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using WebAPI.Repo;



namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly GenericRepocs<Booking> _bookingRepo;
        // GET: api/<BookingController>
        
        public BookingController(MovieDbContext db)
        {
            _bookingRepo = new GenericRepocs<Booking>(db);
        }
        [HttpGet]
        public ActionResult<IEnumerable<Booking>> Get()
        {
            var booking = _bookingRepo.GetAll();

            return booking.ToList();
            //return Ok(booking)
        }
      

            
       
    }
}
