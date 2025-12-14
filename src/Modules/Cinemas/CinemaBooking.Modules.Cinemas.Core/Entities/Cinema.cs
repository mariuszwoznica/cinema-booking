using CinemaBooking.Common.Abstractions.Entities;

namespace CinemaBooking.Modules.Cinemas.Core.Entities;

internal class Cinema : Entity
{
    public string Name { get; private set; }
    public Address Address { get; private set; }
    public IEnumerable<Screen> Screens { get; private set; }

    internal Cinema(string name, Address address, IEnumerable<Screen> screens)
    {
        Id = Guid.NewGuid();
        Name = name;
        Address = address;
        Screens = screens;
    }
}