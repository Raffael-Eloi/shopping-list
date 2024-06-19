using ShoppingList.Application.Contracts.UseCases;
using ShoppingList.Application.Models;
using ShoppingList.Domain.Contracts.Repositories;
using ShoppingList.Domain.Entities;

namespace ShoppingList.Application.UseCases;

public class AddProduct(IProductRepository productRepository) : IAddProduct
{
    public async Task<AddProductResponse> AddAsync(AddProductRequest addProductDTO)
    {
        Product product = CreateProduct(addProductDTO);

        Guid productId = await productRepository.Add(product);

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