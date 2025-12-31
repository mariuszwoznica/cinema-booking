using CinemaBooking.Modules.Cinemas.Api.Endpoints;
using CinemaBooking.Modules.Cinemas.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace CinemaBooking.Modules.Cinemas.Api;

public static class CinemasModule
{
    public static IServiceCollection AddCinemasModule(this IServiceCollection services)
    {
        services
            .AddCore();

        return services;
    }
    
    public static void UseCinemasModule(this WebApplication app)
    {
        app.MapCinemasEndpoints();
    }
}