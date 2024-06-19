
namespace ShoppingList.Application.Tetsts.UseCases
{
    internal interface IGetProduct
    {
        Task<GetProductResponse> GetByIdAsync(Guid productId);
    }
}