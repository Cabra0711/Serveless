using System;
using System.Collections.Generic;
using Amazon.DynamoDBv2.DataModel;
using PedidosBackend.Enum;

namespace PedidosBackend.Models;


public class Product : BaseEntity
{
    public String Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string Sku  { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public ProductCategory Category { get; set; }
    public bool LowStock { get; set; } = true;
    public Guid DeliveryId { get; set; }
    public Delivery? Deliveries { get; set; }
}