using BasicInfo.Infra.Data.Sql.Commands.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Collections.Concurrent;

namespace BasicInfo.Endpoints.API.BackgroundTasks;

public class EventPublisher : BackgroundService
{
    private readonly IConnection _connection;
    private readonly IModel _model;
    private readonly string requestRoutKeyPattern = "NikamoozNewsExchange.BasicInfo.Event.{0}";
    private readonly string _exchangeName = "NikamoozNewsExchange";
    private readonly BasicInfoCommandDbContext _dbContext;

    public EventPublisher(IServiceProvider serviceProvider)
    {
        var factory = new ConnectionFactory
        {
            HostName = "localhost",
        };
        _connection = factory.CreateConnection();
        _model = _connection.CreateModel();
        _model.ExchangeDeclare(_exchangeName, ExchangeType.Topic, false, false, null);
        var scop = serviceProvider.CreateScope();       
        _dbContext = scop.ServiceProvider.GetRequiredService<BasicInfoCommandDbContext>();
    }
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            var events = await _dbContext.OutBoxEventItems.Where(c => c.IsProcessed == false).Take(100).ToListAsync();
            if (events.Any())
            {
                foreach (var @event in events)
                {
                    var finalRoutKey = string.Format(requestRoutKeyPattern, @event.EventName);
                    var messageBody = System.Text.Encoding.UTF8.GetBytes(@event.EventPayload);
                    _model.BasicPublish(_exchangeName, finalRoutKey, null, messageBody);
                    @event.IsProcessed = true;
                }
                _dbContext.SaveChanges();
            }

            await Task.Delay(2000, stoppingToken);
        }

    }
}
