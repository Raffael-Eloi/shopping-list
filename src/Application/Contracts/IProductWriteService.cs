using Application.DTO;
using Application.Models;

namespace Application.Contracts
{
    public interface IProductWriteService
    {
        Task<ProductResponse> AddAsync(RequestProductDTO addProductDTO);
    }
}