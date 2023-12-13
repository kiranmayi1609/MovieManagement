using Microsoft.AspNetCore.Mvc;
using WebAPI.Dto;
using WebAPI.Models;
using WebAPI.Repo;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirectorController : ControllerBase
    {

        private readonly GenericRepocs<Director> _directorRepo;

        public DirectorController(MovieDbContext db)
        {
            _directorRepo = new GenericRepocs<Director>(db);

        }

        [HttpGet]
        public ActionResult<IEnumerable<Director>> Get()
        {
            //Retrieve all movies from the repository 
            var directors = _directorRepo.GetAll();
            //Return the list of movies as an Http 200 ok response 
            var directorlist = directors.Select(director => new DirectorDto
            {
                DirectorId=director.DirectorId,
                Name = director.Name,
              

            }).ToList();
            return Ok(directorlist);

        }
        [HttpGet("{id}")]
        public ActionResult<Movies> GetById(int id)
        {
            //Retrieve a movie by its ID from the repository 
            var director = _directorRepo.GetbyId(id);
            //if the movie is not found ,return an HTTP 404 not found response 
            if (director == null)
            {
                return NotFound();
            }
            //Return the movie as an Http 200 ok reposne 

            return Ok(director);
        }
        //Post:api/Movies 
        [HttpPost]
        public ActionResult CreateMovie([FromBody] DirectorDto directorDto)
        {

            try
            {
                var director = new Director
                {
                    Name=directorDto.Name,
                    
                };
                _directorRepo.Create(director);
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
            var director = _directorRepo.GetbyId(id);
            //if the movie is not found ,return an HTTP 404 not Found response 
            if (director == null)
            {
                return NotFound();
            }
            try
            {
                _directorRepo.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        public ActionResult UpdateMovie(int id,DirectorDto directorDto)
        {
            var existingdirector = _directorRepo.GetbyId(id);
            if (existingdirector == null)
            {
                return NoContent();
            }
              existingdirector.Name=directorDto.Name;
              

            try
            {
                _directorRepo.Update(id,existingdirector);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }
}   }