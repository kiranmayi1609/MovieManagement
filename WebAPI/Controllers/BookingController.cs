using Microsoft.AspNetCore.Mvc;
using WebAPI.Dto;
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

            var bookinglist=booking.Select(booking=> new BookingDto
            {
                BookingDate = booking.BookingDate,
                MovieId=booking.MoviesId,
                UserId=booking.UserId,
            }).ToList();
            return Ok(bookinglist);
          
        }
        [HttpGet("{id}")]
        public ActionResult<Booking> GetById(int id )
        {
            var booking=_bookingRepo.GetbyId(id);
           if(booking==null)
            {
                return NotFound();
            }

            return Ok(booking);
        }
        [HttpPost]
        public IActionResult CreateMovie([FromBody] BookingDto bookingDto)
        {
            try
            {
                var bookings = new Booking
                {
                    BookingDate=bookingDto.BookingDate,
                    MoviesId=bookingDto.MovieId,
                    UserId=bookingDto.UserId
                };
                _bookingRepo.Create(bookings);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            //Retreive the movie by its ID from the repository 
            var movie =_bookingRepo.GetbyId(id);
            //if the movie is not found ,return an HTTP 404 not Found response 
            if (movie == null)
            {
                return NotFound();
            }
            try
            {
                _bookingRepo.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }
        [HttpPut]
        public ActionResult UpdateMovie(int id, BookingDto bookingDto)
        {
            var existingbooking = _bookingRepo.GetbyId(id);
            if (existingbooking == null)
            {
                return NoContent();
            }
            existingbooking.BookingDate = bookingDto.BookingDate;
            existingbooking.MoviesId = bookingDto.MovieId;
            existingbooking.UserId=bookingDto.UserId;
             
            

            try
            {
               _bookingRepo.Update(id,existingbooking);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }






    }
}
