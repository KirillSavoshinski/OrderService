using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using OrderService.Entities;

namespace OrderService.Controllers
{
    [ApiController]
    [Route("api/v1")]
    public class OrderController : ControllerBase
    {
        [HttpGet("getItems")]
        public ActionResult<IEnumerable<Item>> GetItems()
        {
            //
        }

        [HttpPost("orderItem")]
        public void OrderItem(int itemId, int quantity)
        {
            //
        }
    }
}