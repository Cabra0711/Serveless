using System.Collections.Generic;
using Amazon.DynamoDBv2.DataModel;
using PedidosBackend.Enum;

namespace PedidosBackend.Models;
[DynamoDBTable("Delivery")]
public class Delivery : BaseEntity
{
    public decimal Subtotal { get; set; }
    public decimal Total { get; set; }
    public decimal Discount { get; set; }
    public DeliveryStatus Status { get; set; } = DeliveryStatus.Pending;
    public ICollection<Product> Products { get; set; } = new List<Product>();
}