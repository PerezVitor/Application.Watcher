using Meempregarh.Infra.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Service.Domain.Models;
using Service.Infra.Data.Context;
using Service.Infra.Data.Interfaces;
using Service.Infra.Data.Repositories;

namespace Service.Infra.IoC;
internal static class DependencyInjectionDbContext
{
    public static IServiceCollection AddDbContextWithOptions(this IServiceCollection services, Action<AppOptions> serviceOptions)
    {
        var options = new AppOptions();
        serviceOptions(options);

        AppOptionsStatic.ApplicationName = options.ApplicationName;
        AppOptionsStatic.ConnectionString = options.ConnectionString;

        services.AddTransient<ApplicationDbContext>();

        services.AddTransient<IExceptionRepository, ExceptionRepository>();
        services.AddTransient<IResponseRepository, ResponseRepository>();
        services.AddTransient<ILoggerRepository, LoggerRepository>();
        services.AddTransient<IRequestRepository, RequestRepository>();

        return services;
    }
}
