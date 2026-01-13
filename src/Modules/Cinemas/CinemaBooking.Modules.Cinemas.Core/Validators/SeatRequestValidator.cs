using CinemaBooking.Modules.Cinemas.Core.DTOs;
using FluentValidation;

namespace CinemaBooking.Modules.Cinemas.Core.Validators;

internal class SeatRequestValidator : AbstractValidator<SeatRequest>
{
    public SeatRequestValidator()
    {
        RuleFor(s => s.Row)
            .NotEmpty()
            .WithMessage("Row is required.");
        
        RuleFor(s => s.Number)
            .NotEmpty()
            .WithMessage("Number is required.");
        
        RuleFor(s => s.Type)
            .NotEmpty()
            .WithMessage("Type is required.");
        
        RuleFor(s => s.Type)
            .IsInEnum()
            .WithMessage("Seat type is not valid.");
    }
}