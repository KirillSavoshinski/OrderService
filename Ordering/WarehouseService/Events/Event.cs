using System;
using WarehouseService.Entities;
using WarehouseService.Enums;

namespace WarehouseService.Events
{
    public class Event
    {
        public int Id { get; set; }
        public Item Item { get; set; }
        public int Quantity { get; set; }
        public EventType EventType { get; set; }
        public DateTime EventTime { get; set; } = DateTime.UtcNow;
    }
}