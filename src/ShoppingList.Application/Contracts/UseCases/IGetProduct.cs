using ShoppingList.Application.Models;

namespace ShoppingList.Application.Contracts.UseCases;

public interface IGetProduct
{
    Task<GetProductResponse> GetByIdAsync(Guid productId);

    Task<IEnumerable<GetProductResponse>> GetAllAsync();
}