using System;
using PedidosBackend.Enum;

namespace PedidosBackend.Models;

public class Product : BaseEntity
{
    public String Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public ProductCategory Category { get; set; }
    public bool LowStock { get; set; } = true;
}