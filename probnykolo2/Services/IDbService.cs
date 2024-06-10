using probnykolo2.Models;

namespace probnykolo2.Services;

public interface IDbService
{
    Task<IEnumerable<Order>> GetOrdersByLastName(string? clientLastName);
    Task<bool> DoesPastryExist(string pastryName);
    Task<bool> DoesClientExist(int clientId);
    Task<bool> DoesEmployeeExist(int employeeId);
    Task<Pastry> GetPastryByName(string pastryName);
    Task AddOrder(Order order);
    Task AddOrderPastries(List<OrderPastry> orderPastries);
}