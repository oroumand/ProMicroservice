﻿using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

var connectionFactory = new ConnectionFactory()
{
    HostName = "localhost",
};
using var connection = connectionFactory.CreateConnection();
using var channel = connection.CreateModel();
string queueName = "helloWorld";
channel.QueueDeclare(queueName, false, false, false, null);

var cunsumer = new EventingBasicConsumer(channel);
cunsumer.Received += Cunsumer_Received;

channel.BasicConsume(queueName, true, cunsumer);
Console.Write("Press [Enter] to exit.");
Console.ReadLine();

void Cunsumer_Received(object? sender, BasicDeliverEventArgs e)
{
   var body =  e.Body.ToArray();   
    var stringMessage = Encoding.UTF8.GetString(body);
    Console.WriteLine($"[-] Message received: {stringMessage}");
}