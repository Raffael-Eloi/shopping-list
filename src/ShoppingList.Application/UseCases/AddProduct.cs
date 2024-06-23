using FluentValidation.Results;
using Serilog;
using ShoppingList.Application.Contracts.UseCases;
using ShoppingList.Application.Contracts.Validators;
using ShoppingList.Application.Models;
using ShoppingList.Domain.Contracts.Repositories;
using ShoppingList.Domain.Entities;

namespace ShoppingList.Application.UseCases;

public class AddProduct(
    IProductRepository repository,
    IAddProductValidator validator) : IAddProduct
{
    public async Task<AddProductResponse> AddAsync(AddProductRequest request)
    {
        Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .CreateLogger();

        if (RequestIsValid(request, out AddProductResponse invalidResponse))
        {
            return invalidResponse;
        }

        Product product = CreateProduct(request);

        await PersistProduct(product);

        Log.Information("Product {ProductId} added with request {@ProductRequest} in {CreatedAt}",
            product.Id,
            request,
            DateTime.UtcNow);

        return SuccessfulResponse(product.Id);
    }

    private bool RequestIsValid(AddProductRequest request, out AddProductResponse invalidResponse)
    {
        invalidResponse = new AddProductResponse();

        ValidationResult result = validator.Validate(request);

        if (!result.IsValid)
        {
            invalidResponse.Errors = result.Errors;
            return true;
        }

        return false;
    }

    private static Product CreateProduct(AddProductRequest addProductDTO)
    {
        return new()
        {
            Name = addProductDTO.Name,
            Description = addProductDTO.Description,
            Price = addProductDTO.Price,
            Quantity = addProductDTO.Quantity,
        };
    }

    private async Task PersistProduct(Product product)
    {
        await repository.Add(product);
    }

    private static AddProductResponse SuccessfulResponse(Guid productId)
    {
        return new AddProductResponse
        {
            ProductId = productId
        };
    }
}