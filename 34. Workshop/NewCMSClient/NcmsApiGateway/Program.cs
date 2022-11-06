using NcmsApiGateway.Extentsions;
using Steeltoe.Discovery.Client;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDiscoveryClient();
builder.Services.AddReverseProxy()
    .LoadFromEureka(builder.Services);
builder.Services.AddHealthChecks();
//.LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));
var app = builder.Build();

app.MapReverseProxy();
app.UseRouting();

app.UseEndpoints(c =>
{
    c.MapHealthChecks("/health/live");
});

app.Run();