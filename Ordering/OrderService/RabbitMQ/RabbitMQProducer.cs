using System;
using System.Text;
using Newtonsoft.Json;
using OrderService.Entities;
using OrderService.Interfaces;
using RabbitMQ.Client;

namespace OrderService.RabbitMQ
{
    public class RabbitMqProducer : IRabbitMqService
    {
        public void Publish(Order order)
        {
            var factory = new ConnectionFactory
            {
                Uri = new Uri("amqp://guest:guest@localhost:5672")
            };

            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.ExchangeDeclare(exchange: "orders", type: ExchangeType.Fanout); 
            var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(order));

            channel.BasicPublish(exchange: "orders",
                routingKey: "",
                basicProperties: null,
                body: body);
        }
    }
}