namespace CinemaBooking.Modules.Cinemas.Core.DTOs;

public record CinemaDto(
       Guid Id,
       string Name,
       AddressDto Address,
       IEnumerable<ScreenDto> Screens);