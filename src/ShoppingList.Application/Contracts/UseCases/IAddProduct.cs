using ShoppingList.Application.Models;

namespace ShoppingList.Application.Contracts.UseCases;

public interface IAddProduct
{
    Task<AddProductResponse> AddAsync(AddProductRequest addProductDTO);
}