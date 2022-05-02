using DomainEventsSamples.Core.ApplicationServices;
using DomainEventsSamples.Core.ApplicationServices.People.EventHandlers;
using DomainEventsSamples.Core.Domain.People.Events;
using DomainEventsSamples.Framework;
using DomainEventsSamples.Infra.Dal;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<SampleContext>(c => c.UseSqlServer("Server=.; Initial Catalog=PersonDb; User Id=sa;Password=1qaz!QAZ"));
builder.Services.AddTransient<PersonService>();
builder.Services.AddTransient<IDomainEventDispatcher, DomainEventDispatcher>();
builder.Services.AddTransient<IDomainEventHandler<PersonCreated>, WitePersonCreatedToConsole>();
builder.Services.AddTransient<IDomainEventHandler<PersonCreated>, WitePersonCreatedToFile>();
builder.Services.AddTransient<IDomainEventHandler<FirstNameChanged>, WiteFirstNameChangedToConsole>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
