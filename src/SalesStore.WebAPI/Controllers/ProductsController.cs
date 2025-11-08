using SalesStore.WebAPI.Models;
using SalesStore.WebAPI.Data;
using SalesStore.WebAPI.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
    public async Task<ActionResult<ProductResponse>> CreateProductAsync(CreateProductRequest productRequest)
    {
        var product = new Product
        {
            Name = productRequest.Name,
            Price = productRequest.Price,
            Quantity = productRequest.Quantity,
            CategoryId = productRequest.CategoryId
        };

        await _context.Products.AddAsync(product);
        await _context.SaveChangesAsync();

        var productResponse = new ProductResponse
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price,
            Quantity = product.Quantity,
            CategoryId = product.CategoryId
        };

        return CreatedAtAction(
            "GetProductById",
            new { id = productResponse.Id },
            productResponse);
    }

    [HttpGet]
    public async Task<ActionResult<List<ProductResponse>>> GetAllProductsAsync()
    {
        var productsResponse = await _context.Products
            .Select(p => new ProductResponse
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Quantity = p.Quantity,
                CategoryId = p.CategoryId
            })
            .ToListAsync();

        return Ok(productsResponse);
    }

    [HttpGet("{id}", Name = "GetProductById")]
    public async Task<ActionResult<ProductResponse>> GetProductByIdAsync(int id)
    {
        var productResponse = await _context.Products
            .Where(p => p.Id == id)
            .Select(p => new ProductResponse
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Quantity = p.Quantity,
                CategoryId = p.CategoryId
            })
            .SingleOrDefaultAsync();

        if (productResponse == null)
        {
            return NotFound();
        }

        return Ok(productResponse);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProductAsync(int id, UpdateProductRequest productUpdate)
    {
        var product = await _context.Products.FindAsync(id);

        if(product == null)
        {
            return NotFound();
        }

        product.Name = productUpdate.Name;
        product.Price = productUpdate.Price;
        product.Quantity = productUpdate.Quantity;
        product.CategoryId = productUpdate.CategoryId;

        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProductAsync(int id)
    {
        var product = await _context.Products.FindAsync(id);

        if (product == null)
        {
            return NotFound();
        }

        _context.Products.Remove(product);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}