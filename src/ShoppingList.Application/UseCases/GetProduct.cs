
using FluentValidation.Results;
using ShoppingList.Application.Contracts.UseCases;
using ShoppingList.Application.Contracts.Validators;
using ShoppingList.Application.Models;
using ShoppingList.Domain.Contracts.Repositories;
using ShoppingList.Domain.Entities;

namespace ShoppingList.Application.UseCases;

public class GetProduct(
    IProductRepository repository,
    IGetProductValidator validator) : IGetProduct
{
    public async Task<GetProductResponse> GetByIdAsync(Guid productId)
    {
        Product? product = await GetProductById(productId);

        if (RequestIsValid(product, out GetProductResponse invalidResponse))
        {
            return invalidResponse;
        }

        return Map(product);
    }

    private async Task<Product?> GetProductById(Guid productId)
    {
        return await repository.GetById(productId);
    }

    private bool RequestIsValid(Product? product, out GetProductResponse invalidResponse)
    {
        invalidResponse = new GetProductResponse();

        ValidationResult result = validator.Validate(product);

        if (!result.IsValid)
        {
            invalidResponse.Errors = result.Errors;
            return true;
        }

        return false;
    }

    private static GetProductResponse Map(Product? product)
    {
        return new GetProductResponse
        {
            Id = product!.Id,
        };
    }
}