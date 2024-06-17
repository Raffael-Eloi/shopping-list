using Application.DTO;
using Application.Models;

namespace Application.Contracts
{
    public interface IAddProduct
    {
        Task<ProductResponse> AddAsync(RequestProductDTO addProductDTO);
    }
}