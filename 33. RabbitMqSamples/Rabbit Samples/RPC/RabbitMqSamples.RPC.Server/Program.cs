using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System.Text;
using RabbitMqSamples.RPC.Server.Models;
using Newtonsoft.Json;

var connectionFactory = new ConnectionFactory()
{
    HostName = "localhost",
};
CustomerRepository _customerRepository = new CustomerRepository();
using var connection = connectionFactory.CreateConnection();
using var channel = connection.CreateModel();
string exchangeName = "RpcSampleExchange";
channel.ExchangeDeclare(exchangeName, ExchangeType.Topic, false, false, null);



var queueName = channel.QueueDeclare().QueueName;
channel.QueueBind(queueName, exchangeName, "rpc.get.customer.request", null);

var cunsumer = new EventingBasicConsumer(channel);
cunsumer.Received += Cunsumer_Received;

channel.BasicConsume(queueName, true, cunsumer);
Console.Write("Press [Enter] to exit.");
Console.ReadLine();

void Cunsumer_Received(object? sender, BasicDeliverEventArgs e)
{
    var body = e.Body.ToArray();
    var stringMessage = Encoding.UTF8.GetString(body);
    int customerId = int.Parse(stringMessage);
    Customer customer = _customerRepository.GetById(customerId);
    var customerByteArray = Encoding.UTF8.GetBytes( JsonConvert.SerializeObject(customer));
    var requestProperty = e.BasicProperties;
    
    var correlationID = requestProperty.CorrelationId;
    var routingKey = requestProperty.ReplyTo;

    var responseProperty = channel.CreateBasicProperties();
    responseProperty.CorrelationId = correlationID;
    System.Threading.Thread.Sleep(10000);
    channel.BasicPublish(exchangeName, routingKey, responseProperty, customerByteArray);


    Console.WriteLine($"[-] Logger...: {stringMessage}");
}