using System.Data;
using System.Transactions;
using Microsoft.AspNetCore.Mvc;
using probnykolo2.DTOs;
using probnykolo2.Models;
using probnykolo2.Services;

namespace probnykolo2.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ClientsController: ControllerBase
{
    private readonly IDbService _dbService;
    public ClientsController(IDbService dbService)
    {
        _dbService = dbService;
    }

    [HttpPost("{clientID}/orders")]
    public async Task<IActionResult> AddOrder(OrderToPostDTO orderToPost, int clientID)
    {
        if (!await _dbService.DoesClientExist(clientID))
        {
            return NotFound("Client does not exist");
        }

        if (!await _dbService.DoesEmployeeExist(orderToPost.EmployeeID))
        {
            return NotFound("Employee does not exist");
        }

        var order = new Order()
        {
            EmployeeID = orderToPost.EmployeeID,
            AcceptedAt = orderToPost.AcceptedAt,
            Comments = orderToPost.Comments,
            ClientID = clientID
        };

        var orderPastries = new List<OrderPastry>();
        foreach (var p in orderToPost.Pastries)
        {
            if (!await _dbService.DoesPastryExist(p.Name))
            {
                return NotFound("Pastry does not exist");
            }

            var pastry = await _dbService.GetPastryByName(p.Name);
            orderPastries.Add(new OrderPastry()
            {
                PastryID = pastry.ID,
                Amount = p.Amount,
                Order = order,
                Comments = p.Comments
            });
        }

        using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
        {
            await _dbService.AddOrder(order);
            await _dbService.AddOrderPastries(orderPastries);
            scope.Complete();
        }

        return Created("api/orders", new
        {
            ID = order.ID
        });
}
    
}