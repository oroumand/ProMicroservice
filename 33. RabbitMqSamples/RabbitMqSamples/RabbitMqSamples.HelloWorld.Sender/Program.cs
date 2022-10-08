using RabbitMQ.Client;

var connectionFactory = new ConnectionFactory()
{
    HostName = "localhost",
};
using var connection = connectionFactory.CreateConnection();
using var channel = connection.CreateModel();
string queueName = "helloWorld";
channel.QueueDeclare(queueName,false,false,false,null);
Console.Write("Type your message and press [Enter]: ");
string message = Console.ReadLine() ?? "Default message";
var messageBytes = System.Text.Encoding.UTF8.GetBytes(message).ToArray();
channel.BasicPublish("", queueName, null, messageBytes);
Console.WriteLine($"[*] your message sent: {message}");
Console.WriteLine("Press [Enter] to exit.");
Console.ReadLine();


