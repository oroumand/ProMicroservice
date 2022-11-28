using BasicInfo.Endpoints.API;
using NewCms.Endpoints.API;
using OpenTelemetry.Trace;
using Zamin.Extensions.DependencyInjection;

Zamin.Utilities.SerilogRegistration.Extensions.SerilogExtensions.RunWithSerilogExceptionHandling(() =>
{
    var builder = WebApplication.CreateBuilder(args);
    var app = builder.AddZaminSerilog(c =>
    {
        c.ApplicationName = "NewsCMS";
        c.ServiceName = "NewsCMS";
        c.ServiceVersion = "1.0";
        c.ServiceId = Guid.NewGuid().ToString();
    }).ConfigureServices().ConfigurePipeline();
    app.Run();

});