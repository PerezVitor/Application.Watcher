using Microsoft.Extensions.DependencyInjection;
using Service.Application.Log;
using Service.Application.Log.Inteface;
using Service.Application.Middleware;
using Service.Application.Middleware.Interface;
using Service.Domain.Entities;

namespace Service.Infra.IoC;
internal static class DependencyInjection
{
    public static IServiceCollection AddInfraStructure(this IServiceCollection services)
    {
        services.AddTransient<IResponse, AppMiddlewareResponse>();
        services.AddTransient<IRequest, AppMiddlewareRequest>();
        services.AddTransient<IException, AppMiddlewareException>();
        services.AddTransient<ILoggerService, LoggerService>();
        services.AddTransient<ILog, AppMiddlewareLogger>();

        services.AddTransient<ExceptionModel>();
        services.AddTransient<RequestModel>();
        services.AddTransient<ResponseModel>();
        services.AddTransient<LoggerModel>();

        return services;
    }
}
