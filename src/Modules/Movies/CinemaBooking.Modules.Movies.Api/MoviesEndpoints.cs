using CinemaBooking.Common.Infrastructure.Validation;
using CinemaBooking.Modules.Movies.Core.DTOs;
using CinemaBooking.Modules.Movies.Core.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Routing;

namespace CinemaBooking.Modules.Movies.Api;

public static class MoviesEndpoints
{
    public static void MapMoviesEndpoints(this IEndpointRouteBuilder app)
    {
        var endpoints = app.MapGroup("/movies");

        endpoints.MapGet("/{movieId:guid}", GetMovie)
            .WithSummary("Gets a movie")
            .WithName(nameof(GetMovie));

        endpoints.MapGet("/", GetMovies)
            .WithSummary("Gets movies matched a search phrase");

        endpoints.MapPost("/", CreateMovie)
            .WithSummary("Creates a new movie")
            .WithRequestValidation<MovieCreateRequest>();
        
        endpoints.MapPut("/{movieId:guid}", UpdateMovie)
            .WithSummary("Updates a movie")
            .WithRequestValidation<MovieUpdateRequest>();

        endpoints.MapDelete("/{movieId:guid}", DeleteMovie)
            .WithSummary("Deletes a movie");
    }
    
    private static async Task<Results<Ok<MovieDto>, NotFound>> GetMovie(
        Guid movieId,
        IMovieService movieService,
        CancellationToken cancellationToken)
    {
        var movie = await movieService.GetAsync(movieId, cancellationToken);
        return TypedResults.Ok(movie);
    }

    private static async Task<Ok<IReadOnlyCollection<MovieDto>>> GetMovies(
        string searchPhrase,
        IMovieService movieService,
        CancellationToken cancellationToken)
    {
        var movies = await movieService.GetBySearchPhraseAsync(searchPhrase, cancellationToken);
        return TypedResults.Ok(movies);
    }
    
    private static async Task<IResult> CreateMovie(
        MovieCreateRequest request,
        IMovieService movieService,
        CancellationToken cancellationToken)
    {
        var response = await movieService.CreateAsync(request, cancellationToken);
        return TypedResults.CreatedAtRoute(
            routeName: nameof(GetMovie),
            routeValues: new { movieId = response.Id },
            value: response);
    }
    
    private static async Task<NoContent> UpdateMovie(
        Guid movieId,
        MovieUpdateRequest request,
        IMovieService movieService,
        CancellationToken cancellationToken)
    {
        await movieService.UpdateAsync(movieId, request, cancellationToken);
        return TypedResults.NoContent();
    }
    
    private static async Task<NoContent> DeleteMovie(
        Guid movieId,
        IMovieService movieService,
        CancellationToken cancellationToken)
    {
        await movieService.DeleteAsync(movieId, cancellationToken);
        return TypedResults.NoContent();
    }
}