using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Interfaces;
using WebAPI.Models;
using WebAPI.Repo;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LinqController : ControllerBase
    {
        private readonly IGeneric<Actor> _actorservice;
        private readonly IGeneric<Movies> _MovieService;
        private readonly IGeneric<MovieActor> _MovieActorService;
        private readonly IGeneric<Genre> _genericService;
        private readonly IGeneric<Country> _Countryservice;
        //private readonly IGeneric<Review> _Reviewservice;
        private readonly IGeneric<Language> _languageservcie;

        public LinqController(IGeneric<Actor> actorservice, IGeneric<Movies> movieService, IGeneric<MovieActor> movieActorService, IGeneric<Genre> genericService, IGeneric<Country> countryservice, IGeneric<Language> languageservcie)
        {
            _actorservice = actorservice;
            _MovieService = movieService;
            _MovieActorService = movieActorService;
            _genericService = genericService;
            _Countryservice = countryservice;
            //_Reviewservice = reviewservice;
            _languageservcie = languageservcie;
        }

        [HttpGet("alldata")]
        public IActionResult GetAllData()
        {
            try
            {
                var actors = _actorservice.GetAll();
                var movieactors = _MovieActorService.GetAll();
                var movie=_MovieService.GetAll();
                var country=_Countryservice.GetAll();
                var language=_languageservcie.GetAll();
                var genre=_genericService.GetAll();
                //var review = _Reviewservice.GetAll();


                var result = new
                {

                };

                return Ok(result);

            }
            catch (Exception ex) 
            {
                return StatusCode(500, "Internal server error ");
            }
        }
    }
}
