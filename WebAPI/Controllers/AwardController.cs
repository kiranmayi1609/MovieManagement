using Microsoft.AspNetCore.Mvc;
using WebAPI.Dto;
using WebAPI.Models;
using WebAPI.Repo;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AwardController : ControllerBase
    {
        private readonly GenericRepocs<Award> _awardRepo;

        //D injection of MovieDbcontext to initilize the repository 
        public AwardController(MovieDbContext db)
        {
            _awardRepo = new GenericRepocs<Award>(db);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Award>> GetAll()
        {
            var awards = _awardRepo.GetAll();

            var awardslist = awards.Select(awards => new AwardDto
            {
                AwardId=awards.AwardId,
                AwardName = awards.AwardName,
                MovieId=awards.MoviesId
            }).ToList();

            return Ok(awardslist);
        }

        [HttpGet("{id}")]
        public ActionResult<Award> GetById(int id)
        {
            //Retrieve a movie by its ID from the repository 
            var awards = _awardRepo.GetbyId(id);
            //if the movie is not found ,return an HTTP 404 not found response 
            if (awards == null)
            {
                return NotFound();
            }
            //Return the movie as an Http 200 ok reposne 

            return Ok(awards);

        }

        [HttpPost]
        public ActionResult CreateMovie([FromBody] AwardDto awarddto)
        {

            try
            {
                var awards = new Award
                {
                    AwardName = awarddto.AwardName,
                    MoviesId = awarddto.MovieId,
                };
                _awardRepo.Create(awards);
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
            var movie = _awardRepo.GetbyId(id);
            //if the movie is not found ,return an HTTP 404 not Found response 
            if (movie == null)
            {
                return NotFound();
            }
            try
            {
                _awardRepo.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            ////Delete the movie from the repistory 
            //_MovieRepository.Delete(movie);
            ////Return an HTTP 204 no content reposne 
            //return NoContent();
        }
        [HttpPut]
        public ActionResult UpdateMovie(int id, AwardDto awardDto)
        {
            var existingawards = _awardRepo.GetbyId(id);
            if (existingawards == null)
            {
                return NoContent();
            }
            existingawards.AwardName = awardDto.AwardName;
            existingawards.MoviesId = awardDto.MovieId;

            try
            {
                _awardRepo.Update(id, existingawards);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }


    }
}
