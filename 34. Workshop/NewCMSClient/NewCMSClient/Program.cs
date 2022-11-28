
using Microsoft.Extensions.DependencyInjection;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using Serilog;
using Serilog.Sinks.Elasticsearch;
using Serilog.Sinks.MSSqlServer;
using System.IdentityModel.Tokens.Jwt;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateBootstrapLogger();
Log.Information("Starting up");

try
{
    var builder = WebApplication.CreateBuilder(args);

    var serviceName = "news.cms.client";
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
           IndexFormat = "nikamoozcms-webclient-index-{0:yyyy.MM}",
           MinimumLogEventLevel = Serilog.Events.LogEventLevel.Debug,
       })
    .Enrich.FromLogContext()
   .ReadFrom.Configuration(ctx.Configuration));

    JwtSecurityTokenHandler.DefaultMapInboundClaims = false;
    builder.Services.AddAuthentication(c =>
    {
        c.DefaultScheme = "Cookies";
        c.DefaultChallengeScheme = "oidc";
    }).AddCookie("Cookies")
    .AddOpenIdConnect("oidc", c =>
    {
        c.Authority = "https://localhost:5001";
        c.ClientId = "newscmsclient";
        c.ClientSecret = "newscmsclient";
        c.ResponseType = "code";
        c.Scope.Clear();
        c.Scope.Add("openid");
        c.Scope.Add("profile");
        c.Scope.Add("basicinfo");
        c.Scope.Add("newscms");
        c.Scope.Add("offline_access");
        c.GetClaimsFromUserInfoEndpoint = true;
        c.SaveTokens = true;
    })
     
        
        ;

    builder.Services.AddHttpClient("bi", c =>
    {
        c.BaseAddress = new Uri("http://localhost:7300/bi/");
    });
    builder.Services.AddHttpClient("news", c =>
    {
        c.BaseAddress = new Uri("http://localhost:7300/news/");
    });

    builder.Services.AddHttpClient("oAtuh", c =>
    {
        c.BaseAddress = new Uri("https://localhost:5001");
    });
    // Add services to the container.
    builder.Services.AddControllersWithViews();
    builder.Services.AddHealthChecks();
    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Home/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }
    app.UseSerilogRequestLogging();
    app.UseHttpsRedirection();
    app.UseStaticFiles();

    app.UseRouting();

    app.MapHealthChecks("/health/live");
    app.UseAuthentication();
    app.UseAuthorization();

    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}").RequireAuthorization();

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