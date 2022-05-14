using RepositorySamples.DAL;
using Microsoft.EntityFrameworkCore;
using RepositorySamples.Domain.Common;
using RepositorySamples.DAL.Common;
using RepositorySamples.Domain.Categories;
using RepositorySamples.DAL.Categories;
using RepositorySamples.DAL.Products;
using RepositorySamples.Domain.Products;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<RepSampleDbContext>
    (c => c.UseSqlServer("Server=.; Initial Catalog=Repo;User Id=sa;Password=1qaz!QAZ"));
builder.Services.AddScoped<IRepositorySampleDomainUnitOfWork, EFRepositorySampleDomainUnitOfWork>();
builder.Services.AddScoped<ICategoryRepository, EfCategoryRepository>();
builder.Services.AddScoped<IProductRepository, EfProductRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
