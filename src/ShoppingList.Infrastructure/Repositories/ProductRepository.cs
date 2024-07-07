using MongoDB.Driver;
using ShoppingList.Domain.Contracts.Repositories;
using ShoppingList.Domain.Entities;
using ShoppingList.Domain.Models;
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

    public async Task<IEnumerable<Product>> Get(GetProductFilter filter)
    {
        IEnumerable<Product> products = [];

        if (filter.Name is not null)
        {
            products = await context.Products
            .Find(product => product.Name.ToLower().Contains(filter.Name.ToLower()))
            .ToListAsync();
        }
        
        if (filter.Description is not null)
        {
            products = await context.Products
            .Find(product => product.Description.ToLower().Contains(filter.Description.ToLower()))
            .ToListAsync();
        }

        return products;
    }

    public Task<IEnumerable<Product>> GetAll()
    {
        return Task.FromResult(
            context.Products.Find(_ => true).ToEnumerable()
        );
    }
}