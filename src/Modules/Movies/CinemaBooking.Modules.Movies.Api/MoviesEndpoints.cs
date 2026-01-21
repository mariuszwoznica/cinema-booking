using CinemaBooking.Common.Infrastructure.Validation;
using CinemaBooking.Modules.Movies.Core.DTOs;
using CinemaBooking.Modules.Movies.Core.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace CinemaBooking.Modules.Movies.Api;

public static class MoviesEndpoints
{
    public static void MapMoviesEndpoints(this IEndpointRouteBuilder app)
    {
        var endpoints = app.MapGroup("/movies");

        endpoints.MapPost("/", CreateMovie)
            .WithSummary("Creates a new movie")
            .WithRequestValidation<MovieCreateRequest>();
    }
    
    private static async Task<IResult> CreateMovie(
        MovieCreateRequest request,
        IMovieService movieService,
        CancellationToken cancellationToken)
    {
        var response = await movieService.CreateAsync(request, cancellationToken);
        return TypedResults.CreatedAtRoute(
            //routeName: nameof(GetMovie),
            routeValues: new { movieId = response.Id },
            value: response);
    }
}