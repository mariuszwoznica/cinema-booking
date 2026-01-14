using CinemaBooking.Modules.Cinemas.Core.DTOs;
using FluentValidation;

namespace CinemaBooking.Modules.Cinemas.Core.Validators;

internal class CinemaUpdateRequestValidator : AbstractValidator<CinemaUpdateRequest>
{
    public CinemaUpdateRequestValidator()
    {
        RuleFor(c => c.Name)
            .NotEmpty()
            .WithMessage("Name is required.");

        RuleFor(c => c.Name)
            .MaximumLength(60)
            .WithMessage("Name cannot be longer than 60 characters.");

        RuleFor(c => c.Address)
            .NotEmpty()
            .WithMessage("Address is required.");
        
        RuleFor(c => c.Address)
            .NotEmpty()
            .SetValidator(new AddressDtoValidator());
    }
}