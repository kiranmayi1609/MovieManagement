using Microsoft.AspNetCore.Mvc;
using WebAPI.Dto;
using WebAPI.Models;
using WebAPI.Repo;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly GenericRepocs<ReviewController> _reviewRepo;

        public ReviewController(MovieDbContext db)
        {
            _reviewRepo=new GenericRepocs<ReviewController>(db);    
        }

        [HttpGet]
        //public ActionResult<IEnumerable<Review>> Get()
        //{

        //    var reviews = _reviewRepo.GetAll();

        //    var reviewslist= reviews.Select(review => new ReviewDto
        //    {



        //    }).ToList();
        //    return Ok(reviewslist);

        //}

        [HttpGet("{id}")]
        public ActionResult<Review> GetById(int id)
        {
            //Retrieve a movie by its ID from the repository 
            var reviews = _reviewRepo.GetbyId(id);
            //if the movie is not found ,return an HTTP 404 not found response 
            if (reviews == null)
            {
                return NotFound();
            }
            //Return the movie as an Http 200 ok reposne 

            return Ok(reviews);
        }

        //[HttpPost]
        //public ActionResult CreateMovie([FromBody] ReviewDto reviewDto)
        //{

        //    try
        //    {
        //        var reviews = new Review
        //        {
        //            Rating = reviewDto.Rating,
        //            Comment = reviewDto.Comment,
        //            MoviesId = reviewDto.MovieId,


        //        };
        //           _reviewRepo.Create(reviews);
        //            return Ok();
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.InnerException != null ? ex.InnerException.Message : ex.Message);
        //    }

        //}


        [HttpDelete]
        public ActionResult Delete(int id)
        {
            //Retreive the movie by its ID from the repository 
            var review = _reviewRepo.GetbyId(id);
            //if the movie is not found ,return an HTTP 404 not Found response 
            if (review == null)
            {
                return NotFound();
            }
            try
            {
                _reviewRepo.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
        //[HttpPut]
        //public ActionResult UpdateMovie(int id, ReviewDto reviewDto)
        //{
        //    var existingReview = _reviewRepo.GetbyId(id);
        //    if (existingReview == null)
        //    {
        //        return NoContent();
        //    }
        //      existingReview.rat
        //    try
        //    {
        //        _reviewRepo.Update(id, existingReview);
        //        return Ok();
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);

        //    }
        //}







    }
}
