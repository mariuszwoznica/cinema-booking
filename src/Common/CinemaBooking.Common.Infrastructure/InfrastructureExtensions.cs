using System.Reflection;
using CinemaBooking.Common.Infrastructure.Commands;
using CinemaBooking.Common.Infrastructure.Database;
using CinemaBooking.Common.Infrastructure.Exceptions;
using CinemaBooking.Common.Infrastructure.Logging;
using CinemaBooking.Common.Infrastructure.Queries;
using CinemaBooking.Common.Infrastructure.Validation;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CinemaBooking.Common.Infrastructure;

public static class InfrastructureExtensions
{
    public static IServiceCollection AddCommonInfrastructure(this IServiceCollection services,
        IConfiguration configuration, IList<Assembly> assemblies)
    {
        services
            .AddExceptionHandling()
            .AddFluentValidation(assemblies)
            .AddCommands(assemblies)
            .AddQueries(assemblies)
            .AddLoggingDecorators()
            .AddPostgres(configuration);

        return services;
    }

    public static IApplicationBuilder UseCommonInfrastructure(this IApplicationBuilder app)
    {
        app.UseExceptionHandling();
        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/openapi/v1.json", "CinemaBooking API");
        });

        return app;
    }
}