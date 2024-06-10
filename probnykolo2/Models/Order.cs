using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace probnykolo2.Models;

public class Order
{
    public int ID { get; set; }
    public DateTime AcceptedAt { get; set; }
    public DateTime? FulfilledAt { get; set; }
    [MaxLength(300)]
    public string? Comments { get; set; }
    public int ClientID { get; set; }
    public int EmployeeID { get; set; }
    
    [ForeignKey(nameof(ClientID))]
    public Client Client { get; set; }
    [ForeignKey(nameof(EmployeeID))]
    public Employee Employee { get; set; }
    
    public ICollection<OrderPastry> OrderPastries { get; set; } = new List<OrderPastry>();
    
}