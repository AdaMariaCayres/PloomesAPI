using System.Threading.Tasks;
using WebApplicationPloomes.Models;

namespace WebApplicationPloomes.Interfaces
{
    public interface IMovieRepository
    {
        void Create(Movie movie);
        void Delete(Movie movie);
        Task<Movie> SelectById(int id);
        Task<IEnumerable<Movie>> Selectall();
        Task<bool> SaveAsync();
    }
}
