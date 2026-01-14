using CinemaBooking.Modules.Cinemas.Core.DTOs;
using FluentValidation;

namespace CinemaBooking.Modules.Cinemas.Core.Validators;

internal class ScreenCreateRequestValidator : AbstractValidator<ScreenCreateRequest>
{
    public  ScreenCreateRequestValidator()
    {
        RuleFor(s => s.Name)
            .NotEmpty()
            .WithMessage("Name is required.");
        
        RuleForEach(s => s.Seats)
            .NotEmpty()
            .WithMessage("Seats are required.")
            .SetValidator(new SeatCreateRequestValidator());
    }
}