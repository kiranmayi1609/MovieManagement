﻿using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using System.Reflection;
using WebAPI.Dto;
using WebAPI.Models;
using WebAPI.Repo;



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
            var movies1 = movies.Select(movie => new MoviesDTO
            {
                MovieId=movie.MovieId,
                DirectorId = movie.DirectorId,
                Title = movie.Title,

            }).ToList();
            return Ok(movies1);

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
        public ActionResult CreateMovie([FromBody] MoviesDTO moviedto)
        {

            try
            {
                var movies = new Movies
                {
                    Title = moviedto.Title,
                    DirectorId = moviedto.DirectorId
                };
                _MovieRepository.Create(movies);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.InnerException!=null? ex.InnerException.Message:ex.Message);
            }
            //Check if the model state is valid (based on data annotations )
            //if(ModelState.IsValid)
            //{
            //    //Create the new movie in the repository 
            //    _MovieRepository.Create(movie);
            //    //Return the created movie as an HTTP 200 ok response 
            //    return Ok(movie);
            //}
            ////if the model state is not valid ,return an Http 400 bad request response 
            //return BadRequest(ModelState);
        }
        [HttpDelete]
        public ActionResult Delete(int id )
        {
            //Retreive the movie by its ID from the repository 
            var movie=_MovieRepository.GetbyId(id);
            //if the movie is not found ,return an HTTP 404 not Found response 
            if( movie == null)
            {
                return NotFound();
            }
            try
            {
                _MovieRepository.Delete(id);
                return NoContent();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            ////Delete the movie from the repistory 
            //_MovieRepository.Delete(movie);
            ////Return an HTTP 204 no content reposne 
            //return NoContent();
        }
        [HttpPut]
        public ActionResult UpdateMovie(int id ,MoviesDTO movieDto)
        {
            var existingMovie=_MovieRepository.GetbyId(id);
            if(existingMovie == null)
            {
                return NoContent();
            }
            existingMovie.Title = movieDto.Title;
            existingMovie.DirectorId = movieDto.DirectorId;

            try
            {
                _MovieRepository.Update(id,existingMovie);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }
        [HttpGet("search")]

        public IActionResult GetMoviesByTitle([FromQuery] string title)
        {
            try
            {
                var movies = _MovieRepository.FindEntities(movies => movies.Title.Contains(title));
                return Ok(movies);
            }
            catch(Exception ex)
            {
               return StatusCode(500,$"An error occured :{ex.Message}");
            }
        }

        [HttpGet("movies")]
        public IActionResult GetMoviesWithIncludes()
        {
            try
            {
                Func<Movies, bool> moviePredicate = movie => movie.Title=="";

                Expression<Func<Movies, object>>[] movieInclude =
                {
                    movie=>movie.Reviews,
                    movie=>movie.MoviesGenre.Select(mg=>mg.Genre)
                };

                var moviesWithIncludes = _MovieRepository.GetEntitiesWithIncludes(moviePredicate, movieInclude);
                return Ok(moviesWithIncludes);
            }
            catch(Exception ex)
            {
                return StatusCode(500, $"An error occured:{ex.Message} ");
            }
        }



    }
}
