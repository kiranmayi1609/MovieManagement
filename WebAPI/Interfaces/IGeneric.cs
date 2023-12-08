using System.Linq.Expressions;

namespace WebAPI.Interfaces
{
    public interface IGeneric<T>  where T : class

    {
         IEnumerable<T> GetAll();
        T GetbyId(int id);

         void Create (T entity);

        void Update (int id, T entity);

       void Delete (int id );
        //T GetDetails(int id, params Expression<Func<T, object>>[] includes);

        //Demonstrating LINQ queries within the generic repso  for the model entity 
        public IEnumerable<T>GetMoviesWithGenre(string genreName );
        public IEnumerable<T> GetMovieswithDirectors(string directorName );
        public IEnumerable<T> FindEntities(Func<T, bool> predicate);
        //method to get entities with sepcific includes based on a predicate 

       public  IEnumerable<T> GetEntitiesWithIncludes(Func<T, bool> predicate, params Expression<Func<T, object>>[] includes);
        public IEnumerable<object> GetAllData();
    }
}
