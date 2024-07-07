
using FluentValidation.Results;
using ShoppingList.Application.Contracts.Mappers;
using ShoppingList.Application.Contracts.UseCases;
using ShoppingList.Application.Contracts.Validators;
using ShoppingList.Application.Models;
using ShoppingList.Domain.Contracts.Repositories;
using ShoppingList.Domain.Entities;
using ShoppingList.Domain.Models;

namespace ShoppingList.Application.UseCases;

public class GetProduct(
    IProductRepository repository,
    IGetProductValidator validator,
    IProductMapper mapper) : IGetProduct
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

    private GetProductResponse Map(Product? product)
    {
        return mapper.Map(product!);
    }

    public async Task<IEnumerable<GetProductResponse>> GetAsync(GetProductFilter filter)
    {
        IEnumerable<Product> products = await repository.Get(filter);

        return products.Select(Map);

    }

    public async Task<IEnumerable<GetProductResponse>> GetAllAsync()
    {
        IEnumerable<Product> products = await repository.GetAll();

        return products.Select(Map);
    }
}