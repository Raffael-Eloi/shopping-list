using Application.DTO;
using Application.Models;

namespace ShoppingList.Application.Contracts;

public interface IAddProduct
{
    Task<ProductResponse> AddAsync(RequestProductDTO addProductDTO);
}