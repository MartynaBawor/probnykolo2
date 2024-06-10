using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace probnykolo2.Models;
[PrimaryKey(nameof(ID))]

public class Employee
{
    public int ID { get; set; }
    [MaxLength(100)]
    public string FirstName { get; set; }
    [MaxLength(120)]
    public string LastName { get; set; }
    public ICollection<Order> Orders { get; set; } = new List<Order>();
}