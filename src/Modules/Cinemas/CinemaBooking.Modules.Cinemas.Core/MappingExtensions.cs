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

    internal static Address ToEntity(this AddressDto address)
        => new(
            Street: address.Street,
            City: address.City,
            ZipCode: address.ZipCode
        );

    internal static Cinema ToEntity(this CinemaCreateRequest request)
        => new(
            name: request.Name,
            address: request.Address.ToEntity(),
            screens: request.Screens.Select(screen => new Screen(
                name: screen.Name,
                seats: screen.Seats.Select(seat => new Seat(
                    row: seat.Row,
                    number: seat.Number,
                    type: seat.Type.ToEntity()))))
        );

    internal static Screen ToEntity(this ScreenUpdateRequest request, IEnumerable<Screen> entities)
    {
        var screen = entities.FirstOrDefault(screen => screen.Id == request.Id);
        if (screen is null)
        {
            return new Screen(request.Name, request.Seats.Select(seat => new Seat(
                row: seat.Row,
                number: seat.Number,
                type: seat.Type.ToEntity())));
        }

        screen.Update(request.Name, request.Seats.Select(seat => seat.ToEntity(screen.Seats)));
        return screen;
    }

    private static Seat ToEntity(this SeatUpdateRequest request, IEnumerable<Seat> entities)
    {
        var seat = entities.FirstOrDefault(seat => seat.Id == request.Id);
        if (seat is null)
        {
            return new Seat(request.Row, request.Number, request.Type.ToEntity());
        }

        seat.Update(request.Row, request.Number, request.Type.ToEntity());
        return seat;
    }

    private static SeatTypeDto ToDto(this SeatType type)
        => type switch
        {
            SeatType.Saver => SeatTypeDto.Saver,
            SeatType.Standard => SeatTypeDto.Standard,
            SeatType.Vip => SeatTypeDto.Vip,
            _ => throw SeatTypeNotSupportedException.Create(type)
        };

    private static SeatType ToEntity(this SeatTypeDto type)
        => type switch
        {
            SeatTypeDto.Saver => SeatType.Saver,
            SeatTypeDto.Standard => SeatType.Standard,
            SeatTypeDto.Vip => SeatType.Vip,
            _ => throw SeatTypeNotSupportedException.Create(type)
        };
}