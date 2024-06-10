using Microsoft.EntityFrameworkCore;
using probnykolo2.Models;

namespace probnykolo2.Data;

public class DatabaseContext : DbContext
{
    protected DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Pastry> Pastries { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderPastry> OrderPastries { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Client>().HasData(new List<Client>
        {
            new Client
            {
                ID = 1,
                FirstName = "Jan",
                LastName = "Kowalski"
            },
            new Client
            {
                ID = 2,
                FirstName = "Anna",
                LastName = "Nowak"
            }
        });
        modelBuilder.Entity<Employee>().HasData(new List<Employee>
        {
            new Employee
            {
                ID = 1,
                FirstName = "Piotr",
                LastName = "Nowak"
            },
            new Employee
            {
                ID = 2,
                FirstName = "Krzysztof",
                LastName = "Kowalski"
            }
        });
        modelBuilder.Entity<Pastry>().HasData(new List<Pastry>
        {
            new Pastry
            {
                ID = 1,
                Name = "Sernik",
                Price = 15.99m,
                Type = "ciasto"
            },
            new Pastry
            {
                ID = 2,
                Name = "Babka",
                Price = 12.99m,
                Type = "ciasto"
            }
        });
        modelBuilder.Entity<Order>().HasData(new List<Order>
        {
            new Order
            {
                ID = 1,
                AcceptedAt = DateTime.Parse("2021-12-10"),
                FulfilledAt = DateTime.Parse("2021-12-12"),
                Comments = "brak komentarza",
                ClientID = 1,
                EmployeeID = 1
            },
            new Order
            {
                ID = 2,
                AcceptedAt = DateTime.Parse("2021-04-07"),
                FulfilledAt = DateTime.Parse("2022-10-02"),
                Comments = "komentarz",
                ClientID = 2,
                EmployeeID = 2
            },
            new Order
            {
                ID = 3,
                AcceptedAt = DateTime.Parse("2024-06-01"),
                FulfilledAt = null,
                Comments = null,
                ClientID = 2,
                EmployeeID = 1
        }
        });
        modelBuilder.Entity<OrderPastry>().HasData(new List<OrderPastry>
        {
            new OrderPastry
            {
                OrderID = 1,
                PastryID = 1,
                Amount = 2
            },
            new OrderPastry
            {
                OrderID = 2,
                PastryID = 2,
                Amount = 1,
                Comments = "Lorem ipsum ..."
            },
            new OrderPastry
            {
                OrderID = 2,
                PastryID = 1,
                Amount = 3
            },
            new OrderPastry
            {
                OrderID = 1,
                PastryID = 2,
                Amount = 1
            }
        });
        
    }
}