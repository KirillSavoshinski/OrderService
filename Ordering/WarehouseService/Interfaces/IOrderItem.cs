using System.Threading.Tasks;

namespace WarehouseService.Interfaces
{
    public interface IOrderItem
    {
        Task<bool> CreateOrder(int itemId, int quantity);
    }
}