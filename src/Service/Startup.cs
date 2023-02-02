using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Service.Application.Mappings;
using Service.Application.Middleware;
using Service.Application.Services;
using Service.Domain.Models;
using Service.Infra.IoC;

namespace Service;
public static class Startup
{
    public static IServiceCollection AddAppWatcherServices(this IServiceCollection services, Action<AppOptions> serviceOptions)
    {
        services.AddHostedService<WatcherService>();

        services.AddInfraStructure();

        services.AddDbContextWithOptions(serviceOptions);

        services.AddAutoMapper(typeof(MapModels));

        services.AddMediatR(typeof(Startup));

        return services;
    }

    public static IApplicationBuilder AddWatcher(this IApplicationBuilder app)
    {
        app.UseMiddleware<AppMiddleware>();
        return app;
    }
}