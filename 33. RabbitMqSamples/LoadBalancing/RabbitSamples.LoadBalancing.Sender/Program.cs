using RabbitMQ.Client;

var connectionFactory = new ConnectionFactory()
{
    HostName = "localhost",
};
using var connection = connectionFactory.CreateConnection();
using var channel = connection.CreateModel();
string queueName = "LoadBalancing";
channel.QueueDeclare(queueName, true, false, false, null);
Console.Write("Type your message and press [Enter]: ");
string message = Console.ReadLine() ?? "Default message";
var messageProperty = channel.CreateBasicProperties();
messageProperty.Persistent = true;
for (int i = 0; i < 20; i++)
{
    var messageBytes = System.Text.Encoding.UTF8.GetBytes(message + i).ToArray();
    channel.BasicPublish("", queueName, messageProperty, messageBytes);
}

Console.WriteLine($"[*] your message sent: {message}");
Console.WriteLine("Press [Enter] to exit.");
Console.ReadLine();


