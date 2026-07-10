using System.Collections.Generic;
using Amazon.DynamoDBv2.DataModel;
using PedidosBackend.Enum;

namespace PedidosBackend.Models;
public class Order : BaseEntity
{
    public decimal Subtotal { get; set; }
    public decimal Total { get; set; }
    public decimal Discount { get; set; }
    public DeliveryStatus Status { get; set; } = DeliveryStatus.Pending;
    public ICollection<OrderItems> OrderItems { get; set; } = new List<OrderItems>();
}