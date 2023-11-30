﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;
using WebAPI.Interfaces;
using WebAPI.Models;

namespace WebAPI.Repo
{
    public class GenericRepocs<T> : IGeneric<T> where T : class
    {
        private readonly MovieDbContext _db; // inject my entity framework 

        public GenericRepocs(MovieDbContext db)
        {
            _db = db;     
        }

        public void Create(T entity)
        {
            try
            {
                _db.Set<T>().Add(entity);
                _db.SaveChanges();

            }
            catch(Exception ex)

            {
                throw new Exception("Error occured while using saving changes ",ex);

            }
            
        }

        public void Delete(int id )
        {
            var entityToDelete= _db.Set<T>().Find(id);
            if(entityToDelete!=null)
            {
                _db.Set<T>().Remove(entityToDelete);
                _db.SaveChanges();
            }

            //_db.Set<T>().Remove(entity);
            //_db.SaveChanges();
        }

        // FindEntities method to search entities based on a predicate 
        /// <summary>
        /// its delegate that represents a method recieves input type T and returns a boolenvalue('true' or 'false')
        /// deletages is nicwe to use filtering elements in LINQ queries 
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public IEnumerable<T> FindEntities(Func<T, bool> predicate)
        {
            return _db.Set<T>().Where(predicate).ToList();
        }

        public IEnumerable<T> GetAll()
        {
            return _db.Set<T>().ToList();
        }

        public T GetbyId(int id)
        {
            return _db.Set<T>().Find(id);
          //return _db.Set<T>().ToList()[id];
        }

        

        public IEnumerable<T> GetEntitiesWithIncludes(Func<T, bool> predicate, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query =_db.Set<T>().AsQueryable();
            foreach(var include in includes)
            {
                query=query.Include(include);
            }
            return query.Where(predicate).ToList();
        }

        public IEnumerable<T> GetMovieswithDirectors(string directorName)
        {
            throw new NotImplementedException();
            //return _db.Set<Movies>().Where(movie => movie.MoviesGenre.Any(mg => mg.Genre.Name == genreName)).ToList().Cast<T>();


        }

        public IEnumerable<T> GetMoviesWithGenre(string genreName)
        {
            throw new NotImplementedException();
            //return _db.Set<Movies>().Where(movie => movie.Director.Name == directorName).ToList().Cast<T>();
        }

        public void Update(int id,T entity)
        {
            var existingEntity = _db.Set<T>().Find(id);
            if (existingEntity != null)
            {
                _db.Entry(existingEntity).CurrentValues.SetValues(entity);
                _db.SaveChanges();
            }
            //_db.Set<T>().Update(entity);
            //_db.SaveChanges();
        }

        //public T GetDetails(int id, params Expression<Func<T, object>>[] includes)
        //{
        //    // Start building the query by getting a set of the entity type
        //    var query = _db.Set<T>().AsQueryable();

        //    // Iterate through the provided include expressions
        //    foreach (var include in includes)
        //    {
        //        // Add each include expression to the query
        //        query = query.Include(include);
        //    }

        //    // Execute the query, including the specified related entities, and filter by the given 'id'
        //    return query.FirstOrDefault(e => e.Id == id);
        //    // Replace 'Id' with the actual primary key property of your entity
        //}

    }
}
