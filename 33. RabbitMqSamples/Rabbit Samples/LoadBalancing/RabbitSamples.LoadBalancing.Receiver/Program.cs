using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System.Text;

var connectionFactory = new ConnectionFactory()
{
    HostName = "localhost",
};
using var connection = connectionFactory.CreateConnection();
using var channel = connection.CreateModel();
string queueName = "LoadBalancing";
channel.QueueDeclare(queueName, true, false, false, null);

var cunsumer = new EventingBasicConsumer(channel);
cunsumer.Received += Cunsumer_Received;

channel.BasicConsume(queueName, false, cunsumer);
Console.Write("Press [Enter] to exit.");
Console.ReadLine();

void Cunsumer_Received(object? sender, BasicDeliverEventArgs e)
{
    var body = e.Body.ToArray();
    var stringMessage = Encoding.UTF8.GetString(body);
    Console.WriteLine($"[-] Start Processing message...: {stringMessage}");
    Thread.Sleep(5000);
    Console.WriteLine($"[-] Finish Processing message...: {stringMessage}");
    channel.BasicAck(e.DeliveryTag, false);
}