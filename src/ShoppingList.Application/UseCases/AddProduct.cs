using ShoppingList.Application.Contracts;
using ShoppingList.Application.DTO;
using ShoppingList.Application.Models;
using ShoppingList.Domain.Contracts.Repositories;
using ShoppingList.Domain.Entities;

namespace ShoppingList.Application.UseCases;

public class AddProduct(IProductRepository productRepository) : IAddProduct
{
    public async Task<ProductResponse> AddAsync(RequestProductDTO addProductDTO)
    {
        Product product = CreateProduct(addProductDTO);

        Guid productId = await productRepository.Add(product);

        return new ProductResponse
        {
            ProductId = productId
        };
    }

    private static Product CreateProduct(RequestProductDTO addProductDTO)
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