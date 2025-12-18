using CinemaBooking.Common.Abstractions.Exceptions;

namespace CinemaBooking.Modules.Cinemas.Core.Exceptions;

internal class CinemaAlreadyExistsException  : CinemaBookingException
{
    public string Name { get; }

    public CinemaAlreadyExistsException(string name)
        : base($"Cinema with name: '{name}' already exists.")
    {
        Name = name;
    }
}