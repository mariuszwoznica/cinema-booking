using CinemaBooking.Modules.Cinemas.Core.DTOs;
using FluentValidation;

namespace CinemaBooking.Modules.Cinemas.Core.Validators;

internal class AddressDtoValidator : AbstractValidator<AddressDto>
{
    public AddressDtoValidator()
    {
        RuleFor(a => a.Street)
            .NotEmpty()
            .WithMessage("Street is required.");
        
        RuleFor(a => a.City)
            .NotEmpty()
            .WithMessage("City is required.");
            
        RuleFor(a => a.ZipCode)
            .NotEmpty()
            .WithMessage("ZipCode is required.");
    }
}