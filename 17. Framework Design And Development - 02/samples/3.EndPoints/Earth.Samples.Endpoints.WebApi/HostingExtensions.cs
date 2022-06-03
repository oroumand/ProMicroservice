using Earth.Endpoints.WebApi.Extentions.DependencyInjection;
using Earth.Samples.Infra.Data.Sql.Commands.Common;
using Earth.Samples.Infra.Data.Sql.Queries.Common;
using Microsoft.EntityFrameworkCore;
using Zamin.Extensions.DependencyInjection;

namespace Earth.Samples.Endpoints.WebApi;

public static class HostingExtensions
{
    public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
    {
        string cnn = "Server=.; Initial Catalog=EarthSample; User Id=sa; Password=1qaz!QAZ";
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
            option.AssmblyNamesForLoadProfiles = "Earth.Samples";
        });

        builder.Services.AddZaminMicrosoftSerializer();

        builder.Services.AddZaminInMemoryCaching();

        builder.Services.AddDbContext<SampleCommandDbContext>(c => c.UseSqlServer(cnn));
        builder.Services.AddDbContext<SampleQueryDbContext>(c => c.UseSqlServer(cnn));
        builder.Services.AddZaminApiCore("Earth");
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        return builder.Build();
    }

    public static WebApplication ConfigurePipeline(this WebApplication app)
    {
        app.UseZaminApiExceptionHandler();
        //app.UseSerilogRequestLogging();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();


        return app;
    }
}
