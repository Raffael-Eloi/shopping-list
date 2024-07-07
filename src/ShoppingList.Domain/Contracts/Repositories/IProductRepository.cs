using ShoppingList.Domain.Entities;
using ShoppingList.Domain.Models;

namespace ShoppingList.Domain.Contracts.Repositories;

public interface IProductRepository
{
    Task Add(Product product);

    Task<Product?> GetById(Guid id);

    Task<IEnumerable<Product>> GetAll();

    Task<IEnumerable<Product>> Get(GetProductFilter filter);
}