using GraphQL.Types;
using GraphStudy.Movies.Services;

namespace GraphStudy.Movies.Schema
{
    public class MoviesQuery : ObjectGraphType
    {
        public MoviesQuery(IMovieService movieService)
        {
            Name = "Query";

            Field<ListGraphType<MovieType>>("movies", resolve: context => movieService.GetAsyncs());

            Field<MovieType>("movie",arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id"}), resolve: context => movieService.GetByIdAsync(context.GetArgument<int>("id")));
        }
    }
}
