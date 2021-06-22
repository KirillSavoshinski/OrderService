using System.Threading.Tasks;
using WarehouseService.Entities;

namespace WarehouseService.Interfaces
{
    public interface IOrderItem
    {
        Task<bool> CreateOrder(Order order);
    }
}