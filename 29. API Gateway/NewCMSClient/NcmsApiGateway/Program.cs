using NcmsApiGateway.Extentsions;
using Steeltoe.Discovery.Client;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDiscoveryClient();
builder.Services.AddReverseProxy()
    .LoadFromEureka(builder.Services);
//.LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));
var app = builder.Build();

app.MapReverseProxy();


app.Run();