
using ShoppingList.Domain.Contracts.Repositories;
using ShoppingList.Domain.Entities;

namespace ShoppingList.Application.Tetsts.UseCases;

internal class GetProduct(IProductRepository repository) : IGetProduct
{
    public async Task<GetProductResponse> GetByIdAsync(Guid productId)
    {
        Product? product = await repository.GetById(productId);

        return new GetProductResponse
        {
            Id = product.Id,
        };
    }
}