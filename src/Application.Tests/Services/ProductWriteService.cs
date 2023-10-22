using Domain.Contracts.Repositories;

namespace Application.Tests.Services
{
    internal class ProductWriteService : IProductWriteService
    {
        private readonly IProductRepository _productRepository;

        public ProductWriteService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Task<ProductResponse> Add(RequestProductDTO addProductDTO)
        {
            throw new NotImplementedException();
        }
    }
}