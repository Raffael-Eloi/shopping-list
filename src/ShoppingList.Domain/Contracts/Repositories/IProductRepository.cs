using ShoppingList.Domain.Entities;

namespace ShoppingList.Domain.Contracts.Repositories;

public interface IProductRepository
{
    Task<Guid> Add(Product product);

    Task<Product?> GetById(Guid id);
}