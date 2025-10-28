using SalesStore.WebAPI.Models;
using SalesStore.WebAPI.Data;
using Microsoft.AspNetCore.Mvc;

namespace SalesStore.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly SalesStoreDbContext _context;

    public ProductsController(SalesStoreDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> CreateProductAsync([FromBody] Product product)
    {
        await _context.Products.AddAsync(product);
        await _context.SaveChangesAsync();

        return Ok(product);
    }
}