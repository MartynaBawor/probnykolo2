using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using probnykolo2.DTOs;
using probnykolo2.Services;

namespace probnykolo2.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrdersController : ControllerBase
{
    private readonly IDbService _dbService;
    public OrdersController(IDbService dbService)
    {
        _dbService = dbService;
    }

    [HttpGet]
    public async Task<IActionResult> GetOrders(string? clientLastName = null)
    {
        var orders = await _dbService.GetOrdersByLastName(clientLastName);

        return Ok(orders.Select(o => new OrderToReturnDTO()
        {
            ID = o.ID,
            AcceptedAt = o.AcceptedAt,
            FulfilledAt = o.FulfilledAt,
            Comments = o.Comments,
            Pastries = o.OrderPastries.Select(op => new PastryInOrderDTO()
            {
                Name = op.Pastry.Name,
                Price = op.Pastry.Price,
                Amount = op.Amount
            }).ToList()
        }));
    }
}