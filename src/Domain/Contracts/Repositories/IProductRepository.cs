using Domain.Entities;

namespace Domain.Contracts.Repositories
{
    public interface IProductRepository
    {
        Task<Guid> Add(Product product);
    }
}