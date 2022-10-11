using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Collections.Concurrent;
using System.Text.Json.Serialization;
using Zamin.Core.Domain.Events;

namespace BasicInfo.Endpoints.API.BackgroundTasks;

public class KeywordCreatedReceiver : BackgroundService
{
    private readonly IConnection _connection;
    private readonly IModel _model;
    private readonly string routingKey = "NikamoozNewsExchange.BasicInfo.Event.KeywordCreated";
    private readonly string _exchangeName = "NikamoozNewsExchange";
    private string _queueName;
    private int _messageCount;
    private EventingBasicConsumer _consumer;
    private readonly SqlConnection sqlConnection = new SqlConnection("Server=.; Initial Catalog=NewsDb; User Id=sa; Password=1qaz!QAZ");
    public KeywordCreatedReceiver()
    {
        var factory = new ConnectionFactory
        {
            HostName = "localhost",
        };
        _connection = factory.CreateConnection();
        _model = _connection.CreateModel();
        _model.ExchangeDeclare(_exchangeName, ExchangeType.Topic, false, false, null);
        _queueName = _model.QueueDeclare().QueueName;
        _model.QueueBind(_queueName, _exchangeName, routingKey, null);
        _consumer = new EventingBasicConsumer(_model);
        _consumer.Received += consumer_Received;
        _model.BasicConsume(_queueName, true, _consumer);
        Console.WriteLine("Start receiving keyword created event");
        sqlConnection.Open();
    }

    private void consumer_Received(object? sender, BasicDeliverEventArgs e)
    {
        var messageText = System.Text.Encoding.UTF8.GetString(e.Body.ToArray());
        var keywordEvent = JsonConvert.DeserializeObject<KeywordCreated>(messageText);
        string commandText = $"INSERT INTO [dbo].[Keyword]([KeywordBusinessId],[KeywordTitle]) VALUES ('{keywordEvent.BusinessId}',N'{keywordEvent.Title}')";
        SqlCommand command = new SqlCommand(commandText,sqlConnection);
        command.ExecuteNonQuery();
        _messageCount++;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            Console.WriteLine($"Message count is  {_messageCount} at {DateTime.Now.ToString()}");
            _messageCount=0;
            await Task.Delay(10000, stoppingToken);
        }

    }
}

public class KeywordCreated
{
    public Guid BusinessId { get; set; }
    public string Title { get; set; }
}
