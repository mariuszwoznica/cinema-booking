using CinemaBooking.Modules.Movies.Core.DTOs;
using CinemaBooking.Modules.Movies.Core.Exceptions;

namespace CinemaBooking.Modules.Movies.Core.Services;

internal class MovieService(IMovieRepository repository) : IMovieService
{
    public async Task<MovieDto> GetAsync(Guid id, CancellationToken cancellationToken)
    {
        var movie = await repository.GetByIdAsync(id, cancellationToken);
        return movie.ToDto();
    }

    public async Task<IReadOnlyCollection<MovieDto>> GetBySearchPhraseAsync(string searchPhrase, CancellationToken cancellationToken)
    {
        var movies = await repository.GetListAsync(searchPhrase, cancellationToken);
        
        return movies.Select(movie => movie.ToDto()).ToList();
    }

    public async Task<MovieDto> CreateAsync(MovieCreateRequest request, CancellationToken cancellationToken)
    {
        var directors = request.Directors.Select(d => d.ToEntity()).ToList();
        var movieExists = await repository.ExistsAsync(request.Title, directors, cancellationToken);
        if (movieExists)
        {
            throw MovieAlreadyExistsException.Create(request.Title, directors);
        }

        var movie = request.ToEntity();
        await repository.CreateAsync(movie, cancellationToken);
        return movie.ToDto();
    }

    public async Task UpdateAsync(Guid id, MovieUpdateRequest request, CancellationToken cancellationToken)
    {
        var movie = await repository.GetByIdAsync(id, cancellationToken);

        movie.Update(
            title: request.Title,
            description: request.Description,
            length: request.Length,
            releaseDate: request.ReleaseDate,
            genres: request.Genres.Select(genre => genre.ToEntity()),
            ageRestriction: request.AgeRestriction,
            directors: request.Directors.Select(director => director.ToEntity()),
            cast: request.Cast.Select(cast => cast.ToEntity()));

        await repository.UpdateAsync(movie, cancellationToken);
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var movie = await repository.GetByIdAsync(id, cancellationToken);
        await repository.DeleteAsync(movie, cancellationToken);
    }
}