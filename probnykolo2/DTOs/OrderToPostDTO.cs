namespace probnykolo2.DTOs;

public class OrderToPostDTO
{
    public int EmployeeID { get; set; }
    public DateTime AcceptedAt { get; set; }
    public string? Comments { get; set; }
    public ICollection<PastryToPostDTO> Pastries { get; set; } = null!;

}
public class PastryToPostDTO
{
    public string Name { get; set; }
    public int Amount { get; set; }
    public string? Comments { get; set; }
    
}