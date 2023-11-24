using Microsoft.EntityFrameworkCore.ChangeTracking;
using WebAPI.Interfaces;

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
            _db.Set<T>().Add(entity);
            _db.SaveChanges();
        }

        public void Delete(T entity)
        {
            _db.Set<T>().Remove(entity);
            _db.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            return _db.Set<T>().ToList();
        }

        public T GetbyId(int id)
        {
          return _db.Set<T>().ToList()[id];
        }

        public void Update(T entity)
        {
            _db.Set<T>().Update(entity);
            _db.SaveChanges();
        }
    }
}
