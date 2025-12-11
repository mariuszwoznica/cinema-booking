namespace CinemaBooking.Modules.Cinemas.Core.Entities;

internal class Screen
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public IEnumerable<Seat> Seats { get; private set; }

    internal Screen(string name, IEnumerable<Seat> seats)
    {
        Id = Guid.NewGuid();
        Name = name;
        Seats = seats;
    }
}