using Yarp.ReverseProxy.Configuration;

namespace NcmsApiGateway.Extentsions;

public static class DependencyInjectionExtentions
{
    public static IReverseProxyBuilder LoadFromEureka(this IReverseProxyBuilder builder, IServiceCollection sc)
    {
        builder.Services.AddSingleton<EurekaProxyConfigProvider>();

        builder.Services.AddSingleton<IHostedService>(ctx => ctx.GetRequiredService<EurekaProxyConfigProvider>());

        builder.Services.AddSingleton<IProxyConfigProvider>(ctx => ctx.GetRequiredService<EurekaProxyConfigProvider>());

        return builder;
    }
}
