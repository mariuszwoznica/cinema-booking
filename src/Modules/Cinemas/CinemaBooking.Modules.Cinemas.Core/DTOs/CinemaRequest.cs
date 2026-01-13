namespace CinemaBooking.Modules.Cinemas.Core.DTOs;

public record CinemaRequest(
    string Name,
    AddressDto Address,
    IEnumerable<ScreenRequest>? Screens);