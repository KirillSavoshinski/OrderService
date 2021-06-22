using OrderService.Entities;

namespace OrderService.Interfaces
{
    public interface IRabbitMqService
    {
        void Publish(Order order);
    }
}