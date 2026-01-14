namespace CinemaBooking.Modules.Cinemas.Core.DTOs;

public record CinemaUpdateRequest(
    string Name,
    AddressDto Address,
    IEnumerable<ScreenUpdateRequest>? Screens);