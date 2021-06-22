using System;
using System.Threading.Tasks;
using OrderService.Data;
using OrderService.Entities;
using OrderService.Enums;
using OrderService.Interfaces;

namespace OrderService.Services
{
    public class ItemService : IItemService
    {
        private readonly IRabbitMqService _rabbitMqService;
        private readonly DataContext _context;

        public ItemService(IRabbitMqService rabbitMqService, DataContext context)
        {
            _rabbitMqService = rabbitMqService;
            _context = context;
        }

        public async Task AddOrder(int itemId, int quantity)
        {
            var order = new Order {ItemId = itemId, Quantity = quantity, OrderState = OrderState.InProcess};

            await using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                await _context.Orders.AddAsync(order);
                await _context.SaveChangesAsync();
                
                _rabbitMqService.Publish(order);
                await transaction.CommitAsync();
            }
            catch (Exception e)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
    }
}