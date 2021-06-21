using Microsoft.AspNetCore.Mvc;
using WarehouseService.Data;

namespace WarehouseService.Controllers
{
    [ApiController]
    [Route("api/v1")]
    public class WarehouseController : ControllerBase
    {
        private readonly DataContext _context;

        public WarehouseController(DataContext context)
        {
            _context = context;
        }

        [HttpPost("receiveItem")]
        public bool ReceiveItem(int itemId)
        {
            //gets message about the order
            return false;
        }
            
    }
}