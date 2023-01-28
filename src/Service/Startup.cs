using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Service.Application.Log;
using Service.Application.Mappings;
using Service.Application.Middleware;
using Service.Infra.IoC;

namespace Service;
public static class Startup
{
    public static IServiceCollection AddAppWatcherServices(this IServiceCollection services)
    {
        services.AddHostedService<LogBackgroundService>();
        services.AddInfraStructure();

        services.AddAutoMapper(typeof(MapModels));

        return services;
    }

    public static IApplicationBuilder AddWatcher(this IApplicationBuilder app)
    {
        app.UseMiddleware<AppMiddleware>();
        return app;
    }
}