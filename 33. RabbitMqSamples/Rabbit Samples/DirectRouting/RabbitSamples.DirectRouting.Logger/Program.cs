﻿using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System.Text;

var connectionFactory = new ConnectionFactory()
{
    HostName = "localhost",
};
using var connection = connectionFactory.CreateConnection();
using var channel = connection.CreateModel();
string exchangeName = "MailboxDirectExchange";
channel.ExchangeDeclare(exchangeName, ExchangeType.Direct, false, false, null);



var queueName = channel.QueueDeclare().QueueName;
channel.QueueBind(queueName, exchangeName, "message.mail", null);
channel.QueueBind(queueName, exchangeName, "message.sms", null);

var cunsumer = new EventingBasicConsumer(channel);
cunsumer.Received += Cunsumer_Received;

channel.BasicConsume(queueName, true, cunsumer);
Console.Write("Press [Enter] to exit.");
Console.ReadLine();

void Cunsumer_Received(object? sender, BasicDeliverEventArgs e)
{
    var body = e.Body.ToArray();
    var stringMessage = Encoding.UTF8.GetString(body);
    Console.WriteLine($"[-] Logger...: {stringMessage}");
}