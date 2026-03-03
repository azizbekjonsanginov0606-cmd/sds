using Domain.Models;

namespace Infrastructure.Interfeas;

public interface IOrder
{
    Task<int> AddOrder(Order order);
    public Task<List<Order>> GetAllOrder();
    public Task<Order?> GetOrderById(int id);
    public Task UpdateOrder(Order order);
    public Task DeleteOrder(int id);
}
