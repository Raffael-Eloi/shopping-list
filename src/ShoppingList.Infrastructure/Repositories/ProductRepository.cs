using ShoppingList.Domain.Contracts.Repositories;
using ShoppingList.Domain.Entities;

namespace ShoppingList.Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    public Task<Guid> Add(Product product)
    {
        throw new NotImplementedException();
    }

    public Task<Product?> GetById(Guid id)
    {
        throw new NotImplementedException();
    }
}