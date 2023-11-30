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
    public class GenericRepositoryTests
    {
        private readonly MovieDbContext _dbContext;
        private readonly GenericRepocs<Movies> _repository;

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
            _repository = new GenericRepocs<Movies>(_dbContext);
        }
        [Fact]
        public void Create_ShouldAddEntityToDatabase()
        {
            //Arrange 
            var entity = new Movies { MovieId = 1, Title = "TestEntity1", DirectorId = 1 };

            //Act 
            _repository.Create(entity);

            //Assert
            Assert.Equal(1, _dbContext.movies.Count());
            Assert.Equal("TestEntity",_dbContext.movies.Single().Title);
        }
        

        
    }
}

