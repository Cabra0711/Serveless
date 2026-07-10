namespace PedidosBackend.Models;

public class OrderItems : BaseEntity
{
    public Guid ProductId { get; set; }
    public Product? Product { get; set; }
    public  Guid OrderId { get; set; }
    public  Order? Order { get; set; }
    public decimal UnitPrice { get;  set; }
    public int Quantity { get; set; }
}