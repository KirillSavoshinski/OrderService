using System.Collections.Generic;

namespace OrderService.Entities
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}