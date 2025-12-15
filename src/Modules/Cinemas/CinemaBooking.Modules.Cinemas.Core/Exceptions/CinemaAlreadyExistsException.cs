using CinemaBooking.Common.Abstractions.Exceptions;

namespace CinemaBooking.Modules.Cinemas.Core.Exceptions;

internal class CinemaAlreadyExistsException  : CinemaBookingException
{
    public Guid Id { get; }

    public CinemaAlreadyExistsException(Guid id)
        : base($"Cinema with id: '{id}' already exists.")
    {
        Id = id;
    }
}