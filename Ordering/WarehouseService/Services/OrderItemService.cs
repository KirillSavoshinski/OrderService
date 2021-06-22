using System.Linq;
using System.Threading.Tasks;
using WarehouseService.Data;
using WarehouseService.Entities;
using WarehouseService.Enums;
using WarehouseService.Events;
using WarehouseService.Interfaces;

namespace WarehouseService.Services
{
    public class OrderItemService : IOrderItem
    {
        private readonly DataContext _context;

        public OrderItemService(DataContext context)
        {
            _context = context;
        }

        private int CountItems(int itemId)
        {
            var events = _context.Events.Where(e => e.Item.Id == itemId);
            var count = 0;

            foreach (var ev in events)
            {
                if (ev.EventType == EventType.Added)
                {
                    count += ev.Quantity;
                }

                count -= ev.Quantity;
            }

            return count;
        }

        public async Task<bool> CreateOrder(Order order)
        {
            var count = CountItems(order.ItemId);
            if (count >= order.Quantity)
            {
                var receiveEvent = new Event
                {
                    Item = await _context.Items.FindAsync(order.ItemId), 
                    Quantity = order.Quantity, 
                    EventType = EventType.Received
                };
                
                await _context.Events.AddRangeAsync(receiveEvent);
                return true;
            }

            return false;
        }
    }
}