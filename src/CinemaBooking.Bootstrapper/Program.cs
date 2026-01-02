using CinemaBooking.Common.Infrastructure;
using CinemaBooking.Common.Infrastructure.Logging;
using CinemaBooking.Common.Infrastructure.Modules;

var builder = WebApplication.CreateBuilder(args);

var assemblies = ModuleLoader.LoadAssemblies();

builder.Host.UseLogging();

builder.Services.AddOpenApi();
builder.Services.AddInfrastructure(builder.Configuration, assemblies);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
app.UseInfrastructure();

app.UseHttpsRedirection();

app.Run();