using Microsoft.AspNetCore.Mvc;
using OrderService.Interfaces;

namespace OrderService.Controllers
{
    [ApiController]
    [Route("api/v1")]
    public class OrderController : ControllerBase
    {
        private readonly IItemService _itemService;

        public OrderController(IItemService itemService)
        {
            _itemService = itemService;
        }
        // [HttpGet("getItems")]
        // public ActionResult<IEnumerable<Item>> GetItems()
        // {
        //     
        // }

        [HttpPost("orderItem")]
        public void OrderItem(int itemId, int quantity)
        {
            _itemService.AddOrder(itemId, quantity);
        }
    }
}