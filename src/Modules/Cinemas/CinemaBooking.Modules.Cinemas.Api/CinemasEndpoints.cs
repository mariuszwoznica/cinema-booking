using CinemaBooking.Common.Infrastructure.Validation;
using CinemaBooking.Modules.Cinemas.Core.DTOs;
using CinemaBooking.Modules.Cinemas.Core.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Routing;

namespace CinemaBooking.Modules.Cinemas.Api;

public static class CinemasEndpoints
{
    public static void MapCinemasEndpoints(this IEndpointRouteBuilder app)
    {
        var endpoints = app.MapGroup("/cinemas");

        endpoints.MapGet("/{cinemaId:guid}", GetCinema)
            .WithName(nameof(GetCinema));

        endpoints.MapPost("/", CreateCinema)
            .WithRequestValidation<CinemaCreateRequest>();

        endpoints.MapPut("/{cinemaId:guid}", UpdateCinema)
            .WithRequestValidation<CinemaUpdateRequest>();

        endpoints.MapDelete("/{cinemaId:guid}", DeleteCinema);
    }

    private static async Task<Results<Ok<CinemaDto>, NotFound>> GetCinema(
        Guid cinemaId,
        ICinemaService cinemaService,
        CancellationToken cancellationToken)
    {
        var cinema = await cinemaService.GetAsync(cinemaId, cancellationToken);
        return cinema is null
            ? TypedResults.NotFound()
            : TypedResults.Ok(cinema);
    }

    private static async Task<IResult> CreateCinema(
        CinemaCreateRequest request,
        ICinemaService cinemaService,
        CancellationToken cancellationToken)
    {
        var response = await cinemaService.CreateAsync(request, cancellationToken);
        return TypedResults.CreatedAtRoute(
            routeName: nameof(GetCinema),
            routeValues: new { cinemaId = response.Id },
            value: response);
    }

    private static async Task<NoContent> UpdateCinema(
        Guid cinemaId,
        CinemaUpdateRequest request,
        ICinemaService cinemaService,
        CancellationToken cancellationToken)
    {
        await cinemaService.UpdateAsync(cinemaId, request, cancellationToken);
        return TypedResults.NoContent();
    }

    private static async Task<NoContent> DeleteCinema(
        Guid cinemaId,
        ICinemaService cinemaService,
        CancellationToken cancellationToken)
    {
        await cinemaService.DeleteAsync(cinemaId, cancellationToken);
        return TypedResults.NoContent();
    }
}