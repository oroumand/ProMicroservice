using Microsoft.EntityFrameworkCore;
using Serilog;
using Zamin.Extensions.DependencyInjection;
using Zamin.Infra.Data.Sql.Commands.Interceptors;
using NewCms.Infra.Data.Sql.Commands.Common;
using NewCms.Infra.Data.Sql.Queries.Common;
using Steeltoe.Discovery.Client;
using BasicInfo.Endpoints.API.BackgroundTasks;

namespace NewCms.Endpoints.API;

public static class HostingExtensions
{
    public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
    {
        string cnn = "Server=.; Initial Catalog=NewsDb; User Id=sa; Password=1qaz!QAZ";
        builder.Services.AddDiscoveryClient();
        builder.Services.AddZaminParrotTranslator(c =>
        {
            c.ConnectionString = cnn;
            c.AutoCreateSqlTable = true;
            c.SchemaName = "dbo";
            c.TableName = "ParrotTranslations";
            c.ReloadDataIntervalInMinuts = 1;
        });

        builder.Services.AddZaminWebUserInfoService(c=>
        {
            c.DefaultUserId = "1";
        },true);

        builder.Services.AddZaminAutoMapperProfiles(option =>
        {
            option.AssmblyNamesForLoadProfiles = "Miniblog";
        });

        builder.Services.AddZaminMicrosoftSerializer();

        builder.Services.AddZaminInMemoryCaching();

        builder.Services.AddDbContext<NewCmsCommandDbContext>(c => c.UseSqlServer(cnn).AddInterceptors(new SetPersianYeKeInterceptor(), new AddOutBoxEventItemInterceptor(), new AddAuditDataInterceptor()));
        
        builder.Services.AddDbContext<NewCmsQueryDbContext>(c => c.UseSqlServer(cnn));

        builder.Services.AddZaminApiCore("Zamin", "MiniBlog");

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddHostedService<KeywordCreatedReceiver>();
        builder.Services.AddSwaggerGen();
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

        app.MapControllers();


        return app;
    }
}
