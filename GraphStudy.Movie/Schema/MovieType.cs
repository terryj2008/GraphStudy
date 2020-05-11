using GraphQL.Types;
using GraphStudy.Movies.Movies;
using GraphStudy.Movies.Services;

namespace GraphStudy.Movies.Schema
{
    public class MovieType : ObjectGraphType<Movie>
    {
        public MovieType(IActorService actorService)
        {
            Name = "Movie";
            Description = "";

            Field(x => x.Id);
            Field(x => x.Name);
            Field(x => x.Company);
            Field(x => x.ReleaseDate);
            Field(x => x.ActorId);

            Field<MovieRatingEnum>("movieRating", resolve: context => context.Source.MovieRating);

            Field<ActorType>("Actor", resolve: context => actorService.GetByIdAsync(context.Source.ActorId));

            Field<StringGraphType>("customString", resolve: context => "1234");
        }
    }
}
