using CQRSSamples.ApplicationService.Categories;
using CQRSSamples.ApplicationService.Categories.Commands.CreateCategories;
using CQRSSamples.ApplicationService.Categories.Commands.UpdateCategories;
using CQRSSamples.ApplicationService.Products;
using CQRSSamples.ApplicationService.Products.Commands.AddDiscounts;
using CQRSSamples.ApplicationService.Products.Commands.CreateProducts;
using CQRSSamples.Command.DAL;
using CQRSSamples.Command.DAL.Categories;
using CQRSSamples.Command.DAL.Common;
using CQRSSamples.Command.DAL.Products;
using CQRSSamples.Domain.Categories;
using CQRSSamples.Domain.Common;
using CQRSSamples.Domain.Products;
using CQRSSamples.Queries.DAL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<RepSampleCommandDbContext>
    (c => c.UseSqlServer("Server=.; Initial Catalog=Repo;User Id=sa;Password=1qaz!QAZ"));

builder.Services.AddDbContext<RepSampleQueryDbContext>(c => c.UseSqlServer("Server=.; Initial Catalog=Repo;User Id=sa;Password=1qaz!QAZ"));
builder.Services.AddScoped<IRepositorySampleDomainUnitOfWork, EFRepositorySampleDomainUnitOfWork>();
builder.Services.AddScoped<ICategoryRepository, EfCategoryRepository>();
builder.Services.AddScoped<IProductRepository, EfProductRepository>();
//builder.Services.AddScoped<CategoryServices>();
//builder.Services.AddScoped<ProductServices>();
builder.Services.AddScoped<CreateCategoryHandler>();
builder.Services.AddScoped<UpdateCategoryHandler>();
builder.Services.AddScoped<AddDiscountHandler>();
builder.Services.AddScoped<CreateProductHandler>();
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