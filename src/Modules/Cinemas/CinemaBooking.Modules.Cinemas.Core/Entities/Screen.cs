using CinemaBooking.Common.Abstractions.Entities;

namespace CinemaBooking.Modules.Cinemas.Core.Entities;

internal class Screen : Entity
{
    public string Name { get; private set; }
    public List<Seat> Seats { get; private set; }

    //Only for Ef purpose
    public Screen()
    {
    }

    internal Screen(string name, IEnumerable<Seat> seats)
    {
        Id = Guid.NewGuid();
        Name = name;
        Seats = seats.ToList();
    }
    
    internal void Update(string name, IEnumerable<Seat> seats)
    {
        Name = name;
        Seats = seats.ToList();
    }
}