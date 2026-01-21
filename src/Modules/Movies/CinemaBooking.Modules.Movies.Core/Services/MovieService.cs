using CinemaBooking.Modules.Movies.Core.DTOs;

namespace CinemaBooking.Modules.Movies.Core.Services;

public class MovieService : IMovieService
{
    public Task<MovieDto> GetAsync(Guid id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<MovieDto> CreateAsync(MovieCreateRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Guid id, MovieUpdateRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}