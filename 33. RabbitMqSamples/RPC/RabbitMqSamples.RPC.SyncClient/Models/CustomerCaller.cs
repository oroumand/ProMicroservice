using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace RabbitMqSamples.RPC.SyncClient.Models;
public class CustomerCaller
{
    private readonly IConnection _connection;
    private readonly IModel _model;
    private readonly EventingBasicConsumer _consumer;
    private readonly string replyTo = "rpc.get.customer.sync.client";
    private readonly string requestRoutKey = "rpc.get.customer.request";
    private readonly BlockingCollection<Customer> _customers = new BlockingCollection<Customer>();
    private readonly string _exchangeName = "RpcSampleExchange";
    public CustomerCaller()
    {
        var factory = new ConnectionFactory
        {
            HostName = "localhost",
        };
        _connection = factory.CreateConnection();
        _model = _connection.CreateModel();
        _model.ExchangeDeclare(_exchangeName, ExchangeType.Topic, false, false, null);
        string queueName = _model.QueueDeclare().QueueName;
        _model.QueueBind(queueName, _exchangeName, replyTo, null);
        _consumer = new EventingBasicConsumer(_model);
        _consumer.Received += _consumer_Received;
        _model.BasicConsume(queueName, true, _consumer);
    }

    private void _consumer_Received(object? sender, BasicDeliverEventArgs e)
    {
        var customerBytes = e.Body.ToArray();
        var customerString = System.Text.Encoding.UTF8.GetString(customerBytes);
        var customer = JsonConvert.DeserializeObject<Customer>(customerString);
        _customers.Add(customer);
    }

    public Customer Get(int customerId)
    {
        var message = System.Text.Encoding.UTF8.GetBytes(customerId.ToString());
        var props = _model.CreateBasicProperties();
        props.CorrelationId = customerId.ToString();
        props.ReplyTo = replyTo;

        _model.BasicPublish(_exchangeName, requestRoutKey, props, message);
        var customer = _customers.Take();
        return customer;
    }

    public void CloseConnection()
    {
        _connection.Close();
    }
}
