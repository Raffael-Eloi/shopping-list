namespace ShoppingList.Application.Models;

public record AddProductRequest
{
    public AddProductRequest()
    {
        Name = string.Empty;
        Description = string.Empty;
    }

    public string Name { get; set; }

    public string Description { get; set; }

    public decimal Price { get; set; }

    public int Quantity { get; set; }
}