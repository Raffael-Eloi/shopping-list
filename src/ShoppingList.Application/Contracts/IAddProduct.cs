using ShoppingList.Application.Models;

namespace ShoppingList.Application.Contracts;

public interface IAddProduct
{
    Task<AddProductResponse> AddAsync(AddProductRequest addProductDTO);
}