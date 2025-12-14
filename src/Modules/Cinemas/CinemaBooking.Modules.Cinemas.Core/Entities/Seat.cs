using CinemaBooking.Common.Abstractions.Entities;

namespace CinemaBooking.Modules.Cinemas.Core.Entities;

internal class Seat : Entity
{
    public string Row { get; private set; }
    public int Number { get; private set; }
    public SeatType Type { get; private set; }

    internal Seat(string row, int number, SeatType type)
    {
        Id = Guid.NewGuid();
        Row = row;
        Number = number;
        Type = type;
    }
}

internal enum SeatType
{
    Vip = 1,
    Standard = 2,
    Saver = 3
}