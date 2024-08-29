using DAL.Models;

namespace DAL.OrderSystem
{
    public interface IDbCollectionGateway
    {
        Task<int> CreateOrder(Order order);
        Task<bool> OrderExists(int id);
        Task<int> CreateItem(Item item);
        Task<bool> ItemExists(int id);
    }
}
