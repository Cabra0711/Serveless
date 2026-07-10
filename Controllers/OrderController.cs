using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PedidosBackend.Data;
using PedidosBackend.Models;

namespace PedidosBackend.Controllers;

[Route("api/Orders")]
public class OrderController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public OrderController(ApplicationDbContext context)
    {
        _context = context;
    }
    
    [Route("GetProductsById")]
    [HttpGet("{id}")]
    public async Task<ActionResult<IEnumerable<Order>>> GetById(Guid id)
    {
        var order =  await _context.Orders.FirstOrDefaultAsync(o => o.Id == id);

        if (order == null)
            return NotFound();
        else
            return Ok(order);
    }
    
}