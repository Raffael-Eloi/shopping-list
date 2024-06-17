using ShoppingList.Application.DTO;
using ShoppingList.Application.Models;

namespace ShoppingList.Application.Contracts;

public interface IAddProduct
{
    Task<ProductResponse> AddAsync(RequestProductDTO addProductDTO);
}