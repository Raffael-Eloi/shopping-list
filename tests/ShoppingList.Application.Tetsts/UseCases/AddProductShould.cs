using FakeItEasy;
using FluentAssertions;
using ShoppingList.Application.Contracts;
using ShoppingList.Application.DTO;
using ShoppingList.Application.Models;
using ShoppingList.Application.UseCases;
using ShoppingList.Domain.Contracts.Repositories;

namespace ShoppingList.Application.Tetsts.UseCases;

internal class AddProductShould
{
    [Test]
    public async Task Add_Product()
    {
        #region Arrange(Given)

        string name = "Manchester City Shirt";
        string description = "New manchester city shirt 2023/2024";
        decimal price = 200;
        int quantity = 10;

        RequestProductDTO addProductDTO = new()
        {
            Name = name,
            Description = description,
            Price = price,
            Quantity = quantity
        };

        var productRepositoryMock = A.Fake<IProductRepository>();

        IAddProduct addProduct = new AddProduct(productRepositoryMock);

        #endregion

        #region Act(When)

        ProductResponse response = await addProduct.AddAsync(addProductDTO);

        #endregion

        #region Assert(Then)

        response.Should().NotBeNull();
        
        response.IsValid.Should().BeTrue();

        response.ProductId.Should().NotBeNull();

        #endregion
    }
}