namespace SalesStore.WebAPI.Dtos;

public class UpdateProductRequest
{
    public string Name { get; set; }

    public decimal Price { get; set; }

    public int Quantity { get; set; }

    public string Category { get; set; }
}