using CinemaBooking.Modules.Cinemas.Core.DTOs;
using CinemaBooking.Modules.Cinemas.Core.Entities;
using CinemaBooking.Modules.Cinemas.Core.Exceptions;
using SeatType = CinemaBooking.Modules.Cinemas.Core.Entities.SeatType;
using SeatTypeDto = CinemaBooking.Modules.Cinemas.Core.DTOs.SeatType;

namespace CinemaBooking.Modules.Cinemas.Core;

internal static class MappingExtensions
{
    internal static CinemaDto ToDto(this Cinema cinema)
        => new(
            Id: cinema.Id,
            Name: cinema.Name,
            Address: new AddressDto(
                Street: cinema.Address.Street,
                City: cinema.Address.City,
                ZipCode: cinema.Address.ZipCode),
            Screens: cinema.Screens.Select(screen => new ScreenDto(
                Id: screen.Id,
                Name: screen.Name,
                Seats: screen.Seats.Select(seat => new SeatDto(
                    Id: seat.Id,
                    Row: seat.Row,
                    Number: seat.Number,
                    Type: seat.Type.ToDto()))))
            );

    internal static Cinema ToEntity(this CinemaDto dto)
        => new(
            name: dto.Name,
            address: new Address(
                Street: dto.Address.Street,
                City: dto.Address.City,
                ZipCode: dto.Address.ZipCode),
            screens: dto.Screens.Select(screen => new Screen(
                name: screen.Name,
                seats: screen.Seats.Select(seat => new Seat(
                    row: seat.Row,
                    number: seat.Number,
                    type: seat.Type.ToEntity()))))
        );

    private static SeatTypeDto ToDto(this SeatType type)
        => type switch
        {
            SeatType.Saver => SeatTypeDto.Saver,
            SeatType.Standard => SeatTypeDto.Standard,
            SeatType.Vip => SeatTypeDto.Vip,
            _ => throw new SeatTypeNotSupportedException(type.ToString())
        };

    private static SeatType ToEntity(this SeatTypeDto type)
        => type switch
        {
            SeatTypeDto.Saver => SeatType.Saver,
            SeatTypeDto.Standard => SeatType.Standard,
            SeatTypeDto.Vip => SeatType.Vip,
            _ => throw new SeatTypeNotSupportedException(type.ToString())
        };
}