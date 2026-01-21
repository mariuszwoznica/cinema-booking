using CinemaBooking.Modules.Movies.Core.DTOs;

namespace CinemaBooking.Modules.Movies.Core.Services;

public class MovieService : IMovieService
{
    public Task<MovieDto> CreateAsync(MovieCreateRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}