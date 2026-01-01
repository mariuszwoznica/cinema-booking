using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace CinemaBooking.Common.Infrastructure.Validation.Filters;

internal class ValidationFilter<TRequest>(IValidator<TRequest> validator) : IEndpointFilter 
    where TRequest : class
{
    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        var request = context.Arguments.OfType<TRequest>().First();
        var validationResult = await validator.ValidateAsync(request, context.HttpContext.RequestAborted);

        if (!validationResult.IsValid)
        {
            return TypedResults.ValidationProblem(validationResult.ToDictionary());
        }
        
        return await next(context);
    }
}