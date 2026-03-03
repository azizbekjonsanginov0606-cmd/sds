namespace Domain.Models;

public class Order
{
    public int Id { get; set; }
    public int customeriId { set; get; }
    public decimal amount { set; get; }
    public DateTime CreatedAt { get; set; }
}
