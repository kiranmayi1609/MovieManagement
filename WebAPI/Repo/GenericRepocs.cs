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

        public IEnumerable<T> GetAll()
        {
            return _db.Set<T>().ToList();
        }

        public T GetbyId(int id)
        {
            return _db.Set<T>().Find(id);
          //return _db.Set<T>().ToList()[id];
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
    }
}
