using BasicInfo.Endpoints.API.Framework;
using NcmsApiGateway.Extentsions;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using Serilog;
using Serilog.Sinks.Elasticsearch;
using Serilog.Sinks.MSSqlServer;
using Steeltoe.Discovery.Client;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateBootstrapLogger();
Log.Information("Starting up");

try
{
    var builder = WebApplication.CreateBuilder(args);
    var serviceName = "news.cms.api.gateway";
    var serviceVersion = "1.0.0";
    // Configure important OpenTelemetry settings, the console exporter, and instrumentation library
    builder.Services.AddOpenTelemetryTracing(tracerProviderBuilder =>
    {
        tracerProviderBuilder
        .AddConsoleExporter().AddJaegerExporter()
        .AddSource(serviceName)
        .SetResourceBuilder(
            ResourceBuilder.CreateDefault()
                .AddService(serviceName: serviceName, serviceVersion: serviceVersion))
        .AddHttpClientInstrumentation()
        .AddAspNetCoreInstrumentation()
        .AddSqlClientInstrumentation();
    });
    builder.Host.UseSerilog((ctx, lc) => lc
 .WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level}] {SourceContext}{NewLine}{Message:lj}{NewLine}{Exception}{NewLine}")
  .WriteTo.File("log.txt", rollingInterval: RollingInterval.Day)
    .WriteTo.MSSqlServer(
        connectionString: "Server=.;Database=LogDb;User Id=sa; Password=1qaz!QAZ;",
        sinkOptions: new MSSqlServerSinkOptions { TableName = "LogEvents", AutoCreateSqlTable = true })
        .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri("http://localhost:9200"))
        {
            AutoRegisterTemplate = true,
            AutoRegisterTemplateVersion = AutoRegisterTemplateVersion.ESv6,
            IndexFormat = "nikamoozcms-apigateway-index-{0:yyyy.MM}",
            MinimumLogEventLevel = Serilog.Events.LogEventLevel.Debug,
        })
        .Enrich.With<ActivityEnricher>()
    .Enrich.FromLogContext()
 .ReadFrom.Configuration(ctx.Configuration));
    builder.Services.AddDiscoveryClient();
    builder.Services.AddReverseProxy()
        .LoadFromEureka(builder.Services);
    builder.Services.AddHealthChecks();
    //.LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));
    var app = builder.Build();
    app.UseSerilogRequestLogging();
    app.MapReverseProxy();
    app.UseRouting();

    app.UseEndpoints(c =>
    {
        c.MapHealthChecks("/health/live");
    });

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Unhandled exception");
}
finally
{
    Log.Information("Shut down complete");
    Log.CloseAndFlush();
}