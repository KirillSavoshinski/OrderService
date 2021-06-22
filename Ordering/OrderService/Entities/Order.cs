using OrderService.Enums;

namespace OrderService.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public int Quantity { get; set; }
        public OrderState OrderState { get; set; }
    }
}