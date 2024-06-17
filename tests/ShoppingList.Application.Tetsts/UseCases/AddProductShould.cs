﻿using Application.Services;
using Moq;
using ShoppingList.Application.Contracts;
using ShoppingList.Application.DTO;
using ShoppingList.Application.Models;
using ShoppingList.Domain.Contracts.Repositories;

namespace ShoppingList.Application.Tetsts.UseCases;

internal class AddProductShould
{
    [Test]
    public async Task Add_New_Product()
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

        var productRepositoryMock = new Mock<IProductRepository>();

        IAddProduct addProduct = new AddProduct(productRepositoryMock.Object);

        #endregion

        #region Act(When)

        ProductResponse response = await addProduct.AddAsync(addProductDTO);

        #endregion

        #region Assert(Then)

        Assert.That(response, Is.Not.Null);

        Assert.Multiple(() =>
        {
            Assert.That(response.IsValid, Is.True);
            Assert.That(response.ProductId, Is.Not.Null);
        });

        #endregion
    }
}