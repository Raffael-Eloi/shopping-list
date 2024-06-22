namespace ShoppingList.Domain.Entities;

public class Product
{
    public Product()
    {
        Id = Guid.NewGuid();
        Name = string.Empty;
        Description = string.Empty;
        CreatedAt = DateTime.UtcNow;
        Reviews = [];
    }

    public Guid Id { get; set; }

    public string Name { get; set; }

    public decimal Price { get; set; }

    public string Description { get; set; }

    public int Quantity { get; set; }

    public DateTime CreatedAt { get; set; }

    public ICollection<Review> Reviews { get; set; }
}