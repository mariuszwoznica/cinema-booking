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

    public async Task CreateAsync(CinemaDto dto, CancellationToken cancellationToken)
    {
        var cinemaExists = await repository.ExistsAsync(dto.Name, cancellationToken);
        if (cinemaExists)
        {
            throw new CinemaAlreadyExistsException(dto.Name);
        }

        var cinema = dto.ToEntity();
        await repository.CreateAsync(cinema, cancellationToken);
    }

    public async Task UpdateAsync(CinemaDto dto, CancellationToken cancellationToken)
    {
        var cinema = await repository.GetByIdAsync(dto.Id, cancellationToken);
        
        //TODO: call update method from entity class
        await repository.UpdateAsync(dto.ToEntity(), cancellationToken);
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var cinema = await repository.GetByIdAsync(id, cancellationToken);
        await repository.DeleteAsync(cinema, cancellationToken);
    }
}