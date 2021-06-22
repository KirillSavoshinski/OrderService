using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using WarehouseService.Entities;
using WarehouseService.Interfaces;

namespace WarehouseService.RabbitMQ
{
    public class RabbitMQConsumer : BackgroundService
    { 
        private ILogger _logger;
        private ConnectionFactory _factory;
        private IConnection _connection;
        private IModel _channel;
        private string _queueName;
        private IOrderItem _orderItem;

        public RabbitMQConsumer(ILoggerFactory loggerFactory, IOrderItem orderItem)
        {
            _logger = loggerFactory.CreateLogger<RabbitMQConsumer>();
            _orderItem = orderItem;
            InitRabbitMQ();
        }

        private void InitRabbitMQ()
        {
            _factory = new ConnectionFactory
            {
                Uri = new Uri("amqp://guest:guest@localhost:5672")
            };

            _connection = _factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.ExchangeDeclare(exchange: "orders", type: ExchangeType.Fanout);
            _queueName = _channel.QueueDeclare().QueueName;
            _channel.QueueBind(queue: _queueName,
                exchange: "orders",
                routingKey: ""); 
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken) 
        {
            var consumer = new EventingBasicConsumer(_channel); 
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                var order = JsonConvert.DeserializeObject<Order>(message);
                _logger.LogInformation($"consumer received {order}");
                _orderItem.CreateOrder(order);
            };

            _channel.BasicConsume(queue: _queueName,
                autoAck: true,
                consumer: consumer);
            
            return Task.CompletedTask;
        }
    }
}