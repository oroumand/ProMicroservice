using RabbitMQ.Client;

var connectionFactory = new ConnectionFactory()
{
    HostName = "localhost",
};
using var connection = connectionFactory.CreateConnection();
using var channel = connection.CreateModel();

string exchangeName = "MailboxDirectExchange";
channel.ExchangeDeclare(exchangeName, ExchangeType.Direct, false, false, null);


Console.Write("Type your message and press [Enter]: ");
string message = Console.ReadLine() ?? "Default message";
Console.Write("type mail for sending email or sms for sending sms:");
string routKey = $"message.{Console.ReadLine()}";

var messageBytes = System.Text.Encoding.UTF8.GetBytes(message).ToArray();
channel.BasicPublish(exchangeName, routKey, null, messageBytes);

Console.WriteLine($"[*] your message sent: {message}");
Console.WriteLine("Press [Enter] to exit.");
Console.ReadLine();


