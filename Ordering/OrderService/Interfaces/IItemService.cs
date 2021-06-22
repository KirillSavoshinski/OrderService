using System.Threading.Tasks;

namespace OrderService.Interfaces
{
    public interface IItemService
    {
        Task AddOrder(int itemId, int quantity);
    }
}