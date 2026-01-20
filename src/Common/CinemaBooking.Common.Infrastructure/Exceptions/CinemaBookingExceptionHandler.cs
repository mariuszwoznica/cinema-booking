using CinemaBooking.Common.Abstractions.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CinemaBooking.Common.Infrastructure.Exceptions;

internal sealed class CinemaBookingExceptionHandler(
    IProblemDetailsService problemDetailsService, 
    ILogger<GlobalExceptionHandler> logger) : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext, 
        Exception exception, 
        CancellationToken cancellationToken)
    {
        if (exception is not CinemaBookingException)
        {
            return false;
        }
        
        logger.LogError(exception, "Domain exception occurred.");
        
        return await problemDetailsService.TryWriteAsync(new ProblemDetailsContext
        {
            HttpContext = httpContext,
            Exception = exception,
            ProblemDetails = new ProblemDetails
            {
                Status = StatusCodes.Status400BadRequest,
                Type = exception.GetType().Name,
                Title = "Domain exception occurred",
                Detail = exception.Message,
            }
        });
    }
}