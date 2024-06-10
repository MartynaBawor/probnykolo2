using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace probnykolo2.Models;
[Table("Order_Pastry")]
[PrimaryKey(nameof(OrderID), nameof(PastryID))]
public class OrderPastry
{
    public int OrderID { get; set; }
    public int PastryID { get; set; }
    public int Amount { get; set; }
    [MaxLength(300)]
    public string? Comments { get; set; }
    
    [ForeignKey(nameof(OrderID))]
    public Order Order { get; set; } = null!;
    [ForeignKey(nameof(PastryID))]
    public Pastry Pastry { get; set; } = null!;
}