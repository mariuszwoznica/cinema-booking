namespace CinemaBooking.Modules.Cinemas.Core.DTOs;

public record AddressDto(
    string Street, 
    string City, 
    string ZipCode);