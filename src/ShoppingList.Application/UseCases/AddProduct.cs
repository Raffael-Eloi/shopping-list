using FluentValidation.Results;
using ShoppingList.Application.Contracts.UseCases;
using ShoppingList.Application.Contracts.Validators;
using ShoppingList.Application.Models;
using ShoppingList.Domain.Contracts.Repositories;
using ShoppingList.Domain.Entities;

namespace ShoppingList.Application.UseCases;

public class AddProduct(
    IProductRepository repository,
    IValidator validator) : IAddProduct
{
    public async Task<AddProductResponse> AddAsync(AddProductRequest request)
    {
        ValidationResult result = validator.Validate(request);

        if (!result.IsValid)
        {
            return new AddProductResponse(result.Errors);
        }

        Product product = CreateProduct(request);

        Guid productId = await repository.Add(product);

        return new AddProductResponse
        {
            ProductId = productId
        };
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
}