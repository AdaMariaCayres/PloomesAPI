using System.Threading.Tasks;
using WebApplicationPloomes.Models;

namespace WebApplicationPloomes.Interfaces
{
    public interface IDirectorRepository
    {
        void Create(Director director);
        void Delete(Director director);
        void Update(Director director);
        Task<Director> SelectById(int id);
        Task<IEnumerable<Director>> Selectall();
        Task<bool> SaveAsync();
    }
}
