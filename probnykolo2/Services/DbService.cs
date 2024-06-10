using Microsoft.EntityFrameworkCore;
using probnykolo2.Data;
using probnykolo2.Models;

namespace probnykolo2.Services;

public class DbService : IDbService
{
    private readonly DatabaseContext _context;
    public DbService(DatabaseContext context)
    {
        _context = context;
    }

    public  async Task<IEnumerable<Order>> GetOrdersByLastName(string? clientLastName)
    {
        return await _context.Orders
            .Include(o => o.Client)
            .Include(o => o.OrderPastries)
            .ThenInclude(op => op.Pastry)
            .Where(o => o.Client.LastName == clientLastName || clientLastName == null)
            .ToListAsync();
    }

    public async Task<bool> DoesPastryExist(string pastryName)
    {
        return await _context.Pastries.AnyAsync(p => p.Name == pastryName);
    }

    public async Task<bool> DoesClientExist(int clientId)
    {
        return await _context.Clients.AnyAsync(c => c.ID == clientId);
    }

    public async Task<bool> DoesEmployeeExist(int employeeId)
    {
        return await _context.Employees.AnyAsync(e => e.ID == employeeId);
    }

    public async Task<Pastry> GetPastryByName(string pastryName)
    {
        return await _context.Pastries.FirstOrDefaultAsync(p => p.Name == pastryName);
    }

    public async Task AddOrder(Order order)
    {
        await _context.Orders.AddAsync(order);
        await _context.SaveChangesAsync();
    }

    public async Task AddOrderPastries(List<OrderPastry> orderPastries)
    {
        await _context.OrderPastries.AddRangeAsync(orderPastries);
        await _context.SaveChangesAsync();
    }
}