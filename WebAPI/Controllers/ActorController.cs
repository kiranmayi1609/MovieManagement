using Microsoft.AspNetCore.Mvc;
using WebAPI.Dto;
using WebAPI.Models;
using WebAPI.Repo;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorController : ControllerBase
    {
        private readonly GenericRepocs<Actor> _actorRepo;
        // GET: api/<ActorController>
         //constructor injection of MovieDbcontext to initilize the repositorry 
        public ActorController(MovieDbContext db)
        {
            _actorRepo = new GenericRepocs<Actor>(db);
        }
        [HttpGet]
        public  ActionResult <IEnumerable<Actor>>GetAllActors ()
        {
            //Retrieve all actors from the repo
            var actor = _actorRepo.GetAll();
            //Return the list of actors as an http 200 ok response 

            var AllActors=actor.Select(actor=>new ActorDto
            {
                ActorId=actor.Id,
                Name=actor.Name,
            }).ToList();
                
            return Ok(AllActors);
        }

        [HttpGet("{id}")]
        public ActionResult<Actor> GetActorById(int id)
        {
            //Retrieve all actors  id from the repository 
           
            var actor = _actorRepo.GetbyId(id);
            if(actor == null)
            {
                return NotFound();
            }
            return Ok(actor);
        }
        [HttpPost]
        public IActionResult CreateActor([FromBody] ActorDto actordto )
        {
            try
            {
                var actors = new Actor
                {
                    Name = actordto.Name,
                };
                _actorRepo.Create(actors);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }



            
        }
        [HttpPut("{id}")]
        public IActionResult UpdateActor(int id, [FromBody]ActorDto actordto)
        {
            var exisitngActor = _actorRepo.GetbyId(id);
            if(exisitngActor==null)
            {
                return NoContent();
            }
            exisitngActor.Name = actordto.Name;
            try
            {
                _actorRepo.Update(id, exisitngActor);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteActor(int id )
        {
            var actor=_actorRepo.GetbyId(id);
            // if the actor is not found ,return Http 404 not found respomnse 
            if(actor==null)
            {
                return NotFound();
            }
            try
            {
                _actorRepo.Delete(id);
                return NoContent();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        //[HttpGet("movieswithgenre/{genrename}")]

        //public IEnumerable<Actor>GetActorwithgenre(string genrename )
        //{
        //    return _actorRepo.GetMoviesWithGenre(genrename);
        //}
        //[HttpGet("moviewithdirectors/{directorname}")]
        //public IEnumerable<Actor>getActorwithdirectors(string directorname )
        //{
        //    return _actorRepo.GetMovieswithDirectors(directorname);
        //}
    }
    


}

