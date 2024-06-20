
using FluentValidation.Results;
using ShoppingList.Application.Tetsts.Validators;
using ShoppingList.Domain.Contracts.Repositories;
using ShoppingList.Domain.Entities;

namespace ShoppingList.Application.Tetsts.UseCases;

internal class GetProduct(
    IProductRepository repository,
    IGetProductValidator validator) : IGetProduct
{
    public async Task<GetProductResponse> GetByIdAsync(Guid productId)
    {
        Product? product = await repository.GetById(productId);

        ValidationResult validationResult = validator.Validate(product);

        if (!validationResult.IsValid)
        {
            return new GetProductResponse
            {
                Errors = validationResult.Errors,
            };
        }

        return new GetProductResponse
        {
            Id = product.Id,
        };
    }
}