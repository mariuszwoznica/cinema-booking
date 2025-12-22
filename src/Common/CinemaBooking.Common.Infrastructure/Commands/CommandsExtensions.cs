using CinemaBooking.Common.Abstractions.Commands;
using Microsoft.Extensions.DependencyInjection;

namespace CinemaBooking.Common.Infrastructure.Commands;

internal static class CommandsExtensions
{
    public static IServiceCollection AddCommands(this IServiceCollection services)
    {
        services.Scan(s => s.FromAssemblies(AppDomain.CurrentDomain.GetAssemblies())
            .AddClasses(c => c.AssignableTo(typeof(ICommandHandler<>)))
            .AsImplementedInterfaces()
            .WithScopedLifetime());

        return services;
    }
}