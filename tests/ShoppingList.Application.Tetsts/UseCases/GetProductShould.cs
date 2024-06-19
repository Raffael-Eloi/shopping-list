using FakeItEasy;
using FluentAssertions;
using ShoppingList.Domain.Contracts.Repositories;
using ShoppingList.Domain.Entities;

namespace ShoppingList.Application.Tetsts.UseCases;

internal class GetProductShould
{
    [Test]
    public async Task Get_By_Id()
    {
		#region Arrange(Given)

		var productId = Guid.NewGuid();

		var repositoryMock = A.Fake<IProductRepository>();

        var product = new Product
        {
            Id = productId,
        };

        A.CallTo(() => repositoryMock.GetById(productId))
            .Returns(product);

        IGetProduct getProduct = new GetProduct(repositoryMock);

        #endregion

        #region Act(When)

        GetProductResponse response = await getProduct.GetByIdAsync(productId);

        #endregion

        #region Assert(Then)

        response.Should().NotBeNull();

        response.Id.Should().Be(productId);

        #endregion
    }
}