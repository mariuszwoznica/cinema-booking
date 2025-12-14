using CinemaBooking.Common.Abstractions.Entities;

namespace CinemaBooking.Modules.Cinemas.Core.Entities;

internal class Screen : Entity
{
    public string Name { get; private set; }
    public IEnumerable<Seat> Seats { get; private set; }

    internal Screen(string name, IEnumerable<Seat> seats)
    {
        Id = Guid.NewGuid();
        Name = name;
        Seats = seats;
    }
}