using Application.Contracts;
using Application.DTO;
using Application.Models;
using Domain.Contracts.Repositories;
using Domain.Entities;

namespace Application.Services
{
    public class ProductWriteService : IProductWriteService
    {
        private readonly IProductRepository _productRepository;

        public ProductWriteService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ProductResponse> AddAsync(RequestProductDTO addProductDTO)
        {
            Product product = CreateProduct(addProductDTO);

            Guid productId = await _productRepository.Add(product);

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
}