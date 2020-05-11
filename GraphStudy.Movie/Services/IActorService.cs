using GraphStudy.Movies.Movies;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GraphStudy.Movies.Services
{
    public interface IActorService
    {
        Task<Actor> GetByIdAsync(int id);
        Task<IEnumerable<Actor>> GetAsync();
    }
}
