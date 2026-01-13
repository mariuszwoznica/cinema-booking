using CinemaBooking.Modules.Cinemas.Core.DTOs;
using CinemaBooking.Modules.Cinemas.Core.Exceptions;

namespace CinemaBooking.Modules.Cinemas.Core.Services;

internal class CinemaService(ICinemaRepository repository) : ICinemaService
{
    public async Task<CinemaDto> GetAsync(Guid id, CancellationToken cancellationToken)
    {
        var cinema = await repository.GetByIdAsync(id, cancellationToken);
        return cinema.ToDto();
    }

    public async Task<CinemaDto> CreateAsync(CinemaRequest request, CancellationToken cancellationToken)
    {
        var cinemaExists = await repository.ExistsAsync(request.Name, cancellationToken);
        if (cinemaExists)
        {
            throw new CinemaAlreadyExistsException(request.Name);
        }

        var cinema = request.ToEntity();
        await repository.CreateAsync(cinema, cancellationToken);
        return cinema.ToDto();
    }

    public async Task UpdateAsync(Guid id, CinemaRequest request, CancellationToken cancellationToken)
    {
        var cinema = await repository.GetByIdAsync(id, cancellationToken);
        
        //TODO: call update method from entity class
        await repository.UpdateAsync(request.ToEntity(), cancellationToken);
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var cinema = await repository.GetByIdAsync(id, cancellationToken);
        await repository.DeleteAsync(cinema, cancellationToken);
    }
}