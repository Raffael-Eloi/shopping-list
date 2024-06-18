﻿using FluentAssertions;
using FluentValidation.Results;
using ShoppingList.Application.Models;

namespace ShoppingList.Application.Tetsts.Validators;

internal class AddProductValidatorShould
{
    private AddProductValidator validator;
    
    private AddProductRequest request;

    [SetUp]
    public void Setup()
    {
        validator = new AddProductValidator();

        request = new AddProductRequest
        {
            Name = "name"
        };
    }

    [Test]
    public void Return_Notification_When_Name_Is_Empty()
    {
		#region Arrange(Given)

        string name = string.Empty;

        request.Name = name;

        #endregion

        #region Act(When)

        ValidationResult result = validator.Validate(request);

        #endregion

        #region Assert(Then)

        result.Should().NotBeNull();

        result.IsValid.Should().BeFalse();

        result.Errors.First().ErrorMessage.Should().Be("'Name' must not be empty.");

        #endregion
    }
    
    [Test]
    public void Return_Notification_When_Price_Is_Invalid()
    {
        #region Arrange(Given)

        decimal invalidPrice = 0;

        request.Price = invalidPrice;

        #endregion

        #region Act(When)

        ValidationResult result = validator.Validate(request);

        #endregion

        #region Assert(Then)

        result.Should().NotBeNull();

        result.IsValid.Should().BeFalse();

        result.Errors.First().ErrorMessage.Should().Be("'Price' must not be empty.");

        #endregion
    }
}