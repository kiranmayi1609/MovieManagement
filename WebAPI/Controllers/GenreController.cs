using Microsoft.AspNetCore.Mvc;
using WebAPI.Dto;
using WebAPI.Models;
using WebAPI.Repo;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        //Repository for performing CRUD OPERATIONS on Movie entities 
        private readonly GenericRepocs<Genre> _GenreRepository;

        //Constructor injection of MovieDbContext to initialze the repository 
        public GenreController(MovieDbContext db)
        {
            _GenreRepository = new GenericRepocs<Genre>(db);
        }
        //Get:api/Movies
        [HttpGet]
        public ActionResult<IEnumerable<Genre>> Get()
        {
            //Retrieve all movies from the repository 
            var genre = _GenreRepository.GetAll();
            //Return the list of movies as an Http 200 ok response 
            var genre1 = genre.Select(genre => new GenreDto
            {
                GenreId=genre.GenreId,
                Name=genre.Name,

            }).ToList();
            return Ok(genre1);

        }
        [HttpGet("{id}")]
        public ActionResult<Genre> GetById(int id)
        {
            //Retrieve a genre by its ID from the repository 
            var genre = _GenreRepository.GetbyId(id);
            //if the genre is not found ,return an HTTP 404 not found response 
            if (genre == null)
            {
                return NotFound();
            }
            //Return the genre as an Http 200 ok reposne 

            return Ok(genre);
        }
        //Post:api/Movies 
        [HttpPost]
        public ActionResult Post([FromBody] Genre genre)
        {
            //Check if the model state is valid (based on data annotations )
            if (ModelState.IsValid)
            {
                //Create the new movie in the repository 
                _GenreRepository.Create(genre);
                //Return the created movie as an HTTP 200 ok response 
                return Ok(genre);
            }
            //if the model state is not valid ,return an Http 400 bad request response 
            return BadRequest(ModelState);
        }
        [HttpPut]
        public ActionResult Delete(int id)
        {
            //Retreive the genre by its ID from the repository 
            var genre = _GenreRepository.GetbyId(id);

            if(genre== null)
            {
                return NotFound();
            }
            try
            {
                _GenreRepository.Delete(id);
                return NoContent();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            ////if the genre is not found ,return an HTTP 404 not Found response 
            //if (genre == null)
            //{
            //    return NotFound();
            //}
            ////Delete the genre  from the repistory 
            //_GenreRepository.Delete(genre);
            ////Return an HTTP 204 no content reposne 
            //return NoContent();
        }


    }
}

