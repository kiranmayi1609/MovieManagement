using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.Repo;
using Xunit;

namespace MovieTesting.RepoUnit
{
    //unit tests for GenericRepository using in-memory database 
    public class GenericRepositoryTests:IDisposable
    {
        private readonly MovieDbContext _dbContext;
        private readonly GenericRepocs<Movies> _movierepository;

        /// <summary>
        /// we want to take Db offline ,so we can focus on Repo layer 
        /// to do that we use Inmemory Db 
        /// </summary>
        /// 

        public GenericRepositoryTests()
        {
            //using an in-memory database for testing 
            var options = new DbContextOptionsBuilder<MovieDbContext>().UseInMemoryDatabase(databaseName: "TestDatabase").Options;


            _dbContext = new MovieDbContext(options);
            _movierepository = new GenericRepocs<Movies>(_dbContext);
        }
        public void Dispose()
        {
            _dbContext.Dispose();
        }
        [Fact]
        public void GetAll_ReturnsAllMovies()
        {
            //arrange
            _dbContext.movies.AddRange(new List<Movies>
            {
                new Movies{MovieId=1,Title="Movie 3"},
                new Movies{MovieId=2,Title="Movie 4"}

            });
            _dbContext.SaveChanges();

            //Act 
            var movies = _movierepository.GetAll();

            //Assert 
            Assert.NotNull(movies);
            Assert.Equal(2, movies.Count());// the count based on the added movies 
        }

        
    }
}

