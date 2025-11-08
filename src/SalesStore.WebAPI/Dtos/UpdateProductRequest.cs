using System.ComponentModel.DataAnnotations;

namespace SalesStore.WebAPI.Dtos;

public class UpdateProductRequest
{
    [Required(ErrorMessage = "Product name is required")]
    [StringLength(100, ErrorMessage = "Product name cannot exceed 100 characters")]
    public string Name { get; set; } = string.Empty;

    [Range(0.01, 100000000000, ErrorMessage = "The product price is invalid")]
    public decimal Price { get; set; }

    [Range(0, int.MaxValue, ErrorMessage = "The quantity in stock cannot be negative")]
    public int Quantity { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "The category ID is invalid")]
    public int CategoryId { get; set; }
}