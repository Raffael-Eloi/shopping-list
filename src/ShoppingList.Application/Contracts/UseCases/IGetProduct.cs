using ShoppingList.Application.Models;
using ShoppingList.Domain.Models;

namespace ShoppingList.Application.Contracts.UseCases;

public interface IGetProduct
{
    Task<GetProductResponse> GetByIdAsync(Guid productId);

    Task<IEnumerable<GetProductResponse>> GetAsync(GetProductFilter filter);

    Task<IEnumerable<GetProductResponse>> GetAllAsync();
}