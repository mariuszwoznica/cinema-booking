using CinemaBooking.Modules.Movies.Core.Entities;
using CinemaBooking.Modules.Movies.Core.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace CinemaBooking.Modules.Movies.Core.Data;

internal class MovieRepository(MoviesDbContext context) : IMovieRepository
{
    private const string Config = "simple";

    public async Task<Movie> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        => await context.Movies
               .AsNoTracking()
               .SingleOrDefaultAsync(m => m.Id == id, cancellationToken)
           ?? throw new MovieNotFoundException(id);

    public async Task<IReadOnlyCollection<Movie>> GetListAsync(string searchPhrase, CancellationToken cancellationToken)
        => await context.Movies
            .Where(m => EF.Functions.ToTsVector(Config, m.Title)
                .Matches(EF.Functions.PhraseToTsQuery(Config, searchPhrase)))
            .AsNoTracking()
            .ToListAsync(cancellationToken);

    public async Task CreateAsync(Movie movie, CancellationToken cancellationToken)
    {
        context.Movies.Add(movie);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(Movie movie, CancellationToken cancellationToken)
    {
        context.Movies.Update(movie);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(Movie movie, CancellationToken cancellationToken)
    {
        context.Movies.Remove(movie);
        await context.SaveChangesAsync(cancellationToken);
    }
}