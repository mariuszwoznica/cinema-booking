namespace CinemaBooking.Modules.Cinemas.Core.DTOs;

public record CinemaCreateRequest(
    string Name,
    AddressDto Address,
    IEnumerable<ScreenCreateRequest>? Screens);