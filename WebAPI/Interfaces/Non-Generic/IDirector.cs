using WebAPI.Models;

namespace WebAPI.Interfaces.Non_Generic
{
    public interface IDirector
    {
        IEnumerable<Director> GetDirectors();
        IEnumerable<Director> GetDirectors(string name);

        void Create (Director director);

        void Update (Director director);

        void Delete (Director director);
    }
}
