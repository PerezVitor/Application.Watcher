using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Service.Domain;
using Service.Infra.Data.Context;

namespace Service.Infra.IoC;
internal static class DependencyInjectionDbContext
{
    public static IServiceCollection AddDbContextWithOptions(this IServiceCollection services, Action<AppOptions> serviceOptions)
    {
        var options = new AppOptions();
        serviceOptions(options);

        services.AddDbContext<ApplicationDbContext>(opt => opt.UseSqlServer(options.ConnectionString));

        AppOptionsStatic.ApplicationName = options.ApplicationName;

        return services;
    }
}
