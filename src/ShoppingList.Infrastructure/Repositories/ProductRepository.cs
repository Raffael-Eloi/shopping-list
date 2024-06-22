using MongoDB.Driver;
using ShoppingList.Domain.Contracts.Repositories;
using ShoppingList.Domain.Entities;
using ShoppingList.Infrastructure.Database.Contexts;

namespace ShoppingList.Infrastructure.Repositories;

public class ProductRepository(ProductContext context) : IProductRepository
{
    public async Task Add(Product product)
    {
        await context.Products.InsertOneAsync(product);
    }

    public async Task<Product?> GetById(Guid id)
    {
        return await context.Products
            .Find(payment => payment.Id == id)
            .FirstOrDefaultAsync();
    }
}