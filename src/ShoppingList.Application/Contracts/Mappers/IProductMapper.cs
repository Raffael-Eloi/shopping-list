using ShoppingList.Application.Models;
using ShoppingList.Domain.Entities;

namespace ShoppingList.Application.Contracts.Mappers;

public interface IProductMapper
{
    GetProductResponse Map(Product product);
}