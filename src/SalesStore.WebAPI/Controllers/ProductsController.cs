﻿using SalesStore.WebAPI.Models;
using SalesStore.WebAPI.Data;
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
    public async Task<IActionResult> CreateProductAsync([FromBody] Product product)
    {
        await _context.Products.AddAsync(product);
        await _context.SaveChangesAsync();

        return CreatedAtAction(
            "GetProductById",
            new { id = product.Id },
            product);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllProductsAsync()
    {
        var products = await _context.Products.ToListAsync();

        return Ok(products);
    }

    [HttpGet("{id}", Name = "GetProductById")]
    public async Task<IActionResult> GetProductByIdAsync(int id)
    {
        var product = await _context.Products.FindAsync(id);

        if (product == null)
        {
            return NotFound();
        }

        return Ok(product);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProductAsync(int id, [FromBody] Product newProduct)
    {
        var product = await _context.Products.FindAsync(id);

        if(product == null)
        {
            return NotFound();
        }

        product.Name = newProduct.Name;
        product.Price = newProduct.Price;
        product.Quantity = newProduct.Quantity;
        product.Category = newProduct.Category;

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