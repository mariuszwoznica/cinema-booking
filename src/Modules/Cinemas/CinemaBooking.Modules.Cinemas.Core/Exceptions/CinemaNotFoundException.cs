using CinemaBooking.Common.Abstractions.Exceptions;

namespace CinemaBooking.Modules.Cinemas.Core.Exceptions;

public class CinemaNotFoundException : CinemaBookingException
{
    public Guid Id { get; }

    public CinemaNotFoundException(Guid id)
        : base($"Cinema with id: '{id}' was not found.")
    {
        Id = id;
    }
}