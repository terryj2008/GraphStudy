using GraphQL.Types;
using GraphStudy.Movies.Movies;
using GraphStudy.Movies.Services;
using System;
using System.Linq;

namespace GraphStudy.Movies.Schema
{
    public class MoviesMutation : ObjectGraphType
    {
        public MoviesMutation(IMovieService movieService)
        {
            Name = "Mutation";

            FieldAsync<MovieType>
            (
                "createMovie",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<MovieInputType>>
                {
                    Name = "movie"
                }),
                resolve: async context =>
                {
                    var movieInput = context.GetArgument<MovieInput>("movie");
                   
                    var movies = await movieService.GetAsyncs();
                    var maxId = movies.Select(x => x.Id).Max();

                    var movie = new Movie
                    {
                        Id = ++maxId,
                        Name = movieInput.Name,
                        Company = movieInput.Company,
                        ActorId = movieInput.ActorId,
                        MovieRating = movieInput.MovieRating,
                        ReleaseDate = movieInput.ReleaseDate
                    };
                    
                    var result = await movieService.CreateAsync(movie);
                    
                    return result;
                }
            );

            FieldAsync<MovieType>
            (
                "updateMovie",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<MovieInputType>>{Name = "movie"}),
                resolve: async context =>
                {
                    var movie = context.GetArgument<Movie>("movie");
                    if (movie == null)
                    {
                        throw new ArgumentException(String.Format("Can not find movie"));
                    }
                    var result = await movieService.UpdateAsync(movie);
                    return result;
                }
            );

            Field<StringGraphType>
           (
               "deleteMovie",
               arguments: new QueryArguments(
                   new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id" }),
               resolve: context =>
               {
                   int id = context.GetArgument<int>("id");
                   movieService.DeleteAsync(id);
                   return String.Format("The movie with the id: {0} has been successfully deleted.", id);
               }
           );
        }
    }
}