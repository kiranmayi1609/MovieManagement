namespace WebAPI.Interfaces
{
    public interface IGeneric<T>  where T : class

    {
       IEnumerable<T> GetAll();
       T GetbyId(int id);

       void Create (T entity);

       void Update (int id, T entity);

       void Delete (T entity);
      

    }
}
