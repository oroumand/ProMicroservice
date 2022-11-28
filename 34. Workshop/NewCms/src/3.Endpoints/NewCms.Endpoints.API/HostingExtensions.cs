using Microsoft.EntityFrameworkCore;
using Serilog;
using Zamin.Extensions.DependencyInjection;
using Zamin.Infra.Data.Sql.Commands.Interceptors;
using NewCms.Infra.Data.Sql.Commands.Common;
using NewCms.Infra.Data.Sql.Queries.Common;
using Steeltoe.Discovery.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using NewCms.Endpoints.API.BackgroundTasks;
using Zamin.Utilities.OpenTelemetryRegistration.Extensions.DependencyInjection;

namespace NewCms.Endpoints.API;

public static class HostingExtensions
{
    public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
    {
        string cnn = "Server=.; Initial Catalog=NewsDb; User Id=sa; Password=1qaz!QAZ";
        string cnnQuery = "Server=.; Initial Catalog=NewsDb; User Id=sa; Password=1qaz!QAZ";
        builder.Services.AddDiscoveryClient();
        builder.Services.AddZaminParrotTranslator(c =>
        {
            c.ConnectionString = cnn;
            c.AutoCreateSqlTable = true;
            c.SchemaName = "dbo";
            c.TableName = "ParrotTranslations";
            c.ReloadDataIntervalInMinuts = 1;
        });

        builder.Services.AddAuthentication("Bearer").AddJwtBearer("Bearer", c =>
        {
            c.Authority = "https://localhost:5001/";
            c.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
            {
                ValidateAudience = false,
            };
        });


        builder.Services.AddAuthorization(c =>
        {
            c.AddPolicy("NewsCmsPolicy", p =>
            {
                //p.RequireAuthenticatedUser();
                p.RequireClaim("scope", "newscms");
            });
        });
        builder.Services.AddZaminWebUserInfoService(c =>
        {
            c.DefaultUserId = "1";
        }, true);

        builder.Services.AddZaminAutoMapperProfiles(option =>
        {
            option.AssmblyNamesForLoadProfiles = "NewCms";
        });

        builder.Services.AddZaminMicrosoftSerializer();

        builder.Services.AddZaminInMemoryCaching();

        builder.Services.AddDbContext<NewCmsCommandDbContext>(c => c.UseSqlServer(cnn).AddInterceptors(new SetPersianYeKeInterceptor(), new AddOutBoxEventItemInterceptor(), new AddAuditDataInterceptor()));

        builder.Services.AddDbContext<NewCmsQueryDbContext>(c => c.UseSqlServer(cnnQuery));

        builder.Services.AddZaminApiCore("Zamin", "NewCms");

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddHostedService<KeywordCreatedReceiver>();
        builder.Services.AddSwaggerGen();
        builder.Services.AddHealthChecks()
                        .AddDbContextCheck<NewCmsQueryDbContext>(); ;

        builder.Services.AddZaminTraceJeager(c =>
        {
            c.AgentHost = "localhost";
            c.ApplicationName = "NewsCMS";
            c.ServiceName = "NewsCMS";
            c.ServiceVersion = "1.0.0";
            c.ServiceId = "cb387bb6-9a66-444f-92b2-ff64e2a82f99";
        });
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

 
        app.MapHealthChecks("/helth/live", new HealthCheckOptions
        {
            Predicate = _ => false
        });
        app.MapHealthChecks("/helth/ready");
        app.UseAuthentication();
        app.UseAuthorization();
        app.MapControllers().RequireAuthorization("NewsCmsPolicy");

        return app;
    }
}
