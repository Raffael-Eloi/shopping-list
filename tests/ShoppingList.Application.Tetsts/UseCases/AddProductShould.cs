using FakeItEasy;
using FluentAssertions;
using ShoppingList.Application.Contracts;
using ShoppingList.Application.DTO;
using ShoppingList.Application.Models;
using ShoppingList.Application.UseCases;
using ShoppingList.Domain.Contracts.Repositories;
using ShoppingList.Domain.Entities;

namespace ShoppingList.Application.Tetsts.UseCases;

internal class AddProductShould
{
    private IProductRepository productRepositoryMock;

    private IAddProduct addProduct;
    
    private RequestProductDTO request;

    [SetUp]
    public void Setup()
    {
        productRepositoryMock = A.Fake<IProductRepository>();

        addProduct = new AddProduct(productRepositoryMock);

        request = new RequestProductDTO();
    }

    [Test]
    public async Task Add_Product()
    {
        #region Arrange(Given)

        #endregion

        #region Act(When)

        ProductResponse response = await addProduct.AddAsync(request);

        #endregion

        #region Assert(Then)

        response.Should().NotBeNull();
        
        response.IsValid.Should().BeTrue();

        response.ProductId.Should().NotBeNull();

        #endregion
    }
    
    [Test]
    public async Task Persist_When_Add_Product()
    {
        #region Arrange(Given)

        string name = "Manchester City Shirt";
        
        string description = "New manchester city shirt 2023/2024";
        
        decimal price = 200;
        
        int quantity = 10;

        request.Name = name;
        request.Description = description;
        request.Price = price;
        request.Quantity = quantity;

        #endregion

        #region Act(When)

        ProductResponse response = await addProduct.AddAsync(request);

        #endregion

        #region Assert(Then)

        A.CallTo(() => 
            productRepositoryMock.Add(
                A<Product>.That.Matches(
                    product => 
                        product.Name == name &&
                        product.Description == description &&
                        product.Price == price &&
                        product.Quantity == quantity
                    )))
            .MustHaveHappenedOnceExactly();

        #endregion
    }
}