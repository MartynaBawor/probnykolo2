namespace probnykolo2.DTOs;

public class OrderToReturnDTO
{
    public int ID { get; set; }
    public DateTime AcceptedAt { get; set; }
    public DateTime? FulfilledAt { get; set; }
    public string? Comments { get; set; }
    public ICollection<PastryInOrderDTO> Pastries { get; set; } = null!;
}

public class PastryInOrderDTO
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Amount { get; set; }
}
