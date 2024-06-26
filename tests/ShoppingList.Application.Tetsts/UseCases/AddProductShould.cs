﻿using FakeItEasy;
using FluentAssertions;
using FluentValidation.Results;
using Microsoft.Extensions.Logging;
using ShoppingList.Application.Contracts.UseCases;
using ShoppingList.Application.Contracts.Validators;
using ShoppingList.Application.Models;
using ShoppingList.Application.UseCases;
using ShoppingList.Domain.Contracts.Repositories;
using ShoppingList.Domain.Entities;

namespace ShoppingList.Application.Tetsts.UseCases;

internal class AddProductShould
{
    private IProductRepository productRepositoryMock;
    
    private IAddProductValidator validatorMock;
    
    private ILogger<AddProduct> loggerMock;
    
    private IAddProduct addProduct;
    
    private AddProductRequest request;

    [SetUp]
    public void Setup()
    {
        productRepositoryMock = A.Fake<IProductRepository>();

        validatorMock = A.Fake<IAddProductValidator>();

        loggerMock = A.Fake<ILogger<AddProduct>>();

        addProduct = new AddProduct(
            productRepositoryMock,
            validatorMock,
            loggerMock);

        request = new AddProductRequest();

        A.CallTo(() => validatorMock.Validate(request))
        .Returns(new ValidationResult());
    }

    [Test]
    public async Task Add_Product()
    {
        #region Arrange(Given)

        #endregion

        #region Act(When)

        AddProductResponse response = await addProduct.AddAsync(request);

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

        await addProduct.AddAsync(request);

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
    
    [Test]
    public async Task Validate_When_Add_Product()
    {
        #region Arrange(Given)

        IEnumerable<ValidationFailure> errors = [
            new ValidationFailure("Name", "'Name' must not be empty.")
        ];

        var invalidResult = new ValidationResult(errors);

        A.CallTo(() => validatorMock.Validate(request))
            .Returns(invalidResult);

        #endregion

        #region Act(When)

        AddProductResponse response = await addProduct.AddAsync(request);

        #endregion

        #region Assert(Then)

        A.CallTo(() => 
            productRepositoryMock.Add(A<Product>._))
            .MustNotHaveHappened();

        response.IsValid.Should().BeFalse();

        #endregion
    }
}