using Microsoft.EntityFrameworkCore;
using Serilog;
using Zamin.Extensions.DependencyInjection;
using Zamin.Infra.Data.Sql.Commands.Interceptors;
using BasicInfo.Infra.Data.Sql.Commands.Common;
using BasicInfo.Infra.Data.Sql.Queries.Common;
using Steeltoe.Discovery.Client;
using BasicInfo.Endpoints.API.BackgroundTasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

namespace BasicInfo.Endpoints.API;

public static class HostingExtensions
{
    public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
    {
        string cnn = builder.Configuration.GetConnectionString("BasicInfoCommand_ConnectionString");
        string cnnQuery = builder.Configuration.GetConnectionString("BasicInfoQuery_ConnectionString");
        builder.Services.AddDiscoveryClient();
        builder.Services.AddZaminParrotTranslator(c =>
        {
            c.ConnectionString = cnn;
            c.AutoCreateSqlTable = true;
            c.SchemaName = "dbo";
            c.TableName = "ParrotTranslations";
            c.ReloadDataIntervalInMinuts = 1;
        });

        builder.Services.AddZaminWebUserInfoService(true);

        builder.Services.AddZaminAutoMapperProfiles(option =>
        {
            option.AssmblyNamesForLoadProfiles = "BasicInfo";
        });

        builder.Services.AddZaminNewtonSoftSerializer();

        builder.Services.AddZaminInMemoryCaching();

        builder.Services.AddDbContext<BasicInfoCommandDbContext>(c => c.UseSqlServer(cnn).AddInterceptors(new SetPersianYeKeInterceptor(), new AddOutBoxEventItemInterceptor(), new AddAuditDataInterceptor()));
        
        builder.Services.AddDbContext<BasicInfoQueryDbContext>(c => c.UseSqlServer(cnnQuery));

        builder.Services.AddZaminApiCore("Zamin", "BasicInfo");

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddHostedService<EventPublisher>();
        builder.Services.AddSwaggerGen();
        builder.Services.AddHealthChecks()
            .AddDbContextCheck<BasicInfoQueryDbContext>();
        return builder.Build();
    }
    public static WebApplication ConfigurePipeline(this WebApplication app)
    {
        app.UseZaminApiExceptionHandler();
        app.UseSerilogRequestLogging();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        //app.UseHttpsRedirection();

        app.UseAuthorization();
        app.MapHealthChecks("/helth/live", new HealthCheckOptions
        {
            Predicate = _=>false
        }) ;
        app.MapHealthChecks("/helth/ready");
        app.MapControllers();


        return app;
    }
}
