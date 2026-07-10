using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PedidosBackend.Data;
using PedidosBackend.Models;

namespace PedidosBackend.Controllers;

[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public ProductController(ApplicationDbContext context)
    {
        _context = context;
    }
    
    // GET api/values
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product>>> GetAll()
    {
        var products = await _context.Products.ToListAsync();
        return Ok(products);
    }

    // GET api/values/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> GetById(Guid id)
    {
        var product =  await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

        if (product == null)
        {
            return NotFound();
        }
        else
        {
            return Ok(product);
        }
    }

    // POST api/values
    [HttpPost]
    public async Task<ActionResult<Product>> Post([FromBody] Product product)
    {
        var products = await _context.Products.FirstOrDefaultAsync(p => p.Sku == product.Sku);

        if (string.IsNullOrWhiteSpace(product.Sku))
        {
            product.Sku = GenerateSku();
        }
        
        if(products != null)
        {
            return BadRequest(products);
        }
        else
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
        }
    }

    // PUT api/values/5
    [HttpPut("{id}")]
    public async Task<ActionResult<Product>> Put(Guid id, [FromBody] Product product)
    {
        if(!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        _context.Products.Entry(product).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return Ok(product);
    }

    // DELETE api/values/5
    [HttpDelete("{id}")]
    public async Task<ActionResult<Product>> Delete(Guid id)
    {
        var product = await _context.Products.FindAsync(id);
        if (product != null)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return Ok(product);
        }
        else
        {
            return NotFound();
        }
        
    }
    private static string GenerateSku()
    {
        var letters = Guid.NewGuid().ToString("N").Substring(0, 2).ToUpper();
        var numbers = Random.Shared.Next(100, 999);
        return $"FRM-{letters}-{numbers}";
    }
}