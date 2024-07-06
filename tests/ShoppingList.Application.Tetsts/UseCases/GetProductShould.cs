using FakeItEasy;
using FluentAssertions;
using FluentValidation.Results;
using ShoppingList.Application.Contracts.Mappers;
using ShoppingList.Application.Contracts.UseCases;
using ShoppingList.Application.Contracts.Validators;
using ShoppingList.Application.Models;
using ShoppingList.Application.UseCases;
using ShoppingList.Domain.Contracts.Repositories;
using ShoppingList.Domain.Entities;

namespace ShoppingList.Application.Tetsts.UseCases;

internal class GetProductShould
{
    private IProductRepository repositoryMock;

    private IGetProductValidator validatorMock;
    
    private IProductMapper mapperMock;
    
    private IGetProduct getProduct;

    [SetUp]
    public void Setup()
    {
		repositoryMock = A.Fake<IProductRepository>();

        validatorMock = A.Fake<IGetProductValidator>();

        mapperMock = A.Fake<IProductMapper>();

        getProduct = new GetProduct(
            repositoryMock, 
            validatorMock,
            mapperMock);

        A.CallTo(() => validatorMock.Validate(A<Product>._))
            .Returns(new ValidationResult());
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

        A.CallTo(() => mapperMock.Map(product))
            .Returns(new GetProductResponse
            {
                Id = productId,
            });

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

    [Test]
    public async Task Get_All_Products()
    {
        #region Arrange(Given)

        IEnumerable<Product> products =
        [
            new Product(),
            new Product(),
            new Product(),
        ];

        A.CallTo(() => repositoryMock.GetAll())
            .Returns(products);

        #endregion

        #region Act(When)

        IEnumerable<GetProductResponse> response = await getProduct.GetAllAsync();

        #endregion

        #region Assert(Then)

        response.Count().Should().Be(3);

        #endregion
    }
}