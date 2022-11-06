using Serilog;
using NewCms.Endpoints.API;
using Serilog.Sinks.MSSqlServer;
using Serilog.Sinks.Elasticsearch;
using BasicInfo.Endpoints.API.Framework;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateBootstrapLogger();
Log.Information("Starting up");

try
{
    var builder = WebApplication.CreateBuilder(args);

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
        IndexFormat = "nikamoozcms-newscms-index-{0:yyyy.MM}",
        MinimumLogEventLevel = Serilog.Events.LogEventLevel.Debug,
    })
    .Enrich.With<ActivityEnricher>()
       .Enrich.FromLogContext()
    .ReadFrom.Configuration(ctx.Configuration));

    var app = builder.ConfigureServices().ConfigurePipeline();

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
