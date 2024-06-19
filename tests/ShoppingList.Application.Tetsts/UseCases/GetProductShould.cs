using FakeItEasy;
using FluentAssertions;
using ShoppingList.Domain.Contracts.Repositories;
using ShoppingList.Domain.Entities;

namespace ShoppingList.Application.Tetsts.UseCases;

internal class GetProductShould
{
    private IProductRepository repositoryMock;
    
    private IGetProduct getProduct;

    [SetUp]
    public void Setup()
    {
		repositoryMock = A.Fake<IProductRepository>();

        getProduct = new GetProduct(repositoryMock);
    }

    [Test]
    public async Task Get_By_Id()
    {
		#region Arrange(Given)

		var productId = Guid.NewGuid();

        var product = new Product
        {
            Id = productId,
        };

        A.CallTo(() => repositoryMock.GetById(productId))
            .Returns(product);

        #endregion

        #region Act(When)

        GetProductResponse response = await getProduct.GetByIdAsync(productId);

        #endregion

        #region Assert(Then)

        response.Should().NotBeNull();

        response.Id.Should().Be(productId);

        #endregion
    }
    
    [Test]
    public async Task Return_Notification_When_Product_Does_Not_Exist()
    {
		#region Arrange(Given)

		var productId = Guid.NewGuid();

        Product? unexistingProduct = null;

        A.CallTo(() => repositoryMock.GetById(productId))
            .Returns(unexistingProduct);

        #endregion

        #region Act(When)

        GetProductResponse response = await getProduct.GetByIdAsync(productId);

        #endregion

        #region Assert(Then)

        response.IsValid.Should().BeFalse();

        response.Errors.First().ErrorMessage.Should().Be("The Product does not exist.");

        #endregion
    }
}