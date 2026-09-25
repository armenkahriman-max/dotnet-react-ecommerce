namespace Ecommerce.Api.Domain;

public class Order
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public decimal Total { get; set; }
    public string Status { get; set; } = "";
    public DateTime CreatedAt { get; set; }
}

//Enum Status Cancel Confirm InProgress; Payed or Conffirmed