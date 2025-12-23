using CinemaBooking.Common.Infrastructure.Database;
using CinemaBooking.Modules.Cinemas.Core.Data;
using CinemaBooking.Modules.Cinemas.Core.Data.Repositories;
using CinemaBooking.Modules.Cinemas.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CinemaBooking.Modules.Cinemas.Core;

public static class CoreExtensions
{
    public static IServiceCollection AddCore(this IServiceCollection services)
    {
        services
            .AddPostgresDatabase<CinemasDbContext>()
            .AddScoped<ICinemaRepository, CinemaRepository>()
            .AddScoped<ICinemaService, CinemaService>();
        
        return services;
    }
}