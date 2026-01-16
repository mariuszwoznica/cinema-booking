using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace CinemaBooking.Common.Infrastructure.Validation.Filters;

internal class RequestValidationFilter<TRequest>(
    IValidator<TRequest> validator,
    ILogger<RequestValidationFilter<TRequest>> logger) : IEndpointFilter
    where TRequest : class
{
    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        var requestName = typeof(TRequest).Name;

        var request = context.Arguments
            .OfType<TRequest>()
            .FirstOrDefault(a => a.GetType() == typeof(TRequest));

        if (request is not null)
        {
            var validationResult = await validator.ValidateAsync(request, context.HttpContext.RequestAborted);

            if (!validationResult.IsValid)
            {
                logger.LogWarning("Validation failed for request {Request}", requestName);
                return TypedResults.ValidationProblem(validationResult.ToDictionary());
            }
        }

        return await next(context);
    }
}