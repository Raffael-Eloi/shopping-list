namespace Application.Tests.Services
{
    internal interface IProductWriteService
    {
        Task<ProductResponse> Add(RequestProductDTO addProductDTO);
    }
}