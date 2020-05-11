using GraphStudy.Movies.Movies;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GraphStudy.Movies.Services
{
    public interface IMovieService
    {
        Task<IEnumerable<Movie>> GetAsyncs();
        Task<Movie> GetByIdAsync(int id);
        Task<Movie> CreateAsync(Movie movie);
        Task<Movie> UpdateAsync(Movie movie);
        void DeleteAsync(int id);
    }
}
