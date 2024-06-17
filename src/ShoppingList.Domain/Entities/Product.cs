using System.Collections.ObjectModel;

namespace ShoppingList.Domain.Entities;

public class Product
{
    public Product()
    {
        Id = Guid.NewGuid();
        Reviews = new Collection<Review>();
    }

    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public decimal Price { get; set; }

    public string Description { get; set; } = string.Empty;

    public int Quantity { get; set; }

    public Promotion? Promotion { get; set; }

    public ICollection<Review> Reviews { get; set; }
}