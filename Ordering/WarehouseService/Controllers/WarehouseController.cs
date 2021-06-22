using Microsoft.AspNetCore.Mvc;
using WarehouseService.Data;
using WarehouseService.Interfaces;

namespace WarehouseService.Controllers
{
    [ApiController]
    [Route("api/v1")]
    public class WarehouseController : ControllerBase
    {
        // private readonly IRabbitMqService _rabbitMqService;
        //
        // public WarehouseController(IRabbitMqService rabbitMqService)
        // {
        //     _rabbitMqService = rabbitMqService;
        // }

        [HttpPost("receiveItem")]
        public bool ReceiveItem(int itemId)
        {
            return false;
        }
            
    }
}