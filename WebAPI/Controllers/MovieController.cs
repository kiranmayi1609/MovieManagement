using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using WebAPI.Repo;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        //Repository for performing CRUD OPERATIONS on Movie entities 
        private readonly GenericRepocs<Movies> _MovieRepository;

        //Constructor injection of MovieDbContext to initialze the repository 
        public MovieController(MovieDbContext db)
        {
            _MovieRepository = new GenericRepocs<Movies>(db);
        }
        //Get:api/Movies
        [HttpGet]
        public ActionResult<IEnumerable<Movies>> Get()
        {
            //Retrieve all movies from the repository 
            var movies=_MovieRepository.GetAll();
            //Return the list of movies as an Http 200 ok response 
            return Ok(movies);

        }
        [HttpGet("{id}")]
        public ActionResult<Movies> GetById(int id )
        {
            //Retrieve a movie by its ID from the repository 
            var movie = _MovieRepository.GetbyId(id);
            //if the movie is not found ,return an HTTP 404 not found response 
            if(movie == null)
            {
                return NotFound();
            }
            //Return the movie as an Http 200 ok reposne 

            return Ok(movie);
        }
        //Post:api/Movies 
        [HttpPost]
        public ActionResult Post([FromBody] Movies movie)
        {
            //Check if the model state is valid (based on data annotations )
            if(ModelState.IsValid)
            {
                //Create the new movie in the repository 
                _MovieRepository.Create(movie);
                //Return the created movie as an HTTP 200 ok response 
                return Ok(movie);
            }
            //if the model state is not valid ,return an Http 400 bad request response 
            return BadRequest(ModelState);
        }
        [HttpPut]
        public ActionResult Delete(int id )
        {
            //Retreive the movie by its ID from the repository 
            var movie=_MovieRepository.GetbyId(id);
            //if the movie is not found ,return an HTTP 404 not Found response 
            if( movie == null)
            {
                return NotFound();
            }
            //Delete the movie from the repistory 
            _MovieRepository.Delete(movie);
            //Return an HTTP 204 no content reposne 
            return NoContent();
        }


    }
}
