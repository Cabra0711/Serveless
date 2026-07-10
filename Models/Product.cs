using System;
using System.Collections.Generic;
using Amazon.DynamoDBv2.DataModel;
using PedidosBackend.Enum;

namespace PedidosBackend.Models;


public class Product : BaseEntity
{
    public String Name { get; set; } = string.Empty;
    public decimal Price  { get; set; }
    public string Sku  { get; set; } = string.Empty;
    public int Stock { get; set; }
    public ProductCategory Category { get; set; }
    public bool LowStock => Stock <= 5;
}