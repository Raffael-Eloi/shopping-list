using ShoppingList.Application.Models;
using ShoppingList.Domain.Entities;

namespace ShoppingList.Application.Tetsts.Mappers;

internal interface IProductMapper
{
    GetProductResponse Map(Product product);
}