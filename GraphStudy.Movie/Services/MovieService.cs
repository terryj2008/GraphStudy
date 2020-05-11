using GraphStudy.Movies.Movies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphStudy.Movies.Services
{
    public class MovieService : IMovieService
    {
        private readonly IList<Movie> _movie;

        public MovieService()
        {
            _movie = new List<Movie>
            {
                #region Movie List
    
                new Movie
                {
                    Id = 1,
                    Name = "肖申克的救赎The Shawshank Redemption",
                    Company = "美国",
                    MovieRating = MovieRating.G,
                    ActorId = 1,
                    ReleaseDate = new DateTime(1994-10-14)
                },
                new Movie
                {
                    Id = 2,
                    Name = "这个杀手不太冷 Léon ",
                    Company = "法国",
                    MovieRating = MovieRating.NC17,
                    ActorId = 2,
                    ReleaseDate = new DateTime(1994-09-14)
                },
                new Movie
                {
                    Id = 3,
                    Name = "三傻大闹好莱坞",
                    Company = "印度",
                    MovieRating = MovieRating.PG,
                    ActorId = 3,
                    ReleaseDate = new DateTime(2011-12-08)
                },
                new Movie
                {
                    Id = 4,
                    Name = "功夫",
                    Company = "美国",
                    MovieRating = MovieRating.G,
                    ActorId = 4,
                    ReleaseDate = new DateTime(2004-12-23)
                }
                #endregion
            };
        }


        public Task<Movie> CreateAsync(Movie movie)
        {
            _movie.Add(movie);
            return Task.FromResult(movie);
        }

        public Task<Movie> UpdateAsync(Movie movie)
        {
            var obj = _movie.SingleOrDefault(x => x.Id == movie.Id);
            obj.Id = movie.Id;
            obj.Name = movie.Name;
            obj.ReleaseDate = movie.ReleaseDate;
            obj.Company = movie.Company;
            obj.ActorId = movie.ActorId;
            obj.MovieRating = movie.MovieRating;

            return Task.FromResult(obj);
        }
        
        public void DeleteAsync(int id)
        {
            var existingMovie = _movie.SingleOrDefault(x => x.Id == id);
            if (existingMovie == null)
            {
                throw new ArgumentException(String.Format("Can not find Movie"));
            }
            _movie.Remove(existingMovie);
        }

        public Task<IEnumerable<Movie>> GetAsyncs()
        {
            return Task.FromResult(_movie.AsEnumerable());
        }

        public Task<Movie> GetByIdAsync(int id)
        {
            var movie = _movie.SingleOrDefault(x => x.Id == id);
            if (movie == null)
            {
                throw new ArgumentException(String.Format("Movie ID {0} is not correct", id));
            }

            return Task.FromResult(movie);
        }
    }
}
