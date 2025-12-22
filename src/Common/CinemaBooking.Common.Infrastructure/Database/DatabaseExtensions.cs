using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace CinemaBooking.Common.Infrastructure.Database;

public static class DatabaseExtensions
{
    public static IServiceCollection AddPostgresDatabase<TDbContext>(this IServiceCollection services)
        where TDbContext : DbContext
    {
        services.AddDbContext<TDbContext>((serviceProvider, options) =>
        {
            var databaseSettings = serviceProvider
                .GetRequiredService<IOptions<DatabaseSettings>>()
                .Value;

            options.UseNpgsql(databaseSettings.ConnectionString);
        });

        return services;
    }

    public static IServiceCollection AddPostgresDatabase(this IServiceCollection services,
        IConfiguration configuration)
    {
        services
            .Configure<DatabaseSettings>(configuration.GetSection(nameof(DatabaseSettings)));

        return services;
    }
}