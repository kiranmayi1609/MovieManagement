using Microsoft.AspNetCore.Mvc;
using WebAPI.Dto;
using WebAPI.Models;
using WebAPI.Repo;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguageController : ControllerBase
    {
        private readonly GenericRepocs<Language> _Languagerepocs;


        public LanguageController(MovieDbContext db)
        {
            _Languagerepocs = new GenericRepocs<Language>(db);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Language>> Get()
        {
            //Retrieve all movies from the repository 
            var languages =_Languagerepocs.GetAll();
            //Return the list of movies as an Http 200 ok response 
            var languagelist = languages.Select(languages => new LanguageDto
            {
                Name=languages.Name,

            }).ToList();
            return Ok(languagelist);


        }
        [HttpGet("{id}")]
        public ActionResult<Movies> GetById(int id)
        {
            //Retrieve a movie by its ID from the repository 
            var language = _Languagerepocs.GetbyId(id);
            //if the movie is not found ,return an HTTP 404 not found response 
            if (language  == null)
            {
                return NotFound();
            }
            //Return the movie as an Http 200 ok reposne 

            return Ok(language );
        }


        [HttpPost]
        public ActionResult CreateMovie([FromBody] LanguageDto lanuguageDto)
        {

            try
            {
                var language = new Language
                {
                    Name = lanuguageDto.Name,
                };
                _Languagerepocs.Create(language);
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
            var language = _Languagerepocs.GetbyId(id);
            //if the movie is not found ,return an HTTP 404 not Found response 
            if (language == null)
            {
                return NotFound();
            }
            try
            {
                _Languagerepocs.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        public ActionResult UpdateMovie(int id,LanguageDto languagedto)
        {
            var existinglanguage = _Languagerepocs.GetbyId(id);
            if (existinglanguage == null)
            {
             return NoContent();
            }
            existinglanguage.Name = languagedto.Name;       

           try
           {
            _Languagerepocs.Update(id, existinglanguage);
              return Ok();
           }
           catch (Exception ex)
           {
           return BadRequest(ex.Message);

           }
        }




    }
 } 
