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
            c.AddPolicy("BasicInfoPolicy", p =>
            {
                p.RequireAuthenticatedUser();
                p.RequireClaim("scope", "basicinfo");
            });
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
        //builder.Services.AddHostedService<EventPublisher>();
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

        app.MapHealthChecks("/helth/live", new HealthCheckOptions
        {
            Predicate = _ => false
        });
        app.MapHealthChecks("/helth/ready");
        app.UseAuthentication();
        app.UseAuthorization();
        app.MapControllers().RequireAuthorization("BasicInfoPolicy");


        return app;
    }
}
