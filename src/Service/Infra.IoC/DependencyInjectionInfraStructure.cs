using Microsoft.Extensions.DependencyInjection;
using Service.Application.Log;
using Service.Application.Log.Inteface;
using Service.Application.Middleware;
using Service.Application.Middleware.Interface;

namespace Service.Infra.IoC;
internal static class DependencyInjectionInfraStructure
{
    public static IServiceCollection AddInfraStructure(this IServiceCollection services)
    {
        services.AddTransient<IResponse, AppMiddlewareResponse>();
        services.AddTransient<IRequest, AppMiddlewareRequest>();
        services.AddTransient<IException, AppMiddlewareException>();
        services.AddTransient<ILoggerService, LoggerService>();
        services.AddTransient<ILog, AppMiddlewareLogger>();

        return services;
    }
}
