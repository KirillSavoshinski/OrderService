using System.Collections.Generic;
using WarehouseService.Events;

namespace WarehouseService.Entities
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Event> Events { get; set; }
    }
}