using Meempregarh.Infra.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Service.Infra.Data.Context;
using Service.Infra.Data.Interfaces;
using Service.Infra.Data.Repositories;

namespace Service.Infra.IoC;
internal static class DependencyInjectionDbContext
{
    public static IServiceCollection AddDbContextWithOptions(this IServiceCollection services)
    {
        services.AddTransient<ApplicationDbContext>();

        services.AddTransient<IExceptionRepository, ExceptionRepository>();
        services.AddTransient<IResponseRepository, ResponseRepository>();
        services.AddTransient<ILoggerRepository, LoggerRepository>();
        services.AddTransient<IRequestRepository, RequestRepository>();

        return services;
    }
}
