using Earth.Utilities;
using Zamin.Extensions.Logger.Abstractions;

namespace Earth.Endpoints.WebApi.Extentions.DependencyInjection;

public static class AddZaminServicesExtentions
{
    public static IServiceCollection AddZaminUntilityServices(
        this IServiceCollection services)
    {

        services.AddScoped<IScopeInformation, ScopeInformation>();
        services.AddTransient<ZaminServices>();
        return services;
    }

}

