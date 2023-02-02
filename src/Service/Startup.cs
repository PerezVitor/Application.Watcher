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
        GetAppOptions(serviceOptions);

        services.AddHostedService<WatcherService>();

        services.AddInfraStructure();

        services.AddDbContextWithOptions();

        services.AddAutoMapper(typeof(MapModels));

        services.AddMediatR(typeof(Startup));

        return services;
    }

    public static IApplicationBuilder AddWatcher(this IApplicationBuilder app)
    {
        app.UseMiddleware<AppMiddleware>();
        return app;
    }

    private static void GetAppOptions(Action<AppOptions> serviceOptions)
    {
        var options = new AppOptions();
        serviceOptions(options);

        AppOptionsStatic.ListLogsLength = options.ListLogsLength;
        AppOptionsStatic.ListLogInsertLength = options.ListLogInsertLength;
        AppOptionsStatic.ApplicationName = options.ApplicationName;
        AppOptionsStatic.ConnectionString = options.ConnectionString;
        AppOptionsStatic.BackgroundServiceTimer = options.BackgroundServiceTimer;
    }
}