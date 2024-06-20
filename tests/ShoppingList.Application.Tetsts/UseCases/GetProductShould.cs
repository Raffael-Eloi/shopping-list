using FakeItEasy;
using FluentAssertions;
using FluentValidation.Results;
using ShoppingList.Application.Tetsts.Validators;
using ShoppingList.Domain.Contracts.Repositories;
using ShoppingList.Domain.Entities;

namespace ShoppingList.Application.Tetsts.UseCases;

internal class GetProductShould
{
    private IProductRepository repositoryMock;

    private IGetProductValidator validatorMock;
    
    private IGetProduct getProduct;

    [SetUp]
    public void Setup()
    {
		repositoryMock = A.Fake<IProductRepository>();

        validatorMock = A.Fake<IGetProductValidator>();

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
    public async Task Validate_When_Get_By_Id()
    {
		#region Arrange(Given)

		var productId = Guid.NewGuid();

        Product? unexistingProduct = null;

        A.CallTo(() => repositoryMock.GetById(productId))
            .Returns(unexistingProduct);

        IEnumerable<ValidationFailure> errors = [
            new ValidationFailure("Name", "'Name' must not be empty.")
        ];

        var invalidResult = new ValidationResult(errors);

        A.CallTo(() => validatorMock.Validate(unexistingProduct))
            .Returns(invalidResult);

        #endregion

        #region Act(When)

        GetProductResponse response = await getProduct.GetByIdAsync(productId);

        #endregion

        #region Assert(Then)

        response.IsValid.Should().BeFalse();

        #endregion
    }
}