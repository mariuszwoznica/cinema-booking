using CinemaBooking.Modules.Movies.Core.DTOs;

namespace CinemaBooking.Modules.Movies.Core.Services;

public interface IMovieService
{
    Task<MovieDto> CreateAsync(MovieCreateRequest request, CancellationToken cancellationToken);
}