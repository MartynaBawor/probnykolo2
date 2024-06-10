using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace probnykolo2.Models;
[PrimaryKey(nameof(ID))]
public class Pastry
{
    public int ID { get; set; }
    [MaxLength(150)]
    public string Name { get; set; }
    [DataType("decimal")]
    [Precision(10, 2)]
    public decimal Price { get; set; }
    [MaxLength(40)]
    public string Type { get; set; }
    
    public ICollection<OrderPastry> OrderPastries { get; set; } = new List<OrderPastry>();
    
}