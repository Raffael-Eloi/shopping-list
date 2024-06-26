﻿using FluentAssertions;
using FluentValidation.Results;
using ShoppingList.Application.Models;
using ShoppingList.Application.Validators;

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
            Name = "name",
            Price = 1,
            Quantity = 1
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

        decimal invalidPrice = -1;

        request.Price = invalidPrice;

        #endregion

        #region Act(When)

        ValidationResult result = validator.Validate(request);

        #endregion

        #region Assert(Then)

        result.IsValid.Should().BeFalse();

        result.Errors.First().ErrorMessage.Should().Be("'Price' must be greater than 0.");

        #endregion
    }

    [TestCase(1, true)]
    [TestCase(0, false)]
    [TestCase(-1, false)]
    public void Validate_When_Price_Is_Invalid(decimal quantity, bool expectedValidationResult)
    {
        #region Arrange(Given)

        request.Price = quantity;

        #endregion

        #region Act(When)

        ValidationResult result = validator.Validate(request);

        #endregion

        #region Assert(Then)

        result.IsValid.Should().Be(expectedValidationResult);

        #endregion
    }

    [Test]
    public void Return_Notification_When_Quantity_Is_Invalid()
    {
        #region Arrange(Given)

        int invalidQuantity = -1;

        request.Quantity = invalidQuantity;

        #endregion

        #region Act(When)

        ValidationResult result = validator.Validate(request);

        #endregion

        #region Assert(Then)

        result.IsValid.Should().BeFalse();

        result.Errors.First().ErrorMessage.Should().Be("'Quantity' must be greater than 0.");

        #endregion
    }

    [TestCase(1, true)]
    [TestCase(0, false)]
    [TestCase(-1, false)]
    public void Validate_When_Quantity_Is_Invalid(int quantity, bool expectedValidationResult)
    {
        #region Arrange(Given)

        request.Quantity = quantity;

        #endregion

        #region Act(When)

        ValidationResult result = validator.Validate(request);

        #endregion

        #region Assert(Then)

        result.IsValid.Should().Be(expectedValidationResult);

        #endregion
    }
}